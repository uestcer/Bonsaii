using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bonsaii.Models
{
    public class BonsaiiDbContext : DbContext
    {
        public BonsaiiDbContext(): base("DefaultConnection"){}
        //含有连接字符串参数的构造函数，会连接参数中传递的数据库
        public BonsaiiDbContext(string conn)
            : base(conn)
        {
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public DbSet<Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Bonsaii.Models.GroupCompany> GroupCompanies { get; set; }

        public DbSet<VerifyCode> VerifyCodes { get; set; }

        public DbSet<UserModels> Users { get; set; }


        public DbSet<UserRole> UserRoles { get; set; }
        public System.Data.Entity.DbSet<Bonsaii.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<Bonsaii.Models.Phrase> Phrases { get; set; }

        public System.Data.Entity.DbSet<Bonsaii.Models.PhraseScene> PhraseScenes { get; set; }
        public System.Data.Entity.DbSet<Bonsaii.Models.Staff> Staffs { get; set; }


        public System.Data.Entity.DbSet<Bonsaii.Models.Nationality> Nationalities { get; set; }

        public System.Data.Entity.DbSet<Bonsaii.Models.Health> Healths { get; set; }

        public System.Data.Entity.DbSet<Bonsaii.Models.Background> Backgrounds { get; set; }

        public System.Data.Entity.DbSet<Bonsaii.Models.Nation> Nations { get; set; }

        public System.Data.Entity.DbSet<Bonsaii.Models.SkillParameter> SkillParameters { get; set; }
        public System.Data.Entity.DbSet<Bonsaii.Models.StaffSkill> StaffSkills { get; set; }
   


    }
}