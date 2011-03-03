using System;

namespace MotoTrak.Entities
{
    public class ClaimPartEntity : Entity
    {
        #region [ Fields ]

        private int _claimId;
        private ValueComponent _part;
        private ValueComponent _partType;
        private string _referenceNumber;
        private DateTime? _purchaseDate;
        private decimal _discountPercent;
        private decimal _quantity;
        private decimal _unitAmount;
        private decimal _itemAmount;
        private int _flags;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public ClaimPartEntity()
            : base()
        {
            _part = new ValueComponent();
            _partType = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public int ClaimId
        {
            get { return _claimId; }
            set { _claimId = value; }
        }

        public ValueComponent Part
        {
            get { return _part; }
            set { _part = value; }
        }

        public ValueComponent PartType
        {
            get { return _partType; }
            set { _partType = value; }
        }

        public string ReferenceNumber
        {
            get { return _referenceNumber; }
            set { _referenceNumber = value; }
        }

        public DateTime? PurchaseDate
        {
            get { return _purchaseDate; }
            set { _purchaseDate = value; }
        }

        public decimal DiscountPercent
        {
            get { return _discountPercent; }
            set { _discountPercent = value; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal UnitAmount
        {
            get { return _unitAmount; }
            set { _unitAmount = value; }
        }

        public decimal ItemAmount
        {
            get { return _itemAmount; }
            set { _itemAmount = value; }
        }

        public int Flags
        {
            get { return _flags; }
            set { _flags = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}