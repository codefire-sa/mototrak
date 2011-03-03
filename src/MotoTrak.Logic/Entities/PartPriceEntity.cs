using System;

namespace MotoTrak.Entities
{
    public class PartPriceEntity : Entity
    {
        #region [ Fields ]

        private int _partId;
        private DateTime _effectiveDate;
        private ValueComponent _partDiscount;
        private decimal _partAmount;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public PartPriceEntity()
            : base()
        {
            _partDiscount = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public int PartId
        {
            get { return _partId; }
            set { _partId = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

        public ValueComponent PartDiscount
        {
            get { return _partDiscount; }
            set { _partDiscount = value; }
        }

        public decimal PartAmount
        {
            get { return _partAmount; }
            set { _partAmount = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}