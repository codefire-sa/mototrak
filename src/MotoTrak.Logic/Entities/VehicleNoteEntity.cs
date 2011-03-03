using System;

namespace MotoTrak.Entities
{
    public class VehicleNoteEntity : Entity
    {
        private int _vehicleId;
        private int _claimId;
        private string _claimCode = "";
        private string _note = "";
        private int _siteId;
        private string _userCode = "";

        public VehicleNoteEntity()
            : base()
        {
        }

        public int VehicleId
        {
            get { return _vehicleId; }
            set { _vehicleId = value; }
        }

        public int ClaimId
        {
            get { return _claimId; }
            set { _claimId = value; }
        }

        public string ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        public string UserCode
        {
            get { return _userCode; }
            set { _userCode = value; }
        }
    }
}