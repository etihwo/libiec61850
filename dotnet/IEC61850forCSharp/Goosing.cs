using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEC61850
{
    namespace Client
    {
        public partial class IedConnection
        {

            public GooseControlBlock GetGooseControlBlock(string gocbObjectReference)
            {
                var newGoCB = new GooseControlBlock(gocbObjectReference, this, connection);


                return newGoCB;
            }

        }
    }
}
