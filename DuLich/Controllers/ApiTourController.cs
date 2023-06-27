using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DuLich.Controllers
{
    [EnableCors(origins: "http://localhost:50668", headers: "*", methods: "*")]
    public class ApiTourController : ApiController
    {
        //1. Get
        //Get xml
        [Route("Api/ApiTour/GetOne/")]
        public IHttpActionResult GetOne()
        {
            List<spTimkiemTour_Result> data = new mapTour().DanhSach(null, null, null);
            return Ok(data[0]);
        }

        [Route("Api/ApiTour/GetList/")]
        public List<spTimkiemTour_Result> GetList()
        {
            List<spTimkiemTour_Result> data = new mapTour().DanhSach(null,null,null); 
            return data;
        }
        //Get Json
        [Route("Api/ApiTour/GetOneJson/")]
        public IHttpActionResult GetOneJson()
        {
            List<spTimkiemTour_Result> data = new mapTour().DanhSach(null, null, null);
            // oject to json
            //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(data[0]);
            return Json(data[0]);
        }

        [Route("Api/ApiTour/GetListJson/")]
        public IHttpActionResult GetListJson()
        {
            List<spTimkiemTour_Result> data = new mapTour().DanhSach(null, null, null);
            return Json(data);
        }

        //2. Post
        [HttpPost]
        [Route("Api/ApiTour/PostData/")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostData(string username, string password, string address)
        {
            return Json(new { 
                result = true,
                message = "Thêm tk thành công"
            });
        }
    }
}
