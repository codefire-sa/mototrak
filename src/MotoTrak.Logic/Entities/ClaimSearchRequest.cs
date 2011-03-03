using System;

namespace MotoTrak.Entities
{
    public class ClaimSearchRequest
    {
        private string _claimCode = "";
        private string _jobCardNumber = "";
        private string _externalNumber = "";
        private string _dealerName = "";
        private string _chassisNumber = "";
        private string _vinNumber = "";
        private int _limit;

        public string ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        public string JobCardNumber
        {
            get { return _jobCardNumber; }
            set { _jobCardNumber = value; }
        }

        public string ExternalNumber
        {
            get { return _externalNumber; }
            set { _externalNumber = value; }
        }

        public string DealerName
        {
            get { return _dealerName; }
            set { _dealerName = value; }
        }

        public string VinNumber
        {
            get { return _vinNumber; }
            set { _vinNumber = value; }
        }

        public string ChassisNumber
        {
            get { return _chassisNumber; }
            set { _chassisNumber = value; }
        }

        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }
    }
}