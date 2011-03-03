using System;
using System.Security.Principal;
using MotoTrak.Entities;

namespace MotoTrak.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class UserIdentity : IIdentity, IPrincipal
    {
        #region [ Fields ]

        private SecurityTicket _ticket;

        #endregion

        #region [ Constructors ]

        public UserIdentity(SecurityTicket ticket)
        {
            _ticket = ticket;
        }

        #endregion

        #region [ Properties ]

        public SecurityTicket Ticket
        {
            get { return _ticket; }
        }

        public string AuthenticationType
        {
            get { return "Codefire"; }
        }

        public bool IsAuthenticated
        {
            get { return _ticket.UserId > 0; }
        }

        public string Name
        {
            get { return _ticket.UserCode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public IIdentity Identity
        {
            get { return this; }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            return true;
        }

        #endregion
    }
}