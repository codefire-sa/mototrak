using System;
using System.Collections.Generic;

namespace MotoTrak.Entities
{
    public class AjaxMessage
    {
        #region [ Fields ]

        private int _id;
        private string _code = "";
        private string _name = "";
        private string _errorMessage = "";
        private Dictionary<string, object> _properties;

        #endregion

        #region [ Constructor ]

        public AjaxMessage()
        {
            _properties = new Dictionary<string, object>();
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

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public Dictionary<string, object> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        #endregion
    }
}