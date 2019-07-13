using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D06_MVCBasic.Models
{
    public class HangHoa
    {
        [Display(Name="Mã hàng")]
        public int MaHh { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Số lượng tồn")]
        public int SoLuongTon { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
    }
}
