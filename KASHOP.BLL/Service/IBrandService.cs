using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Service
{
    public interface IBrandService
    {
        Task<BrandResponse> CreateAsync(BrandRequest request);
        Task<List<BrandResponse>> GetAllBrands();
        Task<BrandResponse> GetBrand(Expression<Func<Brand, bool>> filter);
        Task<BrandResponse?> DeleteBrandAsync(int id);
    }
}
