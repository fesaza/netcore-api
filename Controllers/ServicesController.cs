using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace codenullConfigApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        persistence _persistence;

        public ServicesController()
        {   
            _persistence = new persistence();
            _persistence.seed();
        }

        [HttpGet("stores")]
        public ActionResult<storeResponse> GetStores(){

            return new storeResponse{
                success = true,
                total_elements = _persistence.stores.Count,
                stores = _persistence.stores
            }; 
        }

        [HttpGet("articles")]
        public ActionResult<articlesResponse> GetArticles(){
            return applyResponse(_persistence.articles);
        }

        [HttpGet("articles/stores/{id}")]
        public ActionResult<responseBase> GetArticlesByStore(string id){
            var _id = 0;
            if(!Int32.TryParse(id, out _id)){
                return BadRequest(new {
                    error_msg= "Bad request",
                    error_code= 400,
                    success= false,
                });
            }

            var articles = _persistence.articles.Where(a=>a.store.id == _id).ToList();
            if(articles.Count == 0){
                return NotFound(new {
                    error_msg= "Record not Found",
                    error_code= 404,
                    success= false,
                });
            }
            return applyResponse(articles);
        }

    

    private articlesResponse applyResponse(List<article> articles){
            return new articlesResponse{
                success = true,
                total_elements = articles.Count,
                articles = articles.Select(a => new articleResponse{
                    id = a.id,
                    description = a.description,
                    name = a.name,
                    price = a.price,
                    total_in_shelf = a.total_in_shelf,
                    total_in_vault = a.total_in_vault,
                    store_name = a.store.name,
                }).ToList()
            }; 
        }
    }
}