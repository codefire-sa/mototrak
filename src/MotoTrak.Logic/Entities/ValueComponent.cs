using System;

namespace MotoTrak.Entities
{
    public class ValueComponent
    {
        #region [ Fields ]

        private int _id;
        private string _code = "";
        private string _name = "";

        #endregion

        #region [ Constructor ]

        public ValueComponent()
        {
        }

        #endregion

        #region [ Properties ]

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        #region [ Methods ]

        public override string ToString()
        {
            return (_id == 0) ? "" : _code + " - " + _name;
        }

        #endregion
    }
}