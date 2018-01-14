using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.App.Data.Abstract;
using Store.App.Model.Account;
using Store.App.API.Core;
using AutoMapper;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    public class CwPrefeeController : Controller
    {
		private readonly IMapper _mapper;
        private readonly ISysDicRepository _sysDicRpt;
        private readonly ISetPaytypeRepository _setPaytypeRepository;
        private readonly ICwPrefeeRepository _cwPrefeeRpt;
        public CwPrefeeController(ICwPrefeeRepository cwPrefeeRpt, ISysDicRepository sysDicRpt, ISetPaytypeRepository setPaytypeRepository,
                IMapper mapper)
        {
            _cwPrefeeRpt = cwPrefeeRpt;
            _setPaytypeRepository = setPaytypeRepository;
            _sysDicRpt = sysDicRpt;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
		    IEnumerable<cw_prefee> entityDto = null;
            await Task.Run(() =>
            {
				entityDto = _cwPrefeeRpt.FindBy(f => f.IsValid);
			});
            var entity = _mapper.Map<IEnumerable<cw_prefee>, IEnumerable<CWPreFeeDto>>(entityDto).ToList();

            var payTypeList = this._setPaytypeRepository.GetAll();
            foreach (var hs in entity)
            {
                hs.PayTypeTxt = payTypeList.FirstOrDefault(f => f.Id == hs.PayType).Name;
            }
            return new OkObjectResult(entity);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var single = _cwPrefeeRpt.GetSingle(id);
            return new OkObjectResult(single);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]cw_prefee value)
        {
            value.CreatedAt = DateTime.Now;
			value.IsValid = true;
            if(User.Identity is ClaimsIdentity identity)
            {
                value.CreatedBy = identity.Name ?? "test";
            }
            _cwPrefeeRpt.Add(value);
            _cwPrefeeRpt.Commit();
            return new OkObjectResult(value);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]cw_prefee value)
        {
            var single = _cwPrefeeRpt.GetSingle(id);

            if (single == null)
            {
                return NotFound();
            }
			//更新字段内容
			if(User.Identity is ClaimsIdentity identity)
			{
				single.CreatedBy = identity.Name ?? "test";
			}
            _cwPrefeeRpt.Commit();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var single = _cwPrefeeRpt.GetSingle(id);
            if (single == null)
            {
                return new NotFoundResult();
            }

            single.IsValid = false;
            _cwPrefeeRpt.Commit();

            return new NoContentResult();
        }
    }
}
