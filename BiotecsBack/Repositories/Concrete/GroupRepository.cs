using BiotecsBack.Data;
using BiotecsBack.Repositories.Abstractions;
using Data.DTOs.FordAdmin;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BiotecsBack.Repositories.Concrete
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext ctx) : base(ctx) { }

        public Task<AdminGroupDto> GetAllGroups(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<AdminGroupDto> GetByIdForAdminAsync(int groupId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }


}
