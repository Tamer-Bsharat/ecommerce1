using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Mapping
{
    public class MapsterConfig
    {
        public static void MapsterConfigRegister()
        {
            TypeAdapterConfig<Category, CategoryResponse>.NewConfig()
                .Map(dest => dest.cat_Id, source => source.Id)
                .Map(dest => dest.UserCreated, source => source.CreatedBy.UserName)
                .Map(dest=>dest.Name , source=>source.Translations.Where(

                    t => t.Language == CultureInfo.CurrentCulture.Name)
                .Select(t=>t.Name).FirstOrDefault()
                );
            TypeAdapterConfig<Product, ProductResponse>.NewConfig()

                .Map(dest => dest.UserCreated, source => source.CreatedBy.UserName)
                .Map(dest => dest.Name, source => source.Translations.Where(

                    t => t.Language == CultureInfo.CurrentCulture.Name)
                .Select(t => t.Name).FirstOrDefault()
                ).Map(dest => dest.MainImage, source => $"https://localhost:7129/images/{source.MainImage}")


                .Map(dest => dest.BrandName, source => source.Brand.Name)
                .Map(dest => dest.BrandImage, source => $"https://localhost:7129/images/{source.Brand.BrandImage}");

            TypeAdapterConfig<ProductUpdateRequest, Product>.NewConfig()
                .IgnoreNullValues(true);

            TypeAdapterConfig<Brand, BrandResponse>.NewConfig()
             .Map(dest => dest.BrandImage , source => $"https://localhost:7129/images/{source.BrandImage}");

        }
    }
}
