using IEC61850.Server;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

// IEC 61850 API for the libiec61850 .NET wrapper library
namespace IEC61850
{
    // IEC 61850 server API.
    namespace Model
    {
        public enum SMVEvent
        {
            IEC61850_SVCB_EVENT_ENABLE = 1,
            IEC61850_SVCB_EVENT_DISABLE = 0,
        }

        public class SVControlBlock : ModelNode
        {
            private IntPtr self = IntPtr.Zero;
            public IedModel parent { get; }
            internal IntPtr Self { get => self; }

            [DllImport("iec61850", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr SVControlBlock_create(string name, IntPtr parent, string svID,string dataSet, UInt32 confRev, uint smpMod,
            UInt16 smpRate, uint optFlds, bool isUnicast);

            /// <summary>
            /// create a new Multicast/Unicast Sampled Value (SV) control block (SvCB)
            /// Create a new Sampled Value control block(SvCB) and add it to the given logical node(LN)
            /// </summary>
            /// <param name="name">name of the SvCB relative to the parent LN</param>
            /// <param name="parent">the parent LN</param>
            /// <param name="svID">the application ID of the SvCB</param>
            /// <param name="dataSet">the data set reference to be used by the SVCB</param>
            /// <param name="confRev">the configuration revision</param>
            /// <param name="smpMod">the sampling mode used</param>
            /// <param name="smpRate">the sampling rate used</param>
            /// <param name="optFlds"></param>
            /// <param name="isUnicast">the optional element configuration</param>
            public SVControlBlock(string name, IedModel parent, string svID, string dataSet, UInt32 confRev, uint smpMod,
                UInt16 smpRate, uint optFlds, bool isUnicast)
            {
                this.self = SVControlBlock_create(name, parent.self, svID, dataSet, confRev, smpMod, smpRate, optFlds, isUnicast);
                this.parent = parent;
            }

            public SVControlBlock(IntPtr self)
            {
                this.self = self;
            }

        }
    }
       
}
