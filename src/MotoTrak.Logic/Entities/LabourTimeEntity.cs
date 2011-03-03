using System;

namespace MotoTrak.Entities
{
    public class LabourTimeEntity : Entity
    {
        #region [ Fields ]

        private int _labourId;
        private string _modelMatch;
        private short _weight;
        private decimal _maximumTime;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public LabourTimeEntity()
        {
        }

        #endregion

        #region [ Properties ]

        public int LabourId
        {
            get { return _labourId; }
            set { _labourId = value; }
        }

        public string ModelMatch
        {
            get { return _modelMatch; }
            set { _modelMatch = value; }
        }

        public short Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public decimal MaximumTime
        {
            get { return _maximumTime; }
            set { _maximumTime = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}