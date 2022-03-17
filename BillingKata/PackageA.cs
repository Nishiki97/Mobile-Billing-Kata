using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingKata
{
    internal class PackageA : Package
    {
        public override void GetCallType(CDR cdr)
        {
            base.GetCallType(cdr);
        }
    }
}
