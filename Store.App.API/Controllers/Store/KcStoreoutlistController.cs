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
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    public class KcStoreoutlistController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IKcStoreoutlistRepository _kcStoreoutlistRpt;
        public KcStoreoutlistController(IKcStoreoutlistRepository kcStoreoutlistRpt,
                IMapper mapper)
        {
            _kcStoreoutlistRpt = kcStoreoutlistRpt;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<kc_storeoutlist> entityDto = null;
            await Task.Run(() =>
            {
                entityDto = _kcStoreoutlistRpt.GetAll();
            });
            return new OkObjectResult(entityDto);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var single = _kcStoreoutlistRpt.GetSingle(id);
            return new OkObjectResult(single);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]kc_storeoutlist value)
        {
            _kcStoreoutlistRpt.Add(value);
            _kcStoreoutlistRpt.Commit();
            return new OkObjectResult(value);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]kc_storeoutlist value)
        {
            var single = _kcStoreoutlistRpt.GetSingle(id);

            if (single == null)
            {
                return NotFound();
            }
            _kcStoreoutlistRpt.Commit();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var single = _kcStoreoutlistRpt.GetSingle(id);
            if (single == null)
            {
                return new NotFoundResult();
            }

            _kcStoreoutlistRpt.Commit();

            return new NoContentResult();
        }
    }
}
