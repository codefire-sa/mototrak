using System;
using MotoTrak.Entities;

namespace MotoTrak.Models
{
    public class WarrantyClaimInvoiceModel : ClaimWorkflowModel
    {
        private string _invoiceNumber;
        private DateTime? _repairDate;

        public WarrantyClaimInvoiceModel()
            : base()
        {
        }

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { _invoiceNumber = value; }
        }

        public DateTime? RepairDate
        {
            get { return _repairDate; }
            set { _repairDate = value; }
        }
    }
}