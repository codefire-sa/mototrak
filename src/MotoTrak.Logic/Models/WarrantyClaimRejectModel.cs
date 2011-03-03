using System;
using MotoTrak.Entities;

namespace MotoTrak.Models
{
    public class WarrantyClaimRejectModel : ClaimWorkflowModel
    {
        private ValueComponent _rejectionReason;

        public WarrantyClaimRejectModel()
            : base()
        {
            _rejectionReason = new ValueComponent();
        }

        public ValueComponent RejectionReason
        {
            get { return _rejectionReason; }
            set { _rejectionReason = value; }
        }
    }
}