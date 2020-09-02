using Data.DTOs.FordAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Group : AuditableEntity
    {

        public Group(AdminGroupDto groupDto)
        {
            Products = new HashSet<Product>();
            SetProperties(groupDto);
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        [StringLength(100)]
        public string GroupNameEng { get; set; }

        [StringLength(100)]
        public string GroupNameRu { get; set; }

        public ICollection<Product> Products { get; set; }

        public AdminGroupDto GetDto()
        {
            return new AdminGroupDto
            {
                Id = Id,
                GroupName = GroupName,
                GroupNameEng = GroupNameEng,
                GroupNameRu = GroupNameRu
            };
        }

        public void UpdateGroup(AdminGroupDto groupDto)
        {
            SetProperties(groupDto);
        }

        private void SetProperties(AdminGroupDto groupDto)
        {
            GroupName = groupDto.GroupName;
            GroupNameEng = groupDto.GroupNameEng;
            GroupNameRu = groupDto.GroupNameRu;
        }
    }
}
