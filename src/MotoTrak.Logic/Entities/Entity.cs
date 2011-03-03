using System;

namespace MotoTrak.Entities
{
    public abstract class Entity
    {
        #region [ Fields ]

        private int _id;
        private int _createUserId;
        private DateTime _createDate;
        private int _modifyUserId;
        private DateTime _modifyDate;
        private bool _isActive;

        #endregion

        #region [ Constructors ]

        protected Entity()
        {
        }

        #endregion

        #region [ Properties ]

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int CreateUserId
        {
            get { return _createUserId; }
            set { _createUserId = value; }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public int ModifyUserId
        {
            get { return _modifyUserId; }
            set { _modifyUserId = value; }
        }

        public DateTime ModifyDate
        {
            get { return _modifyDate; }
            set { _modifyDate = value; }
        }

        public Boolean IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        #endregion
    }
}