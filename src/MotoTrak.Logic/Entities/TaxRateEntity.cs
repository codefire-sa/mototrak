using System;

namespace MotoTrak.Entities
{
    public class TaxRateEntity : Entity
    {
        private string _code = "";
        private string _name = "";

        public TaxRateEntity()
            : base()
        {
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}