using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Text;
using Data.DTOs;
using Data.DTOs.FordAdmin;

namespace Data.Models
{

    public class Product : AuditableEntity
    {
        public Product(){}
        public Product(AdminProductDto productDto)
        {
            SetProperties(productDto);
            AddOrUpdatePhoto(productDto.PhotoUrl);
        }

        public int Id { get; set; }

        
        [StringLength(100)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        
        [StringLength(100)]
        public string ProductNameEng { get; set; }

        public string DescriptionEng { get; set; }

       
        [StringLength(100)]
        public string ProductNameRu { get; set; }

        public string DescriptionRu { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public int? ActiveSubstanceId { get; set; }

        public ActiveSubstance ActiveSubstance { get; set; }

        public ProductPhoto ProductPhoto { get; set; }

        public void UpdateProduct(AdminProductDto productDto)
        {
            SetProperties(productDto);
            AddOrUpdatePhoto(productDto.PhotoUrl);
        }

        public void AddOrUpdatePhoto(string fileName)
        {
            ProductPhoto=new ProductPhoto{FileName = fileName};
        }
        private void SetProperties(AdminProductDto productDto)
        {
            ProductName = productDto.ProductName;
            Description = productDto.Description;
            ProductNameEng = productDto.ProductNameEng;
            DescriptionEng = productDto.DescriptionEng;
            ProductNameRu = productDto.ProductNameRu;
            DescriptionRu = productDto.DescriptionRu;
            GroupId = productDto.GroupId;
            ActiveSubstanceId = productDto.SubstanceId;
        }

        public  AdminProductDto ToAdminDto()
        {
            return new AdminProductDto
            {
                Id=Id,
                ProductName = ProductName,
                Description = Description,
                ProductNameEng = ProductNameEng,
                DescriptionEng = DescriptionEng,
                ProductNameRu = ProductNameRu,
                DescriptionRu = DescriptionRu,
                GroupId = GroupId,
                SubstanceId = ActiveSubstanceId,
                PhotoUrl = ProductPhoto?.FileName
            };
        }

        public static Expression<Func<Product, bool>> GetSearchQuery(string searchBy)
        {
            return c => c.ProductName.Contains(searchBy) ||
                        c.ProductNameEng.Contains(searchBy) ||
                        c.ProductNameRu.Contains(searchBy) ||
                        c.Description.Contains(searchBy) ||
                        c.DescriptionEng.Contains(searchBy) ||
                        c.DescriptionRu.Contains(searchBy);
        }
    }
}
