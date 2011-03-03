using System;
using Codefire.Storm.Engine;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class MotoTrakStrategy : DefaultStrategy
    {
        public MotoTrakStrategy()
            : base()
        {
        }

        public override bool ShouldMap(Type type)
        {
            if (type.IsAbstract) return false;

            return type.Name.EndsWith("Entity");
        }

        public override string GetColumnName(Type entityType, string memberName)
        {
            switch (memberName)
            {
                case "Code":
                case "Name":
                    var className = entityType.Name.Replace("Entity", "");
                    return className + memberName;
                default:
                    return base.GetColumnName(entityType, memberName);
            }
        }
    }
}