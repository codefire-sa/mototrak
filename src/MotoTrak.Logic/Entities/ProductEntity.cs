using System;

namespace MotoTrak.Entities
{
    public class ProductEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";
        private short _contractDuration;
        private int _contractDistance;
        private ValueComponent _policyClass;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public ProductEntity()
            : base()
        {
            _policyClass = new ValueComponent();
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

        public short ContractDuration
        {
            get { return _contractDuration; }
            set { _contractDuration = value; }
        }

        public int ContractDistance
        {
            get { return _contractDistance; }
            set { _contractDistance = value; }
        }

        public ValueComponent PolicyClass
        {
            get { return _policyClass; }
            set { _policyClass = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}