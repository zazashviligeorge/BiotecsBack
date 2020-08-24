using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.DTOs.FordAdmin;

namespace BiotecsBack.Repositories.Abstractions
{
   public interface IGroupRepository
    {
        Task<AdminGroupDto> GetByIdForAdminAsync(int groupId, CancellationToken token);

        Task<AdminGroupDto> GetAllGroups(CancellationToken token);


    }
}
