using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.DTOs;
using Data.DTOs.FordAdmin;

namespace BiotecsBack.Services
{
    public interface IGroupService
    {
        Task<AdminGroupDto> GetByIdForAdminAsync(int groupId, CancellationToken token);
        Task<IList<AdminGroupDto>> GetAllGroups(CancellationToken token);
        Task DeleteGroup(int id, string currentFolder, CancellationToken token);
        Task PutGroup(int id, AdminGroupDto grouptDto, CancellationToken token);
        Task PostGroup(AdminGroupDto groupDto,  CancellationToken token);
    }
}
