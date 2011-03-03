using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Extensions;

namespace MotoTrak.BusinessLogic
{
    public class ConditionLogic : BaseLogic
    {
        public ConditionLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public ConditionEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Conditions.GetById(id);
            }
        }

        public ConditionEntity GetByCode(string code)
        {
            using (var db = CreateCatalog())
            {
                return db.Conditions.GetByCode(code);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var conditionObj = db.Conditions.GetByCode(code);
                if (conditionObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = conditionObj.Id;
                    ajaxObj.Code = conditionObj.Code;
                    ajaxObj.Name = conditionObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<ConditionEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.Conditions.GetAll();
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Conditions.Search(request);
            }
        }
    }
}