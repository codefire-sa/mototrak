using System;

namespace MotoTrak.Entities
{
    public class TaxRateValueEntity : Entity
    {
        private int _taxRateId;
        private DateTime _effectiveDate;
        private decimal _taxPercent;

        public TaxRateValueEntity()
            : base()
        {
        }

        public int TaxRateId
        {
            get { return _taxRateId; }
            set { _taxRateId = value; }
        }

        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

        public decimal TaxPercent
        {
            get { return _taxPercent; }
            set { _taxPercent = value; }
        }
    }
}