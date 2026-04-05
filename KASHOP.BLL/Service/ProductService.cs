using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KASHOP.BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;
        public ProductService(IProductRepository productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }
        public async Task CreateProduct(ProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            if (request.MainImage!=null)
            {
                var imagePath =await _fileService.UploadAsync(request.MainImage);
                product.MainImage= imagePath;
                
            }
            await Task.Delay(5000, cancellationToken);
            await _productRepository.CreateAsync(product,cancellationToken);
        }
        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync(
               p=>p.Status == EntityStatus.Active
                ,
                new string[]
                {
                    nameof(Product.Translations),
                    nameof(Product.CreatedBy),

                    nameof(Product.Brand)
                }
                );
            return products.Adapt<List<ProductResponse>>();

        }

        public async Task<ProductResponse?> GetProduct(Expression<Func<Product, bool>> filter)
        {
            var product = await _productRepository.GetOne(filter, new string[] {
             nameof(Product.Translations),
             nameof(Product.CreatedBy),
             nameof(Product.Brand)
            });

            if (product == null) return null;
            return product.Adapt<ProductResponse>();
        }
        
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _productRepository.GetOne(c=>c.Id == id);
            if (product == null) return false;
            _fileService.Delete(product.MainImage);
            return await _productRepository.DeleteAsync(product);
        }

        public async Task<bool> UpdateProduct(int id, ProductUpdateRequest request)
        {
            var product = await _productRepository.GetOne(p => p.Id == id, new string[]
            {
                nameof(Product.Translations),
            });

            if (product == null) return false;

            request.Adapt(product);

            if (request.Translations != null)
            {
                foreach (var translationRequest in request.Translations)
                {
                    var existing = product.Translations.FirstOrDefault(t => t.Language == translationRequest.Language);
                    if (existing != null)
                    {
                        if (translationRequest.Name != null)
                        { existing.Name = translationRequest.Name; }
                        if (translationRequest.Description != null)
                        { existing.Description = translationRequest.Description; }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

              var oldImage = product.MainImage;
            if (request.MainImage != null)
            {
                _fileService.Delete(oldImage);
                product.MainImage = await _fileService.UploadAsync(request.MainImage);
            }
            else
            {
                product.MainImage = oldImage;
            }

            return await _productRepository.UpdateAsync(product);

        }
        public async Task<bool>ToggelStatus(int id)
        {
            var product = await _productRepository.GetOne(p=>p.Id == id);
            if(product == null) return false;
            product.Status = product.Status == EntityStatus.Active?
                EntityStatus.Inactive : EntityStatus.Active;
            return await _productRepository.UpdateAsync(product);
        }
    }
}
