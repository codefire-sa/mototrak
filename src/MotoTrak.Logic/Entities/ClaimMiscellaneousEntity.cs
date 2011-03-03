using System;

namespace MotoTrak.Entities
{
    public class ClaimMiscellaneousEntity : Entity
    {
        #region [ Fields ]

        private int _claimId;
        private ValueComponent _miscellaneous;
        private string _supplierName = "";
        private string _invoiceNumber = "";
        private decimal _itemAmount;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public ClaimMiscellaneousEntity()
            : base()
        {
            _miscellaneous = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public int ClaimId
        {
            get { return _claimId; }
            set { _claimId = value; }
        }

        public ValueComponent Miscellaneous
        {
            get { return _miscellaneous; }
            set { _miscellaneous = value; }
        }

        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { _invoiceNumber = value; }
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