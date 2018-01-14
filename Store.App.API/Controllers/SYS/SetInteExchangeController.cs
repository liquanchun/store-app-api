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
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    public class SetInteExchangeController : Controller
    {
		private readonly IMapper _mapper;
        private readonly ISetInteExchangeRepository _setInteExchangeRpt;
        private readonly ISetCardRepository _setCardRpt;
        public SetInteExchangeController(ISetInteExchangeRepository setInteExchangeRpt, ISetCardRepository setCardRpt,
                IMapper mapper)
        {
            _setInteExchangeRpt = setInteExchangeRpt;
            _setCardRpt = setCardRpt;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
		    IEnumerable<set_inte_exchange> entityDto = null;
            await Task.Run(() =>
            {
				entityDto = _setInteExchangeRpt.FindBy(f => f.IsValid);
			});
            var entity = _mapper.Map<IEnumerable<set_inte_exchange>, IEnumerable<SetIneExchangDto>>(entityDto).ToList();
            var cardTypeList = _setCardRpt.GetAll().ToList();
            foreach (var hs in entity)
            {
                hs.CardTypeTxt = cardTypeList.FirstOrDefault(f => f.Id == hs.CardType)?.Name;
            }
            return new OkObjectResult(entity);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var single = _setInteExchangeRpt.GetSingle(id);
            return new OkObjectResult(single);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]set_inte_exchange value)
        {
            value.CreatedAt = DateTime.Now;
            value.UpdatedAt = DateTime.Now;
            value.IsValid = true;
            if(User.Identity is ClaimsIdentity identity)
            {
                value.CreatedBy = identity.Name ?? "test";
            }
            _setInteExchangeRpt.Add(value);
            _setInteExchangeRpt.Commit();
            return new OkObjectResult(value);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]set_inte_exchange value)
        {
            var single = _setInteExchangeRpt.GetSingle(id);

            if (single == null)
            {
                return NotFound();
            }
            //更新字段内容
            single.UpdatedAt = DateTime.Now;
            single.CardType = value.CardType;
            single.EndDate = value.EndDate;
            single.ExchangeInte = value.ExchangeInte;
            single.ExchangeType = value.ExchangeType;
            single.GiftName = value.GiftName;
            single.Name = value.Name;
            single.Remark = value.Remark;
            if(User.Identity is ClaimsIdentity identity)
            {
                single.CreatedBy = identity.Name ?? "test";
            }
            _setInteExchangeRpt.Commit();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var single = _setInteExchangeRpt.GetSingle(id);
            if (single == null)
            {
                return new NotFoundResult();
            }
            single.IsValid = false;
            _setInteExchangeRpt.Commit();

            return new NoContentResult();
        }
    }
}
