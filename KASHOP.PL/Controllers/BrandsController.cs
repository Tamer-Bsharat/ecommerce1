using KASHOP.BLL.Service;
using KASHOP.DAL.DTO.Request;
using KASHOP.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public BrandsController(IBrandService brandService , IStringLocalizer<SharedResources> localizer) 
        {
            _brandService = brandService;
            _localizer = localizer;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateBrandAsync([FromForm] BrandRequest request)
        {
            var response = await _brandService.CreateAsync(request);
            if (response == null)
            {
                return BadRequest();

            }
            return Ok(new { 
            Massage = "Brand Added Successfuly ",
            Success = true,
            });
        }

    }
}
