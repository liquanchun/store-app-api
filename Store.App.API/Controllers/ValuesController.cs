using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.App.Data;
using Microsoft.EntityFrameworkCore;
using Store.App.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Store.App.Model.Dto;

namespace Store.App.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly StoreAppContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ValuesController(ILogger<ValuesController> logger, StoreAppContext context, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Index page says hello");
            //using (var context = new MyContext())
            //{
            //    return new string[] { "value1", "value2", context.Users.Count().ToString() };
            //}
            return new string[] { "value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string Get(int id)
        {
            if (User.Identity is ClaimsIdentity identity)
            {
                return identity.Name ?? "admin";
            }
            return "no";
        }
        // POST api/values
        [HttpPost("cashorder")]
        public Paras CreateCashFile([FromBody]Paras paras)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var addrUrl = webRootPath + $@"\temp\{paras.FileName}";
            if (System.IO.File.Exists(addrUrl))
            {
                System.IO.File.Delete(addrUrl);
            }
            string sqlstring = $"Select * from {paras.ViewName} where {paras.Where}";
            var dataList = _context.Set<CashBill>().FromSql(sqlstring).ToList();
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("单号");
            row1.CreateCell(1).SetCellValue("状态");
            row1.CreateCell(2).SetCellValue("开票日期");
            row1.CreateCell(3).SetCellValue("购买性质");
            row1.CreateCell(4).SetCellValue("购买资质");

            row1.CreateCell(5).SetCellValue("客户属性");
            row1.CreateCell(6).SetCellValue("付款方式");
            row1.CreateCell(7).SetCellValue("保险公司");
            row1.CreateCell(8).SetCellValue("优惠金额");
            row1.CreateCell(9).SetCellValue("新车款金额");

            row1.CreateCell(10).SetCellValue("分期首付款金额");
            row1.CreateCell(11).SetCellValue("保险费金额");
            row1.CreateCell(12).SetCellValue("购置税金额");
            row1.CreateCell(13).SetCellValue("金融服务费金额");
            row1.CreateCell(14).SetCellValue("装饰费金额");

            row1.CreateCell(15).SetCellValue("交车综合服务费");
            row1.CreateCell(16).SetCellValue("安心服务费");
            row1.CreateCell(17).SetCellValue("贴心服务费");
            row1.CreateCell(18).SetCellValue("玻璃保障服务费");
            row1.CreateCell(19).SetCellValue("刷卡费金额");

            row1.CreateCell(20).SetCellValue("其他金额");
            row1.CreateCell(21).SetCellValue("应收金额总计");
            row1.CreateCell(22).SetCellValue("开票金额");
            row1.CreateCell(23).SetCellValue("已付订金");
            row1.CreateCell(24).SetCellValue("旧车置换金额");

            row1.CreateCell(25).SetCellValue("金融分期尾款金额");
            row1.CreateCell(26).SetCellValue("其他金额");
            row1.CreateCell(27).SetCellValue("实收金额总计");
            row1.CreateCell(28).SetCellValue("保险费");
            row1.CreateCell(29).SetCellValue("装修费");

            row1.CreateCell(30).SetCellValue("佣金");
            row1.CreateCell(31).SetCellValue("维修费");
            row1.CreateCell(32).SetCellValue("汽油费");
            row1.CreateCell(33).SetCellValue("其他");
            row1.CreateCell(34).SetCellValue("审核人");

            row1.CreateCell(35).SetCellValue("审核结果");
            row1.CreateCell(36).SetCellValue("审核意见");
            row1.CreateCell(37).SetCellValue("审核时间");
            row1.CreateCell(38).SetCellValue("备注");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < dataList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(dataList[i].OrderId);
                rowtemp.CreateCell(1).SetCellValue(dataList[i].Status);
                rowtemp.CreateCell(2).SetCellValue(dataList[i].InvoiceDate);
                rowtemp.CreateCell(3).SetCellValue(dataList[i].BuyType);
                rowtemp.CreateCell(4).SetCellValue(dataList[i].BuyLicense);

                rowtemp.CreateCell(5).SetCellValue(dataList[i].CustAttr);
                rowtemp.CreateCell(6).SetCellValue(dataList[i].PayType);
                rowtemp.CreateCell(7).SetCellValue(dataList[i].InsureCompany);
                rowtemp.CreateCell(8).SetCellValue(dataList[i].Discount);
                rowtemp.CreateCell(9).SetCellValue((double)dataList[i].NewCarFee);

                rowtemp.CreateCell(10).SetCellValue((double)dataList[i].FirstFee);
                rowtemp.CreateCell(11).SetCellValue((double)dataList[i].InsureFee);
                rowtemp.CreateCell(12).SetCellValue((double)dataList[i].BuyTaxFee);
                rowtemp.CreateCell(13).SetCellValue((double)dataList[i].FinanceSerFee);
                rowtemp.CreateCell(14).SetCellValue((double)dataList[i].DecorateFee);

                rowtemp.CreateCell(15).SetCellValue((double)dataList[i].TakeAllFee);
                rowtemp.CreateCell(16).SetCellValue((double)dataList[i].TakeCareFee);
                rowtemp.CreateCell(17).SetCellValue((double)dataList[i].IntimateFee);
                rowtemp.CreateCell(18).SetCellValue((double)dataList[i].GlassSerFee);
                rowtemp.CreateCell(19).SetCellValue((double)dataList[i].CardCashFee);

                rowtemp.CreateCell(20).SetCellValue((double)dataList[i].OtherFee);
                rowtemp.CreateCell(21).SetCellValue((double)dataList[i].ShouldAllFee);
                rowtemp.CreateCell(22).SetCellValue((double)dataList[i].InvoiceFee);
                rowtemp.CreateCell(23).SetCellValue((double)dataList[i].Deposit);
                rowtemp.CreateCell(24).SetCellValue((double)dataList[i].OldChangeFee);

                rowtemp.CreateCell(25).SetCellValue((double)dataList[i].LastFee);
                rowtemp.CreateCell(26).SetCellValue((double)dataList[i].OtherFee2);
                rowtemp.CreateCell(27).SetCellValue((double)dataList[i].RealAllFee);
                rowtemp.CreateCell(28).SetCellValue((double)dataList[i].BaoxianFee);
                rowtemp.CreateCell(29).SetCellValue((double)dataList[i].ZhuangxFee);

                rowtemp.CreateCell(30).SetCellValue((double)dataList[i].Commission);
                rowtemp.CreateCell(31).SetCellValue((double)dataList[i].MaintainFee);
                rowtemp.CreateCell(32).SetCellValue((double)dataList[i].GasFee);
                rowtemp.CreateCell(33).SetCellValue((double)dataList[i].OtherFee3);
                rowtemp.CreateCell(34).SetCellValue(dataList[i].Auditor);


                rowtemp.CreateCell(35).SetCellValue(dataList[i].AuditResult);
                rowtemp.CreateCell(36).SetCellValue(dataList[i].AuditSuggest);
                rowtemp.CreateCell(37).SetCellValue(dataList[i].AuditTime);
                rowtemp.CreateCell(38).SetCellValue(dataList[i].Remark);
            }
            // 写入到客户端 
            using (FileStream fs = new FileStream(addrUrl, FileMode.Create))
            {
                book.Write(fs);
            }
            book = null;
            return paras;
        }
        // POST api/values
        [HttpPost("saleorder")]
        public Paras CreateSaleFile([FromBody]Paras paras)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var addrUrl = webRootPath + $@"\temp\{paras.FileName}";
            if (System.IO.File.Exists(addrUrl))
            {
                System.IO.File.Delete(addrUrl);
            }
            string sqlstring = $"Select * from {paras.ViewName} where {paras.Where}";
            var dataList = _context.Set<SaleBill>().FromSql(sqlstring).ToList();
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("单号");
            row1.CreateCell(1).SetCellValue("日期");
            row1.CreateCell(2).SetCellValue("状态");
            row1.CreateCell(3).SetCellValue("销售顾问");
            row1.CreateCell(4).SetCellValue("DMS号");

            row1.CreateCell(5).SetCellValue("客户");
            row1.CreateCell(6).SetCellValue("地址");
            row1.CreateCell(7).SetCellValue("联系人");
            row1.CreateCell(8).SetCellValue("电话");
            row1.CreateCell(9).SetCellValue("证件号码");

            row1.CreateCell(10).SetCellValue("牌照属性");
            row1.CreateCell(11).SetCellValue("证件地址");
            row1.CreateCell(12).SetCellValue("客户性质");
            row1.CreateCell(13).SetCellValue("车型");
            row1.CreateCell(14).SetCellValue("车身颜色");

            row1.CreateCell(15).SetCellValue("内饰颜色");
            row1.CreateCell(16).SetCellValue("指导价");
            row1.CreateCell(17).SetCellValue("新车销售价");
            row1.CreateCell(18).SetCellValue("定金");
            row1.CreateCell(19).SetCellValue("车架号");

            row1.CreateCell(20).SetCellValue("增值预估费");
            row1.CreateCell(21).SetCellValue("整单费用合计");
            row1.CreateCell(22).SetCellValue("个性化配置");
            row1.CreateCell(23).SetCellValue("优惠点");
            row1.CreateCell(24).SetCellValue("预计交车日期");

            row1.CreateCell(25).SetCellValue("交车地点");
            row1.CreateCell(26).SetCellValue("联系电话");
            row1.CreateCell(27).SetCellValue("提车方式");
            row1.CreateCell(28).SetCellValue("接车人");
            row1.CreateCell(29).SetCellValue("接车电话");

            row1.CreateCell(30).SetCellValue("付款方式");
            row1.CreateCell(31).SetCellValue("预定付款天数");
            row1.CreateCell(32).SetCellValue("现车付款天数");
            row1.CreateCell(33).SetCellValue("分期签约机构");
            row1.CreateCell(34).SetCellValue("首付金额");

            row1.CreateCell(35).SetCellValue("分期期数");
            row1.CreateCell(36).SetCellValue("首付时效天数");
            row1.CreateCell(37).SetCellValue("审核结果");
            row1.CreateCell(38).SetCellValue("审核人");
            row1.CreateCell(39).SetCellValue("审核意见");

            row1.CreateCell(40).SetCellValue("审核时间");
            row1.CreateCell(41).SetCellValue("备注");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < dataList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(dataList[i].OrderId);
                rowtemp.CreateCell(1).SetCellValue(dataList[i].OrderDate);
                rowtemp.CreateCell(2).SetCellValue(dataList[i].Status);
                rowtemp.CreateCell(3).SetCellValue(dataList[i].SaleMan);
                rowtemp.CreateCell(4).SetCellValue(dataList[i].DMSNo);

                rowtemp.CreateCell(5).SetCellValue(dataList[i].Name);
                rowtemp.CreateCell(6).SetCellValue(dataList[i].Address);
                rowtemp.CreateCell(7).SetCellValue(dataList[i].LinkMan);
                rowtemp.CreateCell(8).SetCellValue(dataList[i].Phone);
                rowtemp.CreateCell(9).SetCellValue(dataList[i].IdCard);

                rowtemp.CreateCell(10).SetCellValue(dataList[i].LicenseType);
                rowtemp.CreateCell(11).SetCellValue(dataList[i].IdAddress);
                rowtemp.CreateCell(12).SetCellValue(dataList[i].CustType);
                rowtemp.CreateCell(13).SetCellValue(dataList[i].CarType);
                rowtemp.CreateCell(14).SetCellValue(dataList[i].CarColor);

                rowtemp.CreateCell(15).SetCellValue(dataList[i].CarTrim);
                rowtemp.CreateCell(16).SetCellValue((double)dataList[i].GuidePrice);
                rowtemp.CreateCell(17).SetCellValue((double)dataList[i].SalePrice);
                rowtemp.CreateCell(18).SetCellValue((double)dataList[i].Deposit);
                rowtemp.CreateCell(19).SetCellValue(dataList[i].Vinno);

                rowtemp.CreateCell(20).SetCellValue((double)dataList[i].PredictFee);
                rowtemp.CreateCell(21).SetCellValue((double)dataList[i].WholeFee);
                rowtemp.CreateCell(22).SetCellValue(dataList[i].SelfConfig);
                rowtemp.CreateCell(23).SetCellValue((double)dataList[i].Discount);
                rowtemp.CreateCell(24).SetCellValue(dataList[i].PreCarDate);

                rowtemp.CreateCell(25).SetCellValue(dataList[i].TakeCarSite);
                rowtemp.CreateCell(26).SetCellValue(dataList[i].TakePhone);
                rowtemp.CreateCell(27).SetCellValue(dataList[i].PickCarType);
                rowtemp.CreateCell(28).SetCellValue(dataList[i].PickCarMan);
                rowtemp.CreateCell(29).SetCellValue(dataList[i].PickCarMobile);

                rowtemp.CreateCell(30).SetCellValue(dataList[i].PayType);
                rowtemp.CreateCell(31).SetCellValue(dataList[i].Days2);
                rowtemp.CreateCell(32).SetCellValue(dataList[i].Days1);
                rowtemp.CreateCell(33).SetCellValue(dataList[i].FinaceCompany);
                rowtemp.CreateCell(34).SetCellValue((double)dataList[i].FirstFee);

                rowtemp.CreateCell(35).SetCellValue(dataList[i].Stages);
                rowtemp.CreateCell(36).SetCellValue(dataList[i].Days3);
                rowtemp.CreateCell(37).SetCellValue(dataList[i].AuditResult);
                rowtemp.CreateCell(38).SetCellValue(dataList[i].Auditor);
                rowtemp.CreateCell(39).SetCellValue(dataList[i].AuditSuggest);

                rowtemp.CreateCell(40).SetCellValue(dataList[i].AuditTime);
                rowtemp.CreateCell(41).SetCellValue(dataList[i].Remark);
            }
            // 写入到客户端 
            using (FileStream fs = new FileStream(addrUrl, FileMode.Create))
            {
                book.Write(fs);
            }
            book = null;
            return paras;
        }
        // POST api/values
        [HttpGet("getfile/{filename}")]
        public IActionResult GetFile(string filename)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var addrUrl = webRootPath + $@"\temp\{filename}";
            var fileExt = new System.IO.FileInfo(addrUrl);
            FileStream stream = new FileStream(addrUrl, FileMode.Open, FileAccess.Read);
            //获取文件的ContentType
            var provider = new FileExtensionContentTypeProvider();
            var memi = provider.Mappings[fileExt.Extension];
            return File(stream, memi, Path.GetFileName(addrUrl));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Paras
    {
        public string Where { get; set; }
        public string FileName { get; set; }

        public string ViewName { get; set; }
    }
}
