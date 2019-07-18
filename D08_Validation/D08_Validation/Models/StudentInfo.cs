using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D08_Validation.Models
{
    public class StudentInfo
    {
        [Display(Name ="Mã sinh viên")]
        public int StudentId { get; set; }
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="*")]
        [MaxLength(50, ErrorMessage ="Tối đa 50 kí tự")]
        public string FullName { get; set; }
        [Display(Name ="Điểm")]
        [Range(0, 10, ErrorMessage ="Từ 0 --> 10")]
        public float Mark { get; set; }
        [Display(Name = "Đậu")]
        public bool IsPass => Mark >= 5.5;
        [Display(Name ="Xếp loại")]
        public string Rank
        {
            get
            {
                string result = string.Empty;
                if (Mark < 5.5)  result = "Yếu";
                else if (Mark < 7.8) result = "Trung bình";
                else if (Mark < 8.5) result = "Khá";
                else if (Mark < 9) result = "Giỏi";
                else result = "Xuất sắc";

                return result;
            }
        }
    }
}
