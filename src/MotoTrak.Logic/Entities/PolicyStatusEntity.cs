using System;

namespace MotoTrak.Entities
{
    public class PolicyStatusEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";

        #endregion

        #region [ Constructors ]

        public PolicyStatusEntity()
            : base()
        {
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

        #endregion
    }
}