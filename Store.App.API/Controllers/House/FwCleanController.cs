using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.App.Data.Abstract;
using Store.App.Model.House;
using Store.App.API.Core;
using AutoMapper;
using System.Security.Claims;
using Store.App.Model.SYS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    public class FwCleanController : Controller
    {
		private readonly IMapper _mapper;
        private readonly IFwCleanRepository _fwCleanRpt;
        private readonly ISysUserRepository _sysUserRpt;
        public FwCleanController(IFwCleanRepository fwCleanRpt,
            ISysUserRepository sysUserRpt,
                IMapper mapper)
        {
            _fwCleanRpt = fwCleanRpt;
            _sysUserRpt = sysUserRpt;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
		    IEnumerable<fw_clean> entityDto = null;
            await Task.Run(() =>
            {
				entityDto = _fwCleanRpt.FindBy(f => f.IsValid);
			});
            var entity = _mapper.Map<IEnumerable<fw_clean>, IEnumerable<FWCleanDto>>(entityDto).ToList();
            var userList = _sysUserRpt.GetAll();

            foreach (var ent in entity)
            {
                var sysUsers = userList as sys_user[] ?? userList.ToArray();
                var user = sysUsers.FirstOrDefault(f => f.UserId == ent.CleanMan);
                if (user != null) ent.CleanManTxt = user.UserName;
            }
            return new OkObjectResult(entityDto);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var single = _fwCleanRpt.GetSingle(id);
            return new OkObjectResult(single);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]fw_clean value)
        {
            value.CreatedAt = DateTime.Now;
			value.UpdatedAt = DateTime.Now;
            value.IsValid = true;
            if(User.Identity is ClaimsIdentity identity)
            {
                value.CreatedBy = identity.Name ?? "admin";
            }
            _fwCleanRpt.Add(value);
            _fwCleanRpt.Commit();
            return new OkObjectResult(value);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]fw_clean value)
        {
            var single = _fwCleanRpt.GetSingle(id);

            if (single == null)
            {
                return NotFound();
            }
            //更新字段内容
            single.UpdatedAt = DateTime.Now;
            if(User.Identity is ClaimsIdentity identity)
            {
                single.CreatedBy = identity.Name ?? "admin";
            }
            _fwCleanRpt.Commit();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var single = _fwCleanRpt.GetSingle(id);
            if (single == null)
            {
                return new NotFoundResult();
            }
            single.IsValid = false;
            _fwCleanRpt.Commit();

            return new NoContentResult();
        }
    }
}
