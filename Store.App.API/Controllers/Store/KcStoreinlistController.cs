using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.App.Data.Abstract;
using Store.App.Model.Store;
using Store.App.API.Core;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class KcStoreinlistController : Controller
    {
		private readonly IMapper _mapper;
        private readonly IKcStoreinlistRepository _kcStoreinlistRpt;
        public KcStoreinlistController(IKcStoreinlistRepository kcStoreinlistRpt,
				IMapper mapper)
        {
            _kcStoreinlistRpt = kcStoreinlistRpt;
			_mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
		    IEnumerable<kc_storeinlist> entityDto = null;
            await Task.Run(() =>
            {
				entityDto = _kcStoreinlistRpt.GetAll();
			});
            return new OkObjectResult(entityDto);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var single = _kcStoreinlistRpt.GetSingle(id);
            return new OkObjectResult(single);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]kc_storeinlist value)
        {
            _kcStoreinlistRpt.Add(value);
            _kcStoreinlistRpt.Commit();
            return new OkObjectResult(value);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]kc_storeinlist value)
        {
            var single = _kcStoreinlistRpt.GetSingle(id);

            if (single == null)
            {
                return NotFound();
            }
            _kcStoreinlistRpt.Commit();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var single = _kcStoreinlistRpt.GetSingle(id);
            if (single == null)
            {
                return new NotFoundResult();
            }

            _kcStoreinlistRpt.Commit();

            return new NoContentResult();
        }
    }
}
