using System;

namespace MotoTrak.Entities
{
    public class VehicleServiceEntity : Entity
    {
        #region [ Fields ]

        private int _vehicleId;
        private ValueComponent _dealer;
        private DateTime? _serviceDate;
        private int _serviceDistance;
        private string _invoiceNumber;
        private int _siteId;

        #endregion

        #region [ Constructors ]

        public VehicleServiceEntity()
            : base()
        {
            _dealer = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public int VehicleId
        {
            get { return _vehicleId; }
            set { _vehicleId = value; }
        }

        public ValueComponent Dealer
        {
            get { return _dealer; }
            set { _dealer = value; }
        }

        public DateTime? ServiceDate
        {
            get { return _serviceDate; }
            set { _serviceDate = value; }
        }

        public int ServiceDistance
        {
            get { return _serviceDistance; }
            set { _serviceDistance = value; }
        }

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { _invoiceNumber = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        #endregion
    }
}