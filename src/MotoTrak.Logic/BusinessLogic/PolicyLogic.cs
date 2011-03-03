using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.DataLogic;
using MotoTrak.Entities;
using Codefire.Storm;

namespace MotoTrak.BusinessLogic
{
    public class PolicyLogic : BaseLogic
    {
        public PolicyLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public PolicyEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Policies.GetById(id);
            }
        }

        public int Create(PolicyEntity policyObj)
        {
            using (var db = CreateCatalog())
            {
                var productObj = db.Products.GetById(policyObj.Product.Id);
                var statusObj = db.PolicyStatuses.GetByCode("ACT");
                var endDate = policyObj.StartDate.AddMonths(productObj.ContractDuration).AddDays(-1);
                var endDistance = productObj.ContractDistance;

                policyObj.EndDate = endDate;
                policyObj.EndDistance = endDistance;
                policyObj.ContractDuration = productObj.ContractDuration;
                policyObj.ContractDistance = productObj.ContractDistance;
                policyObj.PolicyStatus.Id = statusObj.Id;
                policyObj.PolicyClass.Id = productObj.PolicyClass.Id;

                return db.Policies.Insert(policyObj);
            }
        }

        public void Update(PolicyEntity policyObj)
        {
            using (var db = CreateCatalog())
            {
                var productObj = db.Products.GetById(policyObj.Product.Id);
                var endDate = policyObj.StartDate.AddMonths(productObj.ContractDuration).AddDays(-1);
                var endDistance = productObj.ContractDistance;

                policyObj.EndDate = endDate;
                policyObj.EndDistance = endDistance;
                policyObj.ContractDuration = productObj.ContractDuration;
                policyObj.ContractDistance = productObj.ContractDistance;
                policyObj.PolicyClass.Id = productObj.PolicyClass.Id;

                db.Policies.Update(policyObj);
            }
        }
    }
}