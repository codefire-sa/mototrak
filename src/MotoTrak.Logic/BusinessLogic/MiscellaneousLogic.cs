using System;
using System.Collections.Generic;
using MotoTrak.Entities;
using Codefire.Extensions;

namespace MotoTrak.BusinessLogic
{
    public class MiscellaneousLogic : BaseLogic
    {
        public MiscellaneousLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public MiscellaneousEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Miscellaneous.GetById(id);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var miscellaneousObj = db.Miscellaneous.GetByCode(code);
                if (miscellaneousObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = miscellaneousObj.Id;
                    ajaxObj.Code = miscellaneousObj.Code;
                    ajaxObj.Name = miscellaneousObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Miscellaneous.Search(request);
            }
        }
    }
}