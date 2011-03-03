using System;

namespace MotoTrak.Entities
{
    public class ClaimEntity : Entity
    {
        #region [ Fields ]

        private string _code = "";
        private int _vehicleId;
        private int _policyId;
        private ValueComponent _dealer;
        private int _claimDistance;
        private string _externalNumber = "";
        private string _jobCardNumber = "";
        private string _invoiceNumber = "";
        private string _diagnosticNumber = "";
        private ValueComponent _fault;
        private ValueComponent _customerConcern;
        private ValueComponent _condition;
        private ValueComponent _program;
        private ValueComponent _claimType;
        private ValueComponent _rejectionReason;
        private ValueComponent _claimStatus;
        private DateTime _claimDate;
        private DateTime? _submitDate;
        private DateTime? _repairDate;
        private DateTime? _paymentDate;
        private string _authorisationNumber = "";
        private ValueComponent _authorisationUser;
        private DateTime? _authorisationDate;
        private string _faultNote = "";
        private string _causeNote = "";
        private string _remedyNote = "";
        private decimal _labourAuthorisedPercent;
        private decimal _partAuthorisedPercent;
        private decimal _miscellaneousAuthorisedPercent;
        private decimal _labourRateAmount;
        private decimal _taxPercent;
        private ClaimAmountComponent _claimAmount;
        private ClaimAmountComponent _authorisedAmount;
        private ValueComponent _claimClass;
        private int _flags;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public ClaimEntity()
            : base()
        {
            _dealer = new ValueComponent();
            _fault = new ValueComponent();
            _customerConcern = new ValueComponent();
            _condition = new ValueComponent();
            _program = new ValueComponent();
            _claimType = new ValueComponent();
            _rejectionReason = new ValueComponent();
            _claimStatus = new ValueComponent();
            _claimAmount = new ClaimAmountComponent();
            _authorisedAmount = new ClaimAmountComponent();
            _claimClass = new ValueComponent();
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

        public int PolicyId
        {
            get { return _policyId; }
            set { _policyId = value; }
        }

        public ValueComponent Dealer
        {
            get { return _dealer; }
            set { _dealer = value; }
        }

        public int ClaimDistance
        {
            get { return _claimDistance; }
            set { _claimDistance = value; }
        }

        public string ExternalNumber
        {
            get { return _externalNumber; }
            set { _externalNumber = value; }
        }

        public string JobCardNumber
        {
            get { return _jobCardNumber; }
            set { _jobCardNumber = value; }
        }

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { _invoiceNumber = value; }
        }

        public string DiagnosticNumber
        {
            get { return _diagnosticNumber; }
            set { _diagnosticNumber = value; }
        }

        public ValueComponent Fault
        {
            get { return _fault; }
            set { _fault = value; }
        }

        public ValueComponent CustomerConcern
        {
            get { return _customerConcern; }
            set { _customerConcern = value; }
        }

        public ValueComponent Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public ValueComponent Program
        {
            get { return _program; }
            set { _program = value; }
        }

        public ValueComponent ClaimType
        {
            get { return _claimType; }
            set { _claimType = value; }
        }

        public ValueComponent RejectionReason
        {
            get { return _rejectionReason; }
            set { _rejectionReason = value; }
        }

        public ValueComponent ClaimStatus
        {
            get { return _claimStatus; }
            set { _claimStatus = value; }
        }

        public DateTime ClaimDate
        {
            get { return _claimDate; }
            set { _claimDate = value; }
        }

        public DateTime? SubmitDate
        {
            get { return _submitDate; }
            set { _submitDate = value; }
        }

        public DateTime? RepairDate
        {
            get { return _repairDate; }
            set { _repairDate = value; }
        }

        public DateTime? PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        public string AuthorisationNumber
        {
            get { return _authorisationNumber; }
            set { _authorisationNumber = value; }
        }

        public ValueComponent AuthorisationUser
        {
            get { return _authorisationUser; }
            set { _authorisationUser = value; }
        }

        public DateTime? AuthorisationDate
        {
            get { return _authorisationDate; }
            set { _authorisationDate = value; }
        }

        public string FaultNote
        {
            get { return _faultNote; }
            set { _faultNote = value; }
        }

        public string CauseNote
        {
            get { return _causeNote; }
            set { _causeNote = value; }
        }

        public string RemedyNote
        {
            get { return _remedyNote; }
            set { _remedyNote = value; }
        }

        public decimal LabourAuthorisedPercent
        {
            get { return _labourAuthorisedPercent; }
            set { _labourAuthorisedPercent = value; }
        }

        public decimal PartAuthorisedPercent
        {
            get { return _partAuthorisedPercent; }
            set { _partAuthorisedPercent = value; }
        }

        public decimal MiscellaneousAuthorisedPercent
        {
            get { return _miscellaneousAuthorisedPercent; }
            set { _miscellaneousAuthorisedPercent = value; }
        }

        public decimal LabourRateAmount
        {
            get { return _labourRateAmount; }
            set { _labourRateAmount = value; }
        }

        public decimal TaxPercent
        {
            get { return _taxPercent; }
            set { _taxPercent = value; }
        }

        public ClaimAmountComponent ClaimAmount
        {
            get { return _claimAmount; }
            set { _claimAmount = value; }
        }

        public ClaimAmountComponent AuthorisedAmount
        {
            get { return _authorisedAmount; }
            set { _authorisedAmount = value; }
        }

        public ValueComponent ClaimClass
        {
            get { return _claimClass; }
            set { _claimClass = value; }
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