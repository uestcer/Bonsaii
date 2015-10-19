﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bonsaii.Models
{
    [Table("StaffChanges")]
    public class StaffChange
    {
        /* 这是StaffChange模型中字段*/
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name="单据类别编号")]
        public string BillTypeNumber { get; set; }
        [Required]
        [Display(Name="单据类别名称")]
        public string BillTypeName { get; set; }
        [Required]
        [Display(Name="单号")]
        public string BillNumber { get; set; }
        [Required]
        [Display(Name="员工工号")]
        public string StaffNumber { get; set; }

        /* 这是Staff模型中字段*/
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "性别")]
        public string Gender { get; set; }
        [Display(Name = "部门")]

        public string Department { get; set; }
        [Display(Name = "工种")]
        public string WorkType { get; set; }
        [Display(Name = "员工职位")]
        public string Position { get; set; }
        [Display(Name = "证件类型")]
        public string IdentificationType { get; set; }
        [Display(Name = "国籍")]
        public string Nationality { get; set; }
        [Display(Name = "证件号码")]
        [RegularExpression(@"^(\d{15}|\d{18}|\d{17}[x])$", ErrorMessage = "身份证号(15位或18位数字)")]
        public string IdentificationNumber { get; set; }
        [Display(Name = "入职日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<DateTime> Entrydate { get; set; }
        [Display(Name = "班次")]
        public string ClassOrder { get; set; }
        //[Display(Name = "手机APP")]
        //public string AppSwitch { get; set; }
        [Display(Name = "在职")]
        public string JobState { get; set; }
        [Display(Name = "异动类型")]
        public string AbnormalChange { get; set; }
        [Display(Name = "免卡")]
        public Boolean FreeCard { get; set; }
        [Display(Name = "用工性质")]
        public string WorkProperty { get; set; }
        [Display(Name = "加班需申请")]
        public Boolean ApplyOvertimeSwitch { get; set; }
        [Display(Name = "员工来源")]
        public string Source { get; set; }
        [Display(Name = "试用期满")]
        public string QualifyingPeriodFull { get; set; }
        [Display(Name = "婚姻状况")]
        public string MaritalStatus { get; set; }
        [Display(Name = "出生日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public Nullable<DateTime> BirthDate { get; set; }
        [Display(Name = "籍贯")]
        public string NativePlace { get; set; }
        [Display(Name = "健康状况")]
        public string HealthCondition { get; set; }
        [Display(Name = "民族")]
        public string Nation { get; set; }
        [Display(Name = "家庭住址")]
        public string Address { get; set; }
        [Display(Name = "签证机关")]
        public string VisaOffice { get; set; }
        [Display(Name = "家庭电话")]
        //[RegularExpression(@"^(\(\d{3,4}-)|\d{3.4}-)?\d{7,8}$",ErrorMessage="电话格式不正确")]
        public string HomeTelNumber { get; set; }
        [Display(Name = "学历")]
        public string EducationBackground { get; set; }
        [Display(Name = "毕业院校")]
        public string GraduationSchool { get; set; }
        [Display(Name = "专业")]
        public string SchoolMajor { get; set; }
        [Display(Name = "学位")]
        public string Degree { get; set; }
        [Display(Name = "介绍人")]
        public string Introducer { get; set; }
        [Display(Name = "手机号码")]
        [Phone]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "手机号码是11位数字")]
        public string IndividualTelNumber { get; set; }
        [Display(Name = "银行卡号")]
        public string BankCardNumber { get; set; }
        [Display(Name = "紧急联系人姓名")]
        public string UrgencyContactMan { get; set; }
        [Display(Name = "紧急联系人地址")]
        public string UrgencyContactAddress { get; set; }
        [Display(Name = "紧急联系人电话")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "手机号码是11位数字")]
        [Phone]
        public string UrgencyContactPhoneNumber { get; set; }
        [Display(Name = "黑名单")]
        public Boolean InBlacklist { get; set; }
        [Display(Name = "物理卡号")]
        public string PhysicalCardNumber { get; set; }
        [Display(Name = "审核状态")]
        public string AuditStatus { get; set; }

        /* 这是StaffChange模型中字段*/
        [Required]
        [Display(Name="生效日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EffectiveDate { get; set; }
        [Display(Name="备注")]
        public string Remark { get; set; }
    }
}