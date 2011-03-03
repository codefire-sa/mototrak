using System;

namespace MotoTrak.Entities
{
    public class UserEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";
        private string _password = "";
        private DateTime _passwordModifyDate;
        private DateTime? _lastLoginDate;
        private int _loginAttemptCount;
        private ValueComponent _dealer;
        private string _phoneNumber = "";
        private string _mobileNumber = "";
        private string _emailAddress = "";
        private ValueComponent _userType;
        private int _flags;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public UserEntity()
            : base()
        {
            _dealer = new ValueComponent();
            _userType = new ValueComponent();
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

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public DateTime PasswordModifyDate
        {
            get { return _passwordModifyDate; }
            set { _passwordModifyDate = value; }
        }

        public DateTime? LastLoginDate
        {
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }

        public int LoginAttemptCount
        {
            get { return _loginAttemptCount; }
            set { _loginAttemptCount = value; }
        }

        public ValueComponent Dealer
        {
            get { return _dealer; }
            set { _dealer = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
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

        public ValueComponent UserType
        {
            get { return _userType; }
            set { _userType = value; }
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