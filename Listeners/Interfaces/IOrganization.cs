using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IOrganization
    {
        public string Name { get; set; }

        public string LittleName { get; set; }

        public string Requisites { get; set; }

        public string INN { get; set; }

        public string KPP { get; set; }

        public string BIK { get; set; }

        public string PersonalAccount { get; set; }

        public string PaymentAccount { get; set; }

        public string OnlyTreasureAccount { get; set; }

        public string TreasureAccount { get; set; }
        public string Director { get; set; }

        public string License { get; set; }

        public string Bank { get; set; }
    }
}
