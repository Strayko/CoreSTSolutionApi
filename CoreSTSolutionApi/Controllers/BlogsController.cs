using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreSTSolutionApi.Data;
using CoreSTSolutionApi.Data.Entities;
using CoreSTSolutionApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoreSTSolutionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public BlogsController(IBlogRepository blogRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<BlogModel[]>> Get(bool includeTags = false)
        {
            try
            {
                var results = await _blogRepository.GetAllBlogsAsync(includeTags);
                BlogModel[] models = _mapper.Map<BlogModel[]>(results);
                return models;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{blogId:int}")]
        public async Task<ActionResult<BlogModel>> Get(int blogId)
        {
            try
            {
                var result = await _blogRepository.GetBlogAsync(blogId);
                if (result == null) return NotFound();
                return _mapper.Map<BlogModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<BlogModel[]>> SearchByName(string name)
        {
            try
            {
                var results = await _blogRepository.GetAllBlogsByName(name);
                if (!results.Any()) return NotFound();
                return _mapper.Map<BlogModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        public async Task<ActionResult<Blog>> Post(Blog model)
        {
            try
            {
                var blog = await _blogRepository.IsUnique(model.Name);
                if (blog != null)
                {
                    return BadRequest("Name in Use");
                }

                _blogRepository.Add(model);
                if (await _blogRepository.SaveChangesAsync())
                {
                    return Created($"/api/blogs/{model.BlogId}", model);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpPut("{blogId:int}")]
        public async Task<ActionResult<Blog>> Put(int blogId, Blog model)
        {
            try
            {
                if (blogId != model.BlogId) return BadRequest();
                var blog =  await _blogRepository.SetModified(model);

                if (await _blogRepository.SaveChangesAsync())
                {
                    return blog;
                }
                
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("{blogId:int}")]
        public async Task<IActionResult> Delete(int blogId)
        {
            try
            {
                var blog = await _blogRepository.GetBlogAsync(blogId);
                if (blog == null) return NotFound();
                
                _blogRepository.Delete(blog);

                if (await _blogRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete the blog");
        }
    }
}