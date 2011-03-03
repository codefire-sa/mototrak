using System;

namespace MotoTrak.Entities
{
    public class ProgramEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private string _name = "";
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public ProgramEntity()
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

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}