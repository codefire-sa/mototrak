using System;

namespace MotoTrak.Entities
{
    public class PolicyEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private int _vehicleId;
        private ValueComponent _product;
        private short _contractDuration;
        private int _contractDistance;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _startDistance;
        private int _endDistance;
        private ValueComponent _cancellationReason;
        private ValueComponent _cancelUser;
        private DateTime? _cancelDate;
        private ValueComponent _policyStatus;
        private ValueComponent _policyClass;
        private int _flags;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public PolicyEntity() 
            : base()
        {
            _product = new ValueComponent();
            _cancellationReason = new ValueComponent();
            _cancelUser = new ValueComponent();
            _policyStatus = new ValueComponent();
            _policyClass = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public int VehicleId
        {
            get { return _vehicleId; }
            set { _vehicleId = value; }
        }

        public ValueComponent Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public short ContractDuration
        {
            get { return _contractDuration; }
            set { _contractDuration = value; }
        }

        public int ContractDistance
        {
            get { return _contractDistance; }
            set { _contractDistance = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
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

        public ValueComponent CancellationReason
        {
            get { return _cancellationReason; }
            set { _cancellationReason = value; }
        }

        public ValueComponent CancelUser
        {
            get { return _cancelUser; }
            set { _cancelUser = value; }
        }

        public DateTime? CancelDate
        {
            get { return _cancelDate; }
            set { _cancelDate = value; }
        }

        public ValueComponent PolicyStatus
        {
            get { return _policyStatus; }
            set { _policyStatus = value; }
        }

        public ValueComponent PolicyClass
        {
            get { return _policyClass; }
            set { _policyClass = value; }
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