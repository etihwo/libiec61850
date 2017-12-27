using IEC61850.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IEC61850
{
    namespace Client
    {
        /// <summary>
        /// Goose control block (GoCB) representation.
        /// </summary>
        /// <description>
        /// This class is used as a client side representation (copy) of a goose control block (GoCB).
        /// Values from the server will only be read when the GetGoCBValues method is called.
        /// Values at the server are only affected when the SetGoCBValues method is called.
        /// </description>
        public class GooseControlBlock
        {
            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr ClientGooseControlBlock_create(string dataAttributeReference);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_destroy(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr IedConnection_getGoCBValues(IntPtr connection, out int error, string goCBReference, IntPtr updateGoCB);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void IedConnection_setGoCBValues(IntPtr connection, out int error, IntPtr goCB, UInt32 parametersMask, bool singleRequest);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            static extern bool ClientGooseControlBlock_getGoEna(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_setGoEna(IntPtr self, bool rptEna);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr ClientGooseControlBlock_getDatSet(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_setDatSet(IntPtr self, string dataSetReference);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr ClientGooseControlBlock_getGoID(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_setGoID(IntPtr self, string goId);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern UInt32 ClientGooseControlBlock_getConfRev(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            static extern bool ClientGooseControlBlock_getNdsComm(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern UInt32 ClientGooseControlBlock_getMinTime(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern UInt32 ClientGooseControlBlock_getMaxTime(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.I1)]
            static extern bool ClientGooseControlBlock_getFixedOffs(IntPtr self);

            /* MMS_OCTET_STRING */
            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr ClientGooseControlBlock_getDstAddress_addr(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_setDstAddress_addr(IntPtr self, IntPtr macAddr);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern Byte ClientGooseControlBlock_getDstAddress_priority(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_setDstAddress_priority(IntPtr self, Byte priorityValue);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern UInt16 ClientGooseControlBlock_getDstAddress_vid(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_setDstAddress_vid(IntPtr self, UInt16 vidValue);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern UInt16 ClientGooseControlBlock_getDstAddress_appid(IntPtr self);

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern void ClientGooseControlBlock_setDstAddress_appid(IntPtr self, UInt16 appidValue);

            private IntPtr self;
            private IntPtr connection;
            private IedConnection iedConnection = null;
            private string objectReference;

            
            private bool flagGoEna = false;
            private bool flagGoId = false;
            private bool flagDataSetReference = false;
            private bool flagConfRev = false;
            private bool flagNdsComm = false;
            private bool flagDstAddressAddr = false;
            private bool flagDstAddressPriority = false;
            private bool flagdstAddressVid = false;
            private bool flagdstAddressAppId = false;
            private bool flagMinTime = false;
            private bool flagMaxTime = false;
            private bool flagFixedOffs = false;

            private void resetSendFlags()
            {
                flagGoEna = false;
                flagGoId = false;
                flagDataSetReference = false;
                flagConfRev = false;
                flagNdsComm = false;
                flagDstAddressAddr = false;
                flagDstAddressPriority = false;
                flagdstAddressVid = false;
                flagdstAddressAppId = false;
                flagMinTime = false;
                flagMaxTime = false;
                flagFixedOffs = false;
            }

            internal GooseControlBlock(string objectReference, IedConnection iedConnection, IntPtr connection)
            {
                self = ClientGooseControlBlock_create(objectReference);
                this.iedConnection = iedConnection;
                this.connection = connection;
                this.objectReference = objectReference;
            }

            ~GooseControlBlock()
            {
                if (self != IntPtr.Zero)
                {
                    ClientGooseControlBlock_destroy(self);
                    self = IntPtr.Zero;
                }
            }

            public string GetObjectReference()
            {
                return this.objectReference;
            }

            /// <summary>
            /// Read access to attributes of a GOOSE control block (GoCB) at the connected server. A GoCB contains the configuration values for a single GOOSE publisher. 
            /// </summary>
            /// <exception cref="IedConnectionException">This exception is thrown if there is a connection or service error</exception>
            public void GetGoCBValues()
            {
                int error;

                IedConnection_getGoCBValues(connection, out error, objectReference, self);

                if (error != 0)
                    throw new IedConnectionException("getGoCBValues service failed", error);
            }

            /// <summary>
            /// Write changed RCB values to the server.
            /// </summary>
            /// <description>
            /// This function will only write the GoCB values that were set by one of the setter methods.
            /// The GoCB values are sent by a single MMS write request.
            /// </description>
            /// <exception cref="IedConnectionException">This exception is thrown if there is a connection or service error</exception>
            public void SetGoCBValues()
            {
                SetGoCBValues(true);
            }

            /// <summary>
            /// Write changed GoCB values to the server.
            /// </summary>
            /// <description>
            /// This function will only write the GoCB values that were set by one of the setter methods.
            /// </description>
            /// <exception cref="IedConnectionException">This exception is thrown if there is a connection or service error</exception>
            /// <param name='singleRequest'>
            /// If true the values are sent by single MMS write request. Otherwise the values are all sent by their own MMS write requests.
            /// </param>
			public void SetGoCBValues(bool singleRequest)
            {
                UInt32 parametersMask = 0;

                if (flagGoEna)
                    parametersMask += 1;

                if (flagGoId)
                    parametersMask += 2;

                if (flagDataSetReference)
                    parametersMask += 4;

                if (flagConfRev)
                    parametersMask += 8;

                if (flagNdsComm)
                    parametersMask += 16;

                if (flagDstAddressAddr || flagdstAddressAppId || flagDstAddressPriority || flagdstAddressVid)
                    parametersMask += 32;

                if (flagMinTime)
                    parametersMask += 64;

                if (flagMaxTime)
                    parametersMask += 128;

                if (flagFixedOffs)
                    parametersMask += 256;

                int error;

                IedConnection_setGoCBValues(connection, out error, self, parametersMask, singleRequest);

                resetSendFlags();

                if (error != 0)
                    throw new IedConnectionException("setGoCBValues service failed", error);

            }

            /// <summary>
            /// Check if goosing is currently enabled
            /// </summary>
            /// <returns>
            /// true, if goosing is enabled, false otherwise
            /// </returns>
            public bool GetGoEna()
            {
                return ClientGooseControlBlock_getGoEna(self);
            }

            /// <summary>
            /// Sets goose enable flag. Use this to enable goosing
            /// </summary>
            /// <param name='goEna'>
            /// true to enable goosing, false to disable
            /// </param>
            public void SetGoEna(bool goEna)
            {
                ClientGooseControlBlock_setGoEna(self, goEna);
                flagGoEna = true;
            }

            /// <summary>
            /// Gets the goose identifier.
            /// </summary>
            /// <returns>
            /// The goose identifier.
            /// </returns>
            public string GetGoId()
            {
                IntPtr rptIdPtr = ClientGooseControlBlock_getGoID(self);

                return Marshal.PtrToStringAnsi(rptIdPtr);
            }

            /// <summary>
            /// Sets the GoId (goose ID) of the GoCB
            /// </summary>
            /// <param name='goId'>
            /// The new GoId
            /// </param>
            public void SetGoId(string goId)
            {
                ClientGooseControlBlock_setGoID(self, goId);
                flagGoId = true;
            }

            /// <summary>
            /// Gets the data set reference of the associated data set
            /// </summary>
            /// <returns>
            /// The data set reference.
            /// </returns>
            public string GetDataSetReference()
            {
                IntPtr dataSetRefPtr = ClientGooseControlBlock_getDatSet(self);

                return Marshal.PtrToStringAnsi(dataSetRefPtr);
            }

            /// <summary>
            /// Sets the data set reference. Use this method to select the associated data set for the GoCB
            /// </summary>
            /// <param name="dataSetReference">The data set reference.</param>
			public void SetDataSetReference(string dataSetReference)
            {
                ClientGooseControlBlock_setDatSet(self, dataSetReference);

                flagDataSetReference = true;
            }

            /// <summary>
            /// Gets the configuration revision of the GoCB
            /// </summary>
            /// <returns>
            /// The conf rev.
            /// </returns>
            public UInt32 GetConfRev()
            {
                return ClientGooseControlBlock_getConfRev(self);
            }

            /// <summary>
            /// Check if GoCB needs commissioning
            /// </summary>
            /// <returns>
            /// true, the GoCB needs commissioning
            /// </returns>
            public bool GetNdsComm()
            {
                return ClientGooseControlBlock_getNdsComm(self);
            }

            /// <summary>
            /// Gets the destination adress of GoCB
            /// </summary>
            /// Returns the destination adress of the last received GetGoValues service response.
            /// 
            /// <returns>The destination adress</returns>
            public byte[] GetDstAddressAddr()
            {
                IntPtr getDstAddressAddrRef = ClientGooseControlBlock_getDstAddress_addr(self);

                if (getDstAddressAddrRef == IntPtr.Zero)
                    return null;
                else
                {
                    MmsValue dstAddressAddr = new MmsValue(getDstAddressAddrRef);

                    return dstAddressAddr.getOctetString();
                }
            }

            /// <summary>
            /// Sets the destination adress of GoCB
            /// </summary>
            /// <param name="dstAddressAddr">The destination adress</param>
            public void SetDstAddressAddr(byte[] dstAddressAddr)
            {
                flagDstAddressAddr = true;

                MmsValue dstAddress_Addr = MmsValue.NewOctetString(dstAddressAddr.Length);

                dstAddress_Addr.setOctetString(dstAddressAddr);

                ClientGooseControlBlock_setDstAddress_addr(self, dstAddress_Addr.valueReference);
            }

            /// <summary>
            /// Gets the VLAN priority of GoCB
            /// </summary>
            /// <returns>The VLAN priority</returns>
            public Byte GetDstAddressPriority()
            {
                return ClientGooseControlBlock_getDstAddress_priority(self);
            }

            /// <summary>
            /// Sets the VLAN priority of GoCB
            /// </summary>
            /// <param name="dstAddressPriority">The new VLAN priority</param>
            public void GetDstAddressPriority(Byte dstAddressPriority)
            {
                flagDstAddressPriority = true;

                ClientGooseControlBlock_setDstAddress_priority(self, dstAddressPriority);
            }

            /// <summary>
            /// Gets the VLAN identifier of GoCB
            /// </summary>
            /// <returns>The VLAN identifier</returns>
            public UInt16 GetDstAddressVid()
            {
                return ClientGooseControlBlock_getDstAddress_vid(self);
            }

            /// <summary>
            /// Sets the VLAN identifier of GoCB
            /// </summary>
            /// <param name="dstAddressVid">The new VLAN identifier</param>
            public void SetDstAddressVid(UInt16 dstAddressVid)
            {
                flagdstAddressVid = true;

                ClientGooseControlBlock_setDstAddress_vid(self, dstAddressVid);
            }

            /// <summary>
            /// Gets the application identifier of GoCB
            /// </summary>
            /// <returns>The application identifier</returns>
            public UInt16 GetDstAddressAppId()
            {
                return ClientGooseControlBlock_getDstAddress_appid(self);
            }

            /// <summary>
            /// Sets the application identifier of GoCB
            /// </summary>
            /// <param name="dstAddressAppId">The new application identifier</param>
            public void setDstAddressAppId(UInt16 dstAddressAppId)
            {
                flagdstAddressAppId = true;

                ClientGooseControlBlock_setDstAddress_appid(self, dstAddressAppId);
            }

            /// <summary>
            /// Gets the minimum time
            /// </summary>
            /// <returns>
            /// The time in ms.
            /// </returns>
			public UInt32 GetMinTime()
            {
                return ClientGooseControlBlock_getMinTime(self);
            }

            /// <summary>
            /// Gets the maximum time.
            /// </summary>
            /// <returns>
            /// The buffer time in ms.
            /// </returns>
			public UInt32 GetMaxTime()
            {
                return ClientGooseControlBlock_getMaxTime(self);
            }

            /// <summary>
            /// Check if GoCB is fixed encoded
            /// </summary>
            /// <returns>
            /// true, the GoCB is fixed encoded
            /// </returns>
			public bool GetFixedOffs()
            {
                return ClientGooseControlBlock_getFixedOffs(self);
            }

        }
    }
}
