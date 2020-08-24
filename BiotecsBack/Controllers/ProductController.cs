using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BiotecsBack.Services;
using BiotecsBack.Services.FileHandling;
using Data.DTOs;
using Data.DTOs.FordAdmin;
using Data.Helpers.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiotecsBack.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly string _currentFolderName ;

        public ProductController(IProductService productService, IPhotoService photoService)
        {
            _productService = productService;
            _currentFolderName = this.GetType().Name.Replace("Controller", "Photos");
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<PagedList<ProductDto>>> Get([FromQuery]PageOptions options,string language,CancellationToken token)
        {
            return await _productService.GetPagedListAsync(options,language,token);
        }

        [HttpGet("ForAdmin")]
        public async Task<ActionResult<PagedList<AdminProductDto>>> GetPagedListForAdmin([FromQuery] PageOptions options,CancellationToken token)
        {
            return await _productService.GetPagedListForAdminAsync(options, token);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id, string language, CancellationToken token)
        {
            return await _productService.GetByIdAsync(id, language, token);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}/ForAdmin")]
        public async Task<AdminProductDto> GetForAdmin(int id,CancellationToken token)
        {
            return await _productService.GetByIdForAdminAsync(id,token);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task  Post([FromForm] AdminProductDto product,CancellationToken token)
        {
            await _productService.PostProduct(product,_currentFolderName ,token);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task Put(int id,[FromForm] AdminProductDto product, CancellationToken token)
        {
            await _productService.PutProduct(id,product, _currentFolderName, token);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id,CancellationToken token)
        {
            await _productService.DeleteProduct(id, _currentFolderName, token);
        }
    }
}
