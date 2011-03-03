using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.Models
{
    public class WarrantyClaimModel
    {
        private ClaimEntity _claim;
        private PolicySummaryEntity _policy;
        private List<ClaimLabourEntity> _labour;
        private List<ClaimPartEntity> _parts;
        private List<ClaimMiscellaneousEntity> _miscellaneous;
        private List<AttachmentEntity> _attachments;

        public WarrantyClaimModel()
        {
            _claim = new ClaimEntity();
            _policy = new PolicySummaryEntity();
            _labour = new List<ClaimLabourEntity>();
            _parts = new List<ClaimPartEntity>();
            _miscellaneous = new List<ClaimMiscellaneousEntity>();
            _attachments = new List<AttachmentEntity>();
        }

        public ClaimEntity Claim
        {
            get { return _claim; }
            set { _claim = value; }
        }

        public PolicySummaryEntity Policy
        {
            get { return _policy; }
            set { _policy = value; }
        }

        public List<ClaimLabourEntity> Labour
        {
            get { return _labour; }
            set { _labour = value; }
        }

        public List<ClaimPartEntity> Parts
        {
            get { return _parts; }
            set { _parts = value; }
        }

        public List<ClaimMiscellaneousEntity> Miscellaneous
        {
            get { return _miscellaneous; }
            set { _miscellaneous = value; }
        }

        public List<AttachmentEntity> Attachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
    }
}