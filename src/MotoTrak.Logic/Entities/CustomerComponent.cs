using System;
using Codefire.Utilities;

namespace MotoTrak.Entities
{
    public class CustomerComponent
    {
        #region [ Fields ]

        private int _id;
        private string _title = "";
        private string _initials = "";
        private string _lastName = "";

        #endregion

        #region [ Constructor ]

        public CustomerComponent()
        {
        }

        #endregion

        #region [ Properties ]

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        #endregion

        #region [ Methods ]

        public override string ToString()
        {
            return (_id == 0) ? "" : StringUtility.BuildList(" ", _title, _initials, _lastName);
        }

        #endregion
    }
}