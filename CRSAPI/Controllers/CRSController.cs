using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRSAPI.Models;
using CRSAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRSController : Controller
    {

        ICRSRepostiory CRSRepos;
        public CRSController(ICRSRepostiory crsrepo)
        {
            CRSRepos = crsrepo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult  Get()
        {
            var associatelist = CRSRepos.GetAllAssociates();
            return Ok(associatelist);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var associatelist = CRSRepos.GetAllAssociatebyid(id);
            return Ok(associatelist);
        }

        // POST api/<controller>
        [HttpPost]
        //public IActionResult Post([FromBody] Associate value)
        //{
        //    int returnval = CRSRepos.AddAssociate(value);
        //    return Ok(returnval);
        //}

        //[HttpPost]
        public IActionResult Post([FromBody] Associate user)
        {
            int id = CRSRepos.AddAssociate(user);
            return Ok(id);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
