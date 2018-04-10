using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.App.Data.Abstract;
using Store.App.Model.SYS;
using Store.App.API.Core;
using AutoMapper;
using System.Security.Claims;
using Store.App.API.Common;
using Store.App.Model.House;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    public class SmsTemplateController : Controller
    {
		private readonly IMapper _mapper;
        private readonly ISmsTemplateRepository _smsTemplateRpt;
        public SmsTemplateController(ISmsTemplateRepository smsTemplateRpt,
				IMapper mapper)
        {
            _smsTemplateRpt = smsTemplateRpt;
			_mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
		    IEnumerable<sms_template> entityDto = null;
            await Task.Run(() =>
            {
				entityDto = _smsTemplateRpt.FindBy(f => f.IsValid);
			});
            return new OkObjectResult(entityDto);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var single = _smsTemplateRpt.GetSingle(id);
            return new OkObjectResult(single);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]sms_template value)
        {
            value.CreatedAt = DateTime.Now;
			value.UpdatedAt = DateTime.Now;
			value.IsValid = true;
            if(User.Identity is ClaimsIdentity identity)
            {
                value.CreatedBy = identity.Name ?? "admin";
            }
            _smsTemplateRpt.Add(value);
            _smsTemplateRpt.Commit();
            return new OkObjectResult(value);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]sms_template value)
        {
            var single = _smsTemplateRpt.GetSingle(id);

            if (single == null)
            {
                return NotFound();
            }
            ObjectCopy.Copy<sms_template>(single, value, new string[] { "tmp_name", "to_business", "tmp_content", "remark" });
            //更新字段内容
            single.UpdatedAt = DateTime.Now;
			if(User.Identity is ClaimsIdentity identity)
			{
			    single.CreatedBy = identity.Name ?? "admin";
			}
            _smsTemplateRpt.Commit();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var single = _smsTemplateRpt.GetSingle(id);
            if (single == null)
            {
                return new NotFoundResult();
            }

            single.IsValid = false;
            _smsTemplateRpt.Commit();

            return new NoContentResult();
        }
    }
}
