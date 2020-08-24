using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.DTOs;
using Data.Models;

namespace Data.LanguageHelpers
{
    public static class MultiLanguageSupport
    {
        
        public static Expression<Func<Product, ProductDto>> SingleProductWithCurrentLanguage(string lang)
        {
            return lang switch
            {
                "Eng" => (p) => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductNameEng,
                    Description = p.DescriptionEng,
                    GroupId = p.GroupId,
                    SubstanceId = p.ActiveSubstanceId,
                    PhotoUrl = p.ProductPhoto.FileName
                },
                "Ru" => (p) => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductNameRu,
                    Description = p.DescriptionRu,
                    GroupId = p.GroupId,
                    SubstanceId = p.ActiveSubstanceId,
                    PhotoUrl = p.ProductPhoto.FileName
                },
                _ => (p) => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    GroupId = p.GroupId,
                    SubstanceId = p.ActiveSubstanceId,
                    PhotoUrl = p.ProductPhoto.FileName
                }
            };
        }
        public static Expression<Func<Product, ProductDto>> ProductWithCurrentLanguage(string lang)
        {
            return lang switch
            {
                "Eng" => (p) => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductNameEng,
                    Description = p.DescriptionEng,
                    GroupId = p.GroupId,
                    PhotoUrl = p.ProductPhoto.FileName
                },
                "Ru" => (p) => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductNameRu,
                    Description = p.DescriptionRu,
                    GroupId = p.GroupId,
                    PhotoUrl = p.ProductPhoto.FileName
                },
                _ => (p) => new ProductDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    GroupId = p.GroupId,
                    PhotoUrl = p.ProductPhoto.FileName
                }
            };
        }

        public static Expression<Func<Article, ArticleDto>> ArticleWithCurrentLanguage(string lang)
        {
            return lang switch
            {
                "Eng" => (p) => new ArticleDto
                {
                    Id = p.Id,
                    Title = p.TitleEng,
                    ArticleText = p.ArticleTextEng,
                    PhotoUrls = p.ArticlePhotos.Select(n => n.FileName).ToList()
                },
                "Ru" => (p) => new ArticleDto
                {
                    Id = p.Id,
                    Title = p.TitleRu,
                    ArticleText = p.ArticleTextRu,
                    PhotoUrls = p.ArticlePhotos.Select(n => n.FileName).ToList()
                },
                _ => (p) => new ArticleDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    ArticleText = p.ArticleText,
                    PhotoUrls = p.ArticlePhotos.Select(n => n.FileName).ToList()
                }
            };
        }

        public static Expression<Func<Group, GroupDto>> GroupWithCurrentLanguage(string lang)
        {
            return lang switch
            {
                "Eng" => (p) => new GroupDto {Id = p.Id, GroupName = p.GroupNameEng},
                "Ru" => (p) => new GroupDto {Id = p.Id, GroupName = p.GroupNameRu},
                _ => (p) => new GroupDto {Id = p.Id, GroupName = p.GroupName}
            };
        }

        public static Expression<Func<ActiveSubstance, ActiveSubstanceDto>> ActiveSubstanceWithCurrentLanguage(string lang)
        {
            return lang switch
            {
                "Eng" => (p) => new ActiveSubstanceDto { Id = p.Id, SubstanceName = p.SubstanceName },
                "Ru" => (p) => new ActiveSubstanceDto { Id = p.Id, SubstanceName = p.SubstanceName },
                _ => (p) => new ActiveSubstanceDto { Id = p.Id, SubstanceName = p.SubstanceName }
            };
        }
    }
}
