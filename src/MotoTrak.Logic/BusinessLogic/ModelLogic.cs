using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Extensions;

namespace MotoTrak.BusinessLogic
{
    public class ModelLogic : BaseLogic
    {
        public ModelLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ModelEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Models.GetById(id);
            }
        }

        public ModelEntity GetByCode(string code)
        {
            using (var db = CreateCatalog())
            {
                return db.Models.GetByCode(code);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var modelObj = db.Models.GetByCode(code);
                if (modelObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = modelObj.Id;
                    ajaxObj.Code = modelObj.Code;
                    ajaxObj.Name = modelObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Models.Search(request);
            }
        }
    }
}