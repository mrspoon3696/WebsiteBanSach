//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBSITEBANSACH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETSACH
    {
        public CHITIETSACH()
        {
            this.CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }
    
        public int MaCTS { get; set; }
        public Nullable<int> MaSach { get; set; }
        public string TensachCT { get; set; }
        public string Mota { get; set; }
        public string Anhbia { get; set; }
        public Nullable<System.DateTime> Ngaycapnhat { get; set; }
        public Nullable<int> Soluongton { get; set; }
        public Nullable<double> Dongia { get; set; }
        public Nullable<int> MACHUDE { get; set; }
        public Nullable<byte> phantram { get; set; }
        public Nullable<bool> khuyenmai { get; set; }
        public Nullable<int> MANXB { get; set; }
        public Nullable<bool> moi { get; set; }
        public Nullable<bool> banchay { get; set; }
    
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual CHUDE CHUDE { get; set; }
        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
        public virtual SACH SACH { get; set; }
    }
}
