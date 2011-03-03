using System;

namespace MotoTrak.Entities
{
    public class SearchRequest
    {
        private string _code = "";
        private string _name = "";
        private string _orderColumn = "";
        private int _limit;

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

        public string OrderColumn
        {
            get { return _orderColumn; }
            set { _orderColumn = value; }
        }

        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }
    }
}