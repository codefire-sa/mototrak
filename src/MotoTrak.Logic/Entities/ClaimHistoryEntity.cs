using System;

namespace MotoTrak.Entities
{
    public class ClaimHistoryEntity : Entity
    {
        #region [ Fields ]

        private int _claimId;
        private ValueComponent _claimStatus;
        private int _siteId;
        private string _userCode = "";

        #endregion

        #region [ Constructors ]

        public ClaimHistoryEntity()
            : base()
        {
            _claimStatus = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public int ClaimId
        {
            get { return _claimId; }
            set { _claimId = value; }
        }

        public ValueComponent ClaimStatus
        {
            get { return _claimStatus; }
            set { _claimStatus = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }

        #endregion
    }
}