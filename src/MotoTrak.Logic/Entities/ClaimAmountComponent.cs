using System;

namespace MotoTrak.Entities
{
    public class ClaimAmountComponent
    {
        private decimal _partAmount;
        private decimal _labourAmount;
        private decimal _miscellaneousAmount;
        private decimal _taxAmount;
        private decimal _totalAmount;

        public ClaimAmountComponent()
        {
        }

        public decimal PartAmount
        {
            get { return _partAmount; }
            set { _partAmount = value; }
        }

        public decimal LabourAmount
        {
            get { return _labourAmount; }
            set { _labourAmount = value; }
        }

        public decimal MiscellaneousAmount
        {
            get { return _miscellaneousAmount; }
            set { _miscellaneousAmount = value; }
        }

        public decimal TaxAmount
        {
            get { return _taxAmount; }
            set { _taxAmount = value; }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }
    }
}