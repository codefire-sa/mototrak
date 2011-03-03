using System;
using MotoTrak.Entities;

namespace MotoTrak.Models
{
    public class ClaimWorkflowModel
    {
        private int _id;
        private string _comment = "";

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
    }
}