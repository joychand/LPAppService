namespace LPAppService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uniplot")]
    public partial class Uniplot
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string LocCd { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string NewDagNo { get; set; }

        [StringLength(30)]
        public string ExNewDag { get; set; }

        [StringLength(30)]
        public string OldDagNo { get; set; }

        public double? Area { get; set; }

        public double? Area_acre { get; set; }

        [StringLength(30)]
        public string OldPattaNo { get; set; }

        [StringLength(30)]
        public string NewPattaNo { get; set; }

        [StringLength(30)]
        public string ExNewPatta { get; set; }

        [StringLength(10)]
        public string KhatianNo { get; set; }

        [StringLength(20)]
        public string CropDesc { get; set; }

        public double? CropArea { get; set; }

        public double? DouCropArea { get; set; }

        [StringLength(20)]
        public string FaOrWaste { get; set; }

        public double? UnCropArea { get; set; }

        [StringLength(20)]
        public string Product { get; set; }

        public double? IrriLand { get; set; }

        [StringLength(20)]
        public string LandClass { get; set; }

        [StringLength(20)]
        public string UnSetDesc { get; set; }

        public double? UnSetArea { get; set; }

        [StringLength(2)]
        public string OpCd { get; set; }

        [StringLength(10)]
        public string EntryDate { get; set; }

        [StringLength(10)]
        public string SlNo { get; set; }

        [StringLength(50)]
        public string OrdNo { get; set; }

        [StringLength(15)]
        public string OrDate { get; set; }

        [StringLength(1)]
        public string RemarkType { get; set; }

        [StringLength(300)]
        public string remark { get; set; }

        public short? sheet { get; set; }

        [StringLength(5)]
        public string unit { get; set; }

        [StringLength(4)]
        public string survey { get; set; }

        [StringLength(10)]
        public string usr { get; set; }

        public decimal? MutNo { get; set; }

        public double? Revenue { get; set; }

        [StringLength(4)]
        public string Year { get; set; }

        public decimal? MutOld { get; set; }

        public byte? VerifiedBy { get; set; }
    }
}
