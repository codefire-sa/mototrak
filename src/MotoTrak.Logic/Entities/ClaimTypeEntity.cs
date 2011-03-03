using System;

namespace MotoTrak.Entities
{
    public class ClaimTypeEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";
        private ValueComponent _claimClass;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public ClaimTypeEntity()
            : base()
        {
            _claimClass = new ValueComponent();
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

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        public ValueComponent ClaimClass
        {
            get { return _claimClass; }
            set { _claimClass = value; }
        }

        #endregion
    }
}