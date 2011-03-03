using System;

namespace MotoTrak.Entities
{
    public class BankDetailComponent
    {
        #region [ Fields ]

        private string _accountHolderName = "";
        private string _branchCode = "";
        private string _accountNumber = "";
        private ValueComponent _accountType;

        #endregion

        #region [ Constructor ]

        public BankDetailComponent()
        {
            _accountType = new ValueComponent();
        }

        #endregion

        #region [ Properties ]

        public string AccountHolderName
        {
            get { return _accountHolderName; }
            set { _accountHolderName = value; }
        }

        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public ValueComponent AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }

        #endregion
    }
}