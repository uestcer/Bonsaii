﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bonsaii.Models;

namespace Bonsaii.Controllers
{
    public class RecruitmentsController : BaseController
    {
        // GET: Recruitments
        public ActionResult Index()
        {
            return View(db.Recruitments.ToList());
        }

        // GET: Recruitments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruitments recruitments = db.Recruitments.Find(id);
            if (recruitments == null)
            {
                return HttpNotFound();
            }
            return View(recruitments);
        }

        // GET: Recruitments/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentsList = new SelectList(db.Departments.ToList(), "Name", "Name");

     //       ViewBag.PositionsList = new SelectList(db.)
         //   var tmp = from x in db.StaffParams where (from d in db.StaffParamTypes where d.Name == "员工岗位" select d.Id).Contains(x.StaffParamTypeId) select x.Value;

            ViewBag.PositionsList = this.GetParamsByName("员工岗位");

            ViewBag.GendersList = this.GetParamsByName("性别");
            ViewBag.MaritalStatusList = this.GetParamsByName("婚姻状况");
            ViewBag.EduBackgroundsList = this.GetParamsByName("学历");
            ViewBag.MajorsList = this.GetParamsByName("专业");

            return View();
        }

        // POST: Recruitments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recruitments recruitments)
        {
            Recruitments tmpRecruit = new Recruitments()
            {
                BillType = Request["BillType"].Length == 4 ? Request["BillType"] : Request["BillType"].Substring(0,4),
                BillCode = Request["BillCode"],
                DepartmentName = Request["DepartmentName"],
                Position = Request["Position"],
                RequiredNumber = int.Parse(Request["RequiredNumber"]),
                Gender = Request["Gender"],
                Age =Request["Age"],
                MaritalStatus = Request["MaritalStatus"],
                EducationBackground = Request["EducationBackground"],
                Major = Request["Major"],
                WorkExperience = Request["WorkExperience"],
                Skill = Request["Skill"],
                Others = Request["Others"],
                Status = "等待招聘"
            };
            if (ModelState.IsValid)
            {
                db.Recruitments.Add(tmpRecruit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruitments);
        }

        // GET: Recruitments/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruitments recruitments = db.Recruitments.Find(id);
            if (recruitments == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillType = recruitments.BillType;
            ViewBag.BillCode = recruitments.BillCode;
            ViewBag.DepartmentsList = new SelectList(db.Departments.ToList(), "Name", "Name",recruitments.DepartmentName);

            ViewBag.PositionsList = new SelectList(this.GetParamsListByName("员工岗位"), recruitments.Position);//this.GetParamsByName("员工岗位");
            ViewBag.RequiredNumber = recruitments.RequiredNumber.ToString();
            ViewBag.GendersList = new MultiSelectList(this.GetParamsListByName("性别"),this.SelectedListByName(recruitments.Gender));
            ViewBag.Age = recruitments.Age.ToString();
            ViewBag.MaritalStatusList = new MultiSelectList(this.GetParamsListByName("婚姻状况"),this.SelectedListByName(recruitments.MaritalStatus));
            ViewBag.EduBackgroundsList = new MultiSelectList(this.GetParamsListByName("学历"),this.SelectedListByName(recruitments.EducationBackground));
            ViewBag.MajorsList = new MultiSelectList(this.GetParamsListByName("专业"),this.SelectedListByName(recruitments.Major));

            ViewBag.WorkExperience = recruitments.WorkExperience;
            ViewBag.Skill = recruitments.Skill;
            ViewBag.Others = recruitments.Others;
            ViewBag.Status = recruitments.Status;
            return View();
        }

        // POST: Recruitments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BillType,BillCode,DepartmentName,Position,RequiredNumber,Gender,Age,MaritalStatus,EducationBackground,Major,WorkExperience,Skill,Others,Status")] Recruitments recruitments)
        {
            if (ModelState.IsValid)
            {
                Recruitments tmp = db.Recruitments.Find(recruitments.Id);
                    tmp.BillType = Request["BillType"];
                    tmp.BillCode = Request["BillCode"];
                    tmp.DepartmentName = Request["DepartmentName"];
                    tmp.Position = Request["Position"];
                    tmp.RequiredNumber = int.Parse(Request["RequiredNumber"]);
                    tmp.Gender = Request["Gender"];
                    tmp.Age = Request["Age"];
                    tmp.MaritalStatus = Request["MaritalStatus"];
                    tmp.EducationBackground = Request["EducationBackground"];
                    tmp.Major = Request["Major"];
                    tmp.WorkExperience = Request["WorkExperience"];
                    tmp.Skill = Request["Skill"];
                    tmp.Others = Request["Others"];
                    tmp.Status = Request["Status"];
                    db.Entry(tmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruitments);
        }

        public ActionResult TestEdit()
        {
            int id = 2;
            Recruitments recruitments = db.Recruitments.Find(id);
            if (recruitments == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillType = recruitments.BillType;
            ViewBag.BillCode = recruitments.BillCode;
            ViewBag.DepartmentsList = new SelectList(db.Departments.ToList(), "Name", "Name", recruitments.DepartmentName);

            ViewBag.PositionsList = new SelectList(this.GetParamsListByName("员工岗位"), recruitments.Position);//this.GetParamsByName("员工岗位");
            ViewBag.RequiredNumber = recruitments.RequiredNumber.ToString();
            ViewBag.GendersList = new MultiSelectList(this.GetParamsListByName("性别"), this.SelectedListByName(recruitments.Gender));
            ViewBag.Age = recruitments.Age.ToString();
            ViewBag.MaritalStatusList = new MultiSelectList(this.GetParamsListByName("婚姻状况"), this.SelectedListByName(recruitments.MaritalStatus));
            ViewBag.EduBackgroundsList = new MultiSelectList(this.GetParamsListByName("学历"), this.SelectedListByName(recruitments.EducationBackground));
            ViewBag.MajorsList = new MultiSelectList(this.GetParamsListByName("专业"), this.SelectedListByName(recruitments.Major));

            ViewBag.WorkExperience = recruitments.WorkExperience;
            ViewBag.Skill = recruitments.Skill;
            ViewBag.Others = recruitments.Others;
            ViewBag.Status = recruitments.Status;
            return View();
        }

        // GET: Recruitments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruitments recruitments = db.Recruitments.Find(id);
            if (recruitments == null)
            {
                return HttpNotFound();
            }
            return View(recruitments);
        }

        // POST: Recruitments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recruitments recruitments = db.Recruitments.Find(id);
            db.Recruitments.Remove(recruitments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult BillTypeSearch(string number)
        {

            try
            {
                // var item = db.Staffs.Where(w => (w.StaffNumber).Contains(number)).ToList().Select(w => new { id=w.StaffNumber,name=w.StaffNumber});
                var items = (from p in db.BillProperties where p.Type.Contains(number) || p.TypeName.Contains(number) select p.Type + "-" + p.TypeName).ToList();//.ToList().Select p;
                return Json(
                    new {
                    success = true,
                    data = items
                });
            }
            catch (Exception e) 
            { 
                return Json(new { success = false, msg = e.Message }); 
            }

        }
        /// <summary>
        /// 根据人事基本参数的名称，获取具体的参数内容（比如：参数为“婚姻状况”，返回值为“已婚”、“未婚”、”离异“）,用于构成下拉列表
        /// </summary>
        /// <param name="TypeName">人事参数的类型名称</param>
        /// <returns>返回具体的参数内容的列表</returns>
        public SelectList GetParamsByName(string TypeName)
        {
            List<string> tmp = (from x in db.StaffParams where (from d in db.StaffParamTypes where d.Name == TypeName select d.Id).Contains(x.StaffParamTypeId) select x.Value).ToList();
            return new SelectList(tmp);
        }
        /// <summary>
        /// 根据人事基本参数的名称，获取具体的参数内容（比如：参数为“婚姻状况”，返回值为“已婚”、“未婚”、”离异“），用于构成多选框选项
        /// </summary>
        /// <param name="TypeName"></param>
        /// <returns></returns>
        public List<string> GetParamsListByName(string TypeName)
        {
            return (from x in db.StaffParams where (from d in db.StaffParamTypes where d.Name == TypeName select d.Id).Contains(x.StaffParamTypeId) select x.Value).ToList();
        }

        /// <summary>
        /// 字符串根据逗号分隔
        /// </summary>
        /// <param name="id">招聘单的Id和要获取的属性的名称</param>
        /// <returns></returns>
        public string[] SelectedListByName(string Name)
        {
            return Name.Split(new char[] { ',' });
        }

        public ActionResult FileUpload()
        {
            HttpPostedFileBase file = Request.Files["file"];
            if (file != null)
            {
                string str = "tmp";
            }
            return View();
        }

        public ActionResult TestFileUpload()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
