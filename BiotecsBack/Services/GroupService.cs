using BiotecsBack.Repositories.Abstractions;
using BiotecsBack.Repositories.Concrete;
using Data.DTOs.FordAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BiotecsBack.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public Task<IList<AdminGroupDto>> GetAllGroups(CancellationToken token)
        {
            return _groupRepository.GetAllGroups(token);
        }

        public Task<AdminGroupDto> GetByIdForAdminAsync(int groupId, CancellationToken token)
        {
            return _groupRepository.GetByIdForAdminAsync(groupId, token);
        }
    }
}
