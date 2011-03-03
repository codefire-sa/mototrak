using System;

namespace MotoTrak.Entities
{
    public class VehicleSearchRequest
    {
        private string _vinNumber = "";
        private string _chassisNumber = "";
        private string _engineNumber = "";
        private string _registrationNumber = "";
        private string _initials = "";
        private string _lastName = "";
        private int _limit;

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

        public string EngineNumber
        {
            get { return _engineNumber; }
            set { _engineNumber = value; }
        }

        public string RegistrationNumber
        {
            get { return _registrationNumber; }
            set { _registrationNumber = value; }
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

        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }
    }
}