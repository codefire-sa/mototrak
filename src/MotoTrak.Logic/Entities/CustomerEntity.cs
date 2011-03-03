using System;

namespace MotoTrak.Entities
{
    public class CustomerEntity : Entity
    {
        #region [ Fields ]

        private string _title = "";
        private string _initials = "";
        private string _firstName = "";
        private string _lastName = "";
        private string _companyName = "";
        private string _referenceNumber = "";
        private ValueComponent _language;
        private ValueComponent _gender;
        private AddressComponent _postalAddress;
        private AddressComponent _physicalAddress;
        private string _homePhoneNumber = "";
        private string _workPhoneNumber = "";
        private string _faxNumber = "";
        private string _mobileNumber = "";
        private string _emailAddress = "";
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public CustomerEntity()
            : base()
        {
            _language = new ValueComponent();
            _gender = new ValueComponent();
            _postalAddress = new AddressComponent();
            _physicalAddress = new AddressComponent();
        }

        #endregion

        #region [ Properties ]

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public string ReferenceNumber
        {
            get { return _referenceNumber; }
            set { _referenceNumber = value; }
        }

        public ValueComponent Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public ValueComponent Gender
        {
            get { return _gender; }
            set { _gender = value; }
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

        public string HomePhoneNumber
        {
            get { return _homePhoneNumber; }
            set { _homePhoneNumber = value; }
        }

        public string WorkPhoneNumber
        {
            get { return _workPhoneNumber; }
            set { _workPhoneNumber = value; }
        }

        public string FaxNumber
        {
            get { return _faxNumber; }
            set { _faxNumber = value; }
        }

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}