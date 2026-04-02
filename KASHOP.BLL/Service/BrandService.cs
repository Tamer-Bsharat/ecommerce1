using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IFileService _fileService1;
        public BrandService(IBrandRepository brandRepository, IFileService fileService)
        {
            _brandRepository = brandRepository;
            _fileService1 = fileService;

        }
        public async Task<BrandResponse> CreateAsync(BrandRequest request)
        {
            var brand = request.Adapt<Brand>();
            if (request.BrandImage != null) {
            
                var imagePath = await _fileService1.UploadAsync(request.BrandImage);
                brand.BrandImage = imagePath; 
            }

            await _brandRepository.CreateBrandAsync(brand);
            return brand.Adapt<BrandResponse>();

        }
    }
}
