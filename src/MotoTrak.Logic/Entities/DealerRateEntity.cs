using System;

namespace MotoTrak.Entities
{
    public class DealerRateEntity : Entity
    {
        #region [ Fields ]

        private int _dealerId;
        private DateTime _effectiveDate;
        private decimal _warrantyRateAmount;
        private decimal _serviceRateAmount;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public DealerRateEntity()
            : base()
        {
        }

        #endregion

        #region [ Properties ]

        public int DealerId
        {
            get { return _dealerId; }
            set { _dealerId = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

        public decimal WarrantyRateAmount
        {
            get { return _warrantyRateAmount; }
            set { _warrantyRateAmount = value; }
        }

        public decimal ServiceRateAmount
        {
            get { return _serviceRateAmount; }
            set { _serviceRateAmount = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}
