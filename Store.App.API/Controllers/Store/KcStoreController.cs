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
using Store.App.Model.Dto;
using Store.App.Model.SYS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class KcStoreController : Controller
    {
		private readonly IMapper _mapper;
        private readonly IKcStoreRepository _kcStoreRpt;
        private readonly IKcGoodsRepository _kcGoodsRepository;
        private readonly ISysDicRepository _sysDicRepository;
        private readonly ISysOrgRepository _sysOrgRepository;
        private readonly IKcStoreinlistRepository _kcStoreinlistRepository;
        public KcStoreController(IKcStoreRepository kcStoreRpt,
            ISysDicRepository sysDicRepository,
            IKcGoodsRepository kcGoodsRepository,
            ISysOrgRepository sysOrgRepository,
            IKcStoreinlistRepository kcStoreinlistRepository,
                IMapper mapper)
        {
            _kcStoreRpt = kcStoreRpt;
			_mapper = mapper;
            _sysDicRepository = sysDicRepository;
            _kcGoodsRepository = kcGoodsRepository;
            _sysOrgRepository = sysOrgRepository;
            _kcStoreinlistRepository = kcStoreinlistRepository;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(GetByStore(0));
        }

        public List<StoreDto> GetByStore(int storeId)
        {
            IEnumerable<kc_store> entityDto = _kcStoreRpt.FindBy(f => f.IsValid && f.Number > 0);
            if(storeId > 0)
            {
                entityDto = _kcStoreRpt.FindBy(f => f.IsValid && f.StoreId == storeId && f.Number > 0);
            }
            var storeDtoList = _mapper.Map<IEnumerable<kc_store>, IEnumerable<StoreDto>>(entityDto).ToList();

            var kcGoodsList = _kcGoodsRepository.GetAll();
            var sysDicList = _sysDicRepository.GetAll();
            var sysOrgList = _sysOrgRepository.GetAll();
            var storeinList = _kcStoreinlistRepository.GetAll();

            var sysDics = sysDicList as sys_dic[] ?? sysDicList.ToArray();
            var kcGoodses = kcGoodsList as kc_goods[] ?? kcGoodsList.ToArray();
            var sysOrgs = sysOrgList as sys_org[] ?? sysOrgList.ToArray();
            var storeins = storeinList as kc_storeinlist[] ?? storeinList.ToArray();

            foreach (var store in storeDtoList)
            {
                store.GoodsTypeIdTxt = sysDics.FirstOrDefault(f => f.Id == store.GoodsTypeId)?.DicName;
                store.StoreIdTxt = sysDics.FirstOrDefault(f => f.Id == store.StoreId)?.DicName;

                var gd = kcGoodses.FirstOrDefault(f => f.Id == store.GoodsId);
                store.GoodsIdTxt = gd?.Name;
                store.GoodsCode = gd?.GoodsCode;
                store.GoodsNo = gd?.GoodsNo;
                store.Unit = gd?.Unit;
                store.Price = storeins.FirstOrDefault(f => f.GoodsId == store.GoodsId && f.batchno == store.BatchNo)?.price;
                if(store.Price == null || store.Price <=0)
                {
                    store.Price = gd?.Price;
                }
                store.OrgTxt = sysOrgs.FirstOrDefault(f => f.Id == store.OrgId)?.DeptName;
            }
            return storeDtoList;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new OkObjectResult(GetByStore(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]kc_store value)
        {
            value.CreatedAt = DateTime.Now;
			value.UpdatedAt = DateTime.Now;
            value.IsValid = true;
            if(User.Identity is ClaimsIdentity identity)
            {
                value.CreatedBy = identity.Name ?? "admin";
            }
            _kcStoreRpt.Add(value);
            _kcStoreRpt.Commit();
            return new OkObjectResult(value);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]kc_store value)
        {
            var single = _kcStoreRpt.GetSingle(id);

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
            _kcStoreRpt.Commit();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var single = _kcStoreRpt.GetSingle(id);
            if (single == null)
            {
                return new NotFoundResult();
            }
            single.IsValid = false;
            _kcStoreRpt.Commit();

            return new NoContentResult();
        }
    }
}
