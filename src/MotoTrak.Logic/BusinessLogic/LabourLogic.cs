using System;
using System.Collections.Generic;
using Codefire.Extensions;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class LabourLogic : BaseLogic
    {
        public LabourLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public LabourEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Labour.GetById(id);
            }
        }

        public LabourEntity GetByCode(string code)
        {
            using (var db = CreateCatalog())
            {
                return db.Labour.GetByCode(code);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var labourObj = db.Labour.GetByCode(code);
                if (labourObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = labourObj.Id;
                    ajaxObj.Code = labourObj.Code;
                    ajaxObj.Name = labourObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Labour.Search(request);
            }
        }
    }
}