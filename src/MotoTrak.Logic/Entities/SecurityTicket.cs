using System;

namespace MotoTrak.Entities
{
    public class SecurityTicket
    {
        #region [ Fields ]

        private int _userId;
        private string _userCode = "";
        private string _userName = "";
        private int _dealerId;

        #endregion

        #region [ Constructors ]

        public SecurityTicket()
        {
        }

        #endregion

        #region [ Properties ]

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public int DealerId
        {
            get { return _dealerId; }
            set { _dealerId = value; }
        }

        #endregion
    }
}