using System;

namespace MotoTrak.Entities
{
    public class ClaimLabourEntity : Entity
    {
        #region [ Fields ]

        private int _claimId;
        private ValueComponent _labour;
        private decimal _hours;
        private decimal _itemAmount;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public ClaimLabourEntity()
            : base()
        {
            _labour = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public int ClaimId
        {
            get { return _claimId; }
            set { _claimId = value; }
        }

        public ValueComponent Labour
        {
            get { return _labour; }
            set { _labour = value; }
        }

        public decimal Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public decimal ItemAmount
        {
            get { return _itemAmount; }
            set { _itemAmount = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}