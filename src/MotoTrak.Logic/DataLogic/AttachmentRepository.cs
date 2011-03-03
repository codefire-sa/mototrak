using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class AttachmentRepository : EntityRepository<AttachmentEntity>
    {
        public List<AttachmentEntity> GetByVehicle(int vehicleId)
        {
            return Context.Find<AttachmentEntity>()
                             .Where(x => x.LinkId == vehicleId && x.AttachmentType == AttachmentType.Vehicle && x.IsActive == true)
                             .OrderAsc(x => x.FileName)
                             .List();
        }

        public List<AttachmentEntity> GetByClaim(int claimId)
        {
            return Context.Find<AttachmentEntity>()
                             .Where(x => x.LinkId == claimId && x.AttachmentType == AttachmentType.Claim && x.IsActive == true)
                             .OrderAsc(x => x.FileName)
                             .List();
        }
    }
}