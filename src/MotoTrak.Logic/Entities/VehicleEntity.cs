using System;

namespace MotoTrak.Entities
{
    public class VehicleEntity : Entity
    {
        #region [ Fields ]

        private string _vinNumber = "";
        private string _chassisNumber = "";
        private string _engineNumber = "";
        private string _registrationNumber = "";
        private int _customerId;
        private ValueComponent _model;
        private ValueComponent _dealer;
        private DateTime? _wholesaleDate;
        private DateTime? _registrationDate;
        private DateTime? _retailDate;
        private int _currentDistance;
        private ValueComponent _currentDistanceUser;
        private DateTime _currentDistanceDate;
        private ValueComponent _vehicleStatus;
        private int _flags;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public VehicleEntity()
            : base()
        {
            _model = new ValueComponent();
            _dealer = new ValueComponent();
            _currentDistanceUser = new ValueComponent();
            _vehicleStatus = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
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

        public DateTime? WholesaleDate
        {
            get { return _wholesaleDate; }
            set { _wholesaleDate = value; }
        }

        public DateTime? RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }

        public DateTime? RetailDate
        {
            get { return _retailDate; }
            set { _retailDate = value; }
        }

        public int CurrentDistance
        {
            get { return _currentDistance; }
            set { _currentDistance = value; }
        }

        public ValueComponent CurrentDistanceUser
        {
            get { return _currentDistanceUser; }
            set { _currentDistanceUser = value; }
        }

        public DateTime CurrentDistanceDate
        {
            get { return _currentDistanceDate; }
            set { _currentDistanceDate = value; }
        }

        public ValueComponent VehicleStatus
        {
            get { return _vehicleStatus; }
            set { _vehicleStatus = value; }
        }

        public int Flags
        {
            get { return _flags; }
            set { _flags = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}