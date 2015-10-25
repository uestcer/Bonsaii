namespace Bonsaii.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StaffParam")]
    public partial class StaffParam
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name="����ֵ")]
        public string Value { get; set; }

        [Display(Name="��������")]
        public int StaffParamTypeId { get; set; }
        [Display(Name = "��������")]
        public virtual StaffParamType StaffParamType { get; set; }

        [StringLength(30)]
        public string Extra { get; set; }
    }
}
