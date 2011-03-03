using System;
namespace MotoTrak.Entities
{
    public class DealerEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";
        private ValueComponent _taxRate;
        private AddressComponent _postalAddress;
        private AddressComponent _physicalAddress;
        private string _phoneNumber = "";
        private string _faxNumber = "";
        private string _emailAddress = "";
        private BankDetailComponent _bankingDetail;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public DealerEntity()
            : base()
        {
            _taxRate = new ValueComponent();
            _postalAddress = new AddressComponent();
            _physicalAddress = new AddressComponent();
            _bankingDetail = new BankDetailComponent();
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

        public ValueComponent TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        public AddressComponent PostalAddress
        {
            get { return _postalAddress; }
            set { _postalAddress = value; }
        }

        public AddressComponent PhysicalAddress
        {
            get { return _physicalAddress; }
            set { _physicalAddress = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string FaxNumber
        {
            get { return _faxNumber; }
            set { _faxNumber = value; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public BankDetailComponent BankingDetail
        {
            get { return _bankingDetail; }
            set { _bankingDetail = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}