using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Extensions;

namespace MotoTrak.BusinessLogic
{
    public class RejectionReasonLogic : BaseLogic
    {
        public RejectionReasonLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public RejectionReasonEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.RejectionReasons.GetById(id);
            }
        }

        public RejectionReasonEntity GetByCode(string code)
        {
            using (var db = CreateCatalog())
            {
                return db.RejectionReasons.GetByCode(code);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var reasonObj = db.RejectionReasons.GetByCode(code);
                if (reasonObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = reasonObj.Id;
                    ajaxObj.Code = reasonObj.Code;
                    ajaxObj.Name = reasonObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<RejectionReasonEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.RejectionReasons.GetAll();
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.RejectionReasons.Search(request);
            }
        }
    }
}