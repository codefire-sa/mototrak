using System;

namespace MotoTrak.Entities
{
    public class AddressComponent
    {
        #region [ Fields ]

        private string _line1 = "";
        private string _line2 = "";
        private string _line3 = "";
        private string _line4 = "";
        private string _postCode = "";

        #endregion

        #region [ Constructor ]

        public AddressComponent()
        {
        }

        #endregion

        #region [ Properties ]

        public string Line1
        {
            get { return _line1; }
            set { _line1 = value; }
        }

        public string Line2
        {
            get { return _line2; }
            set { _line2 = value; }
        }

        public string Line3
        {
            get { return _line3; }
            set { _line3 = value; }
        }

        public string Line4
        {
            get { return _line4; }
            set { _line4 = value; }
        }

        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        #endregion
    }
}