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

        public Task DeleteGroup(int id, string currentFolder, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task PostGroup(AdminGroupDto groupDto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public  async Task PutGroup(int id, AdminGroupDto grouptDto, CancellationToken token)
        {
            var existingGroup = await _groupRepository.GetByIdForAdminAsync(id, token);

            throw new NotImplementedException();

        }
    }
}
