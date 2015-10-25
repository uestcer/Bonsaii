using Bonsaii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bonsaii.Controllers
{
    public class StaffParamController : BaseController
    {
        // GET: StaffParam
        public ActionResult Index()
        {
            List<SelectListItem> item = db.StaffParamTypes.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            item.Insert(0, new SelectListItem{ Value = "0",Text = ""});
            ViewBag.StaffParamTypesList = item;
            return View();
        }

        public JsonResult GetStaffParams(int StaffParamTypeId)
        {
            List<StaffParam> list = db.StaffParams.Where(p => p.StaffParamTypeId == StaffParamTypeId).ToList();
            return Json(list);
        }


        public ActionResult StaffParamsIndex()
        {
            return View();
        }
    }
}