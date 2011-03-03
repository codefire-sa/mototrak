using System;
using System.Data;
using Codefire.Extensions;
using MotoTrak.Entities;
using System.Collections.Generic;
using MotoTrak.DataLogic;

namespace MotoTrak.BusinessLogic
{
    public class PartLogic : BaseLogic
    {
        public PartLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public PartEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Parts.GetById(id);
            }
        }

        public PartEntity GetByCode(string code)
        {
            using (var db = CreateCatalog())
            {
                return db.Parts.GetByCode(code);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var partObj = db.Parts.GetByCode(code);
                if (partObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = partObj.Id;
                    ajaxObj.Code = partObj.Code;
                    ajaxObj.Name = partObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Parts.Search(request);
            }
        }
    }
}