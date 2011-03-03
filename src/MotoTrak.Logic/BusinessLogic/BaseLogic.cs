using System;
using MotoTrak.DataLogic;
using MotoTrak.Entities;
using Codefire.Storm;

namespace MotoTrak.BusinessLogic
{
    public abstract class BaseLogic
    {
        #region [ Fields ]

        private int _errorCode = 0;
        private string _errorMessage = "";
        private SecurityTicket _ticket;
        
        #endregion

        #region [ Constructors ]

        protected BaseLogic(SecurityTicket ticket)
        {
            _ticket = ticket;
        }

        #endregion

        #region [ Properties ]

        public int ErrorCode
        {
            get { return _errorCode; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public SecurityTicket Ticket
        {
            get { return _ticket; }
        }

        #endregion

        #region [ Methods ]

        #region [ Protected ]

        protected void SetSuccess()
        {
            _errorCode = 0;
            _errorMessage = "";
        }

        protected void SetError(int code, string message)
        {
            _errorCode = code;
            _errorMessage = message;
        }

        protected MotoTrakCatalog CreateCatalog()
        {
            var catalog = new MotoTrakCatalog();
            catalog.CurrentUser = _ticket.UserId;

            return catalog;
        }

        #endregion

        #endregion
    }
}