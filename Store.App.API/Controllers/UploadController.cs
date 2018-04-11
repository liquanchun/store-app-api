using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.AspNetCore.Hosting;
using Store.App.API.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.App.API.Controllers
{

    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public UploadController(IKcGoodsRepository kcGoodsRpt, ISysDicRepository sysDicRpt,
            IHostingEnvironment hostingEnvironment,
        IMapper mapper)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("api/uploads")]
        public IActionResult PostUpload()
        {
            var myHttpPostedFile = Request.Form.Files[0];
            string sPath = _hostingEnvironment.ContentRootPath + "\\Files\\";
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }
            string filePath = sPath + myHttpPostedFile.FileName;
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                myHttpPostedFile.CopyTo(stream);
            }
            string sReturn = myHttpPostedFile.FileName;
            return Ok(sReturn); //³É¹¦
        }
    }
}
