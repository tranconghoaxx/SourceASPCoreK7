using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D07_MVCBasic.Models
{
    /*Tên lớp (class), tên thuộc tính (Property), tên hàm (method): PascalCase
     *Tên tham số (parameter) của hàm: cammelCase
     * Đặt tên cho rõ nghĩa (khỏi cần comment)
     */
    public class HangHoa
    {
        [Display(Name ="Mã")]
        public int MaHh { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }
        public string Hinh { get; set; }
        public int SoLuong { get; set; }
        public double? DonGia { get; set; }
    }
}
