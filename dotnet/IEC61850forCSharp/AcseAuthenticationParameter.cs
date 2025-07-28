/*
 *  AcseAuthenticationParameter.cs
 *
 *  Copyright 2014 Michael Zillgith
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
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

// IEC 61850 API for the libiec61850 .NET wrapper library
namespace IEC61850
{
    /// <summary>
    /// Authentication mechanism used by AcseAuthenticator
    /// </summary>
    public enum AcseAuthenticationMechanism
    {
        /** Neither ACSE nor TLS authentication used */
        ACSE_AUTH_NONE = 0,

        /** Use ACSE password for client authentication */
        ACSE_AUTH_PASSWORD = 1,

        /** Use ACSE certificate for client authentication */
        ACSE_AUTH_CERTIFICATE = 2,

        /** Use TLS certificate for client authentication */
        ACSE_AUTH_TLS = 3
    }
    

    public class AcseAuthenticationParameter
    {
        [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr AcseAuthenticationParameter_create();

        [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
        static extern void AcseAuthenticationParameter_setAuthMechanism(IntPtr self, int mechanism);
        
        [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
        static extern void AcseAuthenticationParameter_setPassword(IntPtr self, string password);
        
        [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
        static extern int AcseAuthenticationParameter_getAuthMechanism(IntPtr self);

        private IntPtr self = IntPtr.Zero;

        public AcseAuthenticationParameter()
        {
            self = AcseAuthenticationParameter_create();
        }

        public AcseAuthenticationParameter(IntPtr self)
        {
            this.self = self;  
        }

        public void SetAuthMechanism(AcseAuthenticationMechanism acseAuthenticationMechanism)
        {
            AcseAuthenticationParameter_setAuthMechanism(self,(int)acseAuthenticationMechanism);
        }

        public void SetPassword(string password)
        {
            AcseAuthenticationParameter_setPassword(self, password);
        }

        public AcseAuthenticationMechanism GetAuthMechanism()
        {
            return (AcseAuthenticationMechanism)AcseAuthenticationParameter_getAuthMechanism(self);
        }
    }

    public class IsoApplicationReference
    {
        private IntPtr self = IntPtr.Zero;

        public IsoApplicationReference(IntPtr self)
        {
            this.self= self;
        }
    }
}
