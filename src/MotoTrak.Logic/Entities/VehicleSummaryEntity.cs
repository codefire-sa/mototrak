using System;

namespace MotoTrak.Entities
{
    public class VehicleSummaryEntity
    {
        #region [ Fields ]

        private int _id;
        private string _vinNumber = "";
        private string _chassisNumber = "";
        private string _engineNumber = "";
        private string _registrationNumber = "";
        private DateTime? _registrationDate;
        private ValueComponent _model;
        private ValueComponent _dealer;
        private int _currentDistance;
        private CustomerComponent _customer; 

        #endregion

        #region [ Constructor ]

        public VehicleSummaryEntity()
        {
            _model = new ValueComponent();
            _dealer = new ValueComponent();
            _customer = new CustomerComponent();
        }

        #endregion

        #region [ Properties ]

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        public DateTime? RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }

        public ValueComponent Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public ValueComponent Dealer
        {
            get { return _dealer; }
            set { _dealer = value; }
        }

        public int CurrentDistance
        {
            get { return _currentDistance; }
            set { _currentDistance = value; }
        }

        public CustomerComponent Customer
        {
            get { return _customer; }
            set { _customer = value; }
        } 

        #endregion
    }
}