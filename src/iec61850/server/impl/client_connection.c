/*
 *  client_connection.c
 *
 *  Copyright 2013-2025 Michael Zillgith
 *
 *  This file is part of libIEC61850.
 *
 *  libIEC61850 is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  libIEC61850 is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with libIEC61850.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  See COPYING file for the complete license text.
 */

#include "iec61850_server.h"
#include "iso_server.h"
#include "mms_mapping.h"
#include "control.h"
#include "stack_config.h"
#include "hal_thread.h"

#include "ied_server_private.h"

#include "libiec61850_platform_includes.h"

#if __STDC_VERSION__ >= 201112L
#include <stdatomic.h>
#else
#define _TLS_OWN_CNT_SEM 1
#endif

struct sClientConnection
{
#if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore tasksCountMutex;
#endif

    int tasksCount;
    void* serverConnectionHandle;

    bool isValid; /* connection is still valid and has not been closed in the meantime */

#ifdef _TLS_OWN_CNT_SEM
    #if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore ownerCountMutex;
    #endif /*#if (CONFIG_MMS_THREADLESS_STACK != 1) */
    int ownerCount;
#else
    _Atomic(int) ownerCount;
#endif /* _TLS_OWN_CNT_SEM */
};

ClientConnection
private_ClientConnection_create(void* serverConnectionHandle)
{
    ClientConnection self = (ClientConnection) GLOBAL_MALLOC(sizeof(struct sClientConnection));

    if (self)
    {
#if (CONFIG_MMS_THREADLESS_STACK != 1)
        self->tasksCountMutex = Semaphore_create(1);

        #ifdef _TLS_OWN_CNT_SEM
        self->ownerCount = Semaphore_create(1);
        #endif
#endif

        self->ownerCount = 1;
        self->tasksCount = 0;
        self->serverConnectionHandle = serverConnectionHandle;
        self->isValid = true;
    }

    return self;
}

static void
private_ClientConnection_destroy(ClientConnection self)
{
    if (self)
    {
#if (CONFIG_MMS_THREADLESS_STACK != 1)
        Semaphore_destroy(self->tasksCountMutex);

        #ifdef _TLS_OWN_CNT_SEM
        Semaphore_destroy(self->ownerCountMutex);
        #endif
#endif

        GLOBAL_FREEMEM(self);
    }
}

int
private_ClientConnection_getTasksCount(ClientConnection self)
{
    int tasksCount;

#if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_wait(self->tasksCountMutex);
#endif

    tasksCount = self->tasksCount;

#if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_post(self->tasksCountMutex);
#endif

    return tasksCount;
}

void
private_ClientConnection_increaseTasksCount(ClientConnection self)
{
#if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_wait(self->tasksCountMutex);
#endif

    self->tasksCount++;

#if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_post(self->tasksCountMutex);
#endif
}

void
private_ClientConnection_decreaseTasksCount(ClientConnection self)
{
#if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_wait(self->tasksCountMutex);
#endif

    self->tasksCount--;

#if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_post(self->tasksCountMutex);
#endif
}

void*
private_ClientConnection_getServerConnectionHandle(ClientConnection self)
{
    return self->serverConnectionHandle;
}

const char*
ClientConnection_getPeerAddress(ClientConnection self)
{
    if (self->isValid)
    {
        MmsServerConnection mmsConnection = (MmsServerConnection) self->serverConnectionHandle;

        return MmsServerConnection_getClientAddress(mmsConnection);
    }
    else
    {
        return NULL;
    }
}

const char*
ClientConnection_getLocalAddress(ClientConnection self)
{
    if (self->isValid)
    {
        MmsServerConnection mmsConnection = (MmsServerConnection) self->serverConnectionHandle;

        return MmsServerConnection_getLocalAddress(mmsConnection);
    }
    else
    {
        return NULL;
    }
}

void*
ClientConnection_getSecurityToken(ClientConnection self)
{
    if (self->isValid)
    {
        MmsServerConnection mmsConnection = (MmsServerConnection) self->serverConnectionHandle;

        return MmsServerConnection_getSecurityToken(mmsConnection);
    }
    else
    {
        return NULL;
    }
}

bool
ClientConnection_abort(ClientConnection self)
{
    //TODO set only a flag and let the connection thread close the connection!?
    //     this could be required for thread safety

    bool aborted = false;

    if (self->isValid)
    {
        MmsServerConnection mmsConnection = (MmsServerConnection) self->serverConnectionHandle;

        if (mmsConnection)
        {
            MmsServer mmsServer = MmsServerConnection_getServer(mmsConnection);

            aborted = MmsServer_abortConnection(mmsServer, mmsConnection);

            if (aborted)
            {
                /* remove reference to underlying connection. Instance cannot be used any longer */
                self->serverConnectionHandle = NULL;
            }
        }
    }

    return aborted;
}

ClientConnection
ClientConnection_claimOwnership(ClientConnection self)
{
#ifdef _TLS_OWN_CNT_SEM
    #if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_wait(self->ownerCountMutex);
    #endif
    self->ownerCount++;
    #if (CONFIG_MMS_THREADLESS_STACK != 1)
    Semaphore_post(self->ownerCountMutex);
    #endif
#else
    atomic_fetch_add(&(self->ownerCount), 1);
#endif

    return self;
}

void
ClientConnection_release(ClientConnection self)
{
    if (self)
    {
#ifdef _TLS_OWN_CNT_SEM

        int cnt;

        #if (CONFIG_MMS_THREADLESS_STACK != 1)
        Semaphore_wait(self->ownerCountMutex);
        #endif

        cnt = self->ownerCount;
        self->ownerCount--;

        #if (CONFIG_MMS_THREADLESS_STACK != 1)
        Semaphore_post(self->ownerCountMutex);
        #endif

        if (cnt == 1) {
            private_ClientConnection_destroy(self);
        }
#else
        if (atomic_fetch_sub(&(self->ownerCount), 1) == 1)
        {
            private_ClientConnection_destroy(self);
        }
#endif /* #ifdef _TLS_OWN_CNT_SEM */
    }
}
