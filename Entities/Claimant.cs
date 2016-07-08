namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Claimant")]
    public partial class Claimant
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TSNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TSYear { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short SlNo { get; set; }

        [StringLength(30)]
        public string ClaimSurName { get; set; }

        [StringLength(50)]
        public string ClaimMiddleName { get; set; }

        [StringLength(50)]
        public string ClaimLastName { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Aadhaar { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        public short? Occupation { get; set; }

        [StringLength(50)]
        public string FatherSurName { get; set; }

        [StringLength(50)]
        public string FatherMiddleName { get; set; }

        [StringLength(50)]
        public string FatherLastName { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(50)]
        public string SubDivision { get; set; }

        [StringLength(50)]
        public string Circle { get; set; }

        [StringLength(50)]
        public string Village { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string PostOffice { get; set; }

        public int? PinCode { get; set; }

        [StringLength(50)]
        public string PoliceSt { get; set; }

        [StringLength(15)]
        public string EnterBy { get; set; }
    }
}
