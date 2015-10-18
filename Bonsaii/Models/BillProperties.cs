namespace Bonsaii.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillProperties
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string Type { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        [StringLength(50)]
        public string TypeFullName { get; set; }

        [StringLength(20)]
        public string CodeMethod { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        public int? Year { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public int? SerialNumber { get; set; }

        public bool? IsAutoAudit { get; set; }

        public bool? IsApprove { get; set; }

        public bool? IsLimitInput { get; set; }

        public bool? IsAscOrDesc { get; set; }
    }
}
