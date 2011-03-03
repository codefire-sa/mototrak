using System;

namespace MotoTrak.Entities
{
    public class SearchEntity
    {
        private int _id;
        private string _code = "";
        private string _name = "";

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
    }
}