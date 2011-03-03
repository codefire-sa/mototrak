using System;

namespace MotoTrak.Entities
{
    public class LanguageEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";

        #endregion

        #region [ Constructors ]

        public LanguageEntity()
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