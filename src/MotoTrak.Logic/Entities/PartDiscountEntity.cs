using System;

namespace MotoTrak.Entities
{
    public class PartDiscountEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";
        private decimal _stockPercent;
        private decimal _emergencyPercent;
        private decimal _servicePercent;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public PartDiscountEntity()
            : base()
        {
        }

        #endregion

        #region [ Properties ]

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

        public decimal StockPercent
        {
            get { return _stockPercent; }
            set { _stockPercent = value; }
        }

        public decimal EmergencyPercent
        {
            get { return _emergencyPercent; }
            set { _emergencyPercent = value; }
        }

        public decimal ServicePercent
        {
            get { return _servicePercent; }
            set { _servicePercent = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}