using System;

namespace MotoTrak.Entities
{
    public class PolicySummaryEntity
    {
        private int _id;
        private string _code = "";
        private ValueComponent _product;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private int _startDistance;
        private int _endDistance;
        private string _vinNumber = "";
        private string _chassisNumber = "";
        private string _engineNumber = "";
        private string _registrationNumber = "";
        private ValueComponent _model;
        private ValueComponent _dealer;
        private int _currentDistance;
        private CustomerComponent _customer;

        public PolicySummaryEntity()
        {
            _product = new ValueComponent();
            _model = new ValueComponent();
            _dealer = new ValueComponent();
            _customer = new CustomerComponent();
        }

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

        public ValueComponent Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public int StartDistance
        {
            get { return _startDistance; }
            set { _startDistance = value; }
        }

        public int EndDistance
        {
            get { return _endDistance; }
            set { _endDistance = value; }
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
    }
}