using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Day09_Validation.Models
{
    public enum Gender
    {
        Nam = 0, Nữ = 1, Khác = -1
    }
    public class Employee
    {
        [Display(Name = "Mã")]
        public int Id { get; set; }
        [Display(Name = "Mã nhân viên")]
        [Remote(action:"CheckEmployeeNo", controller: "Demo", ErrorMessage ="Mã này đã có")]
        public int? EmployeeNo { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "*")]
        [MinLength(3, ErrorMessage = "Tối thiểu 3 kí tự")]
        public string FullName { get; set; }
        [EmailAddress(ErrorMessage = "Chưa đúng định dạng email")]
        public string Email { get; set; }
        [Url(ErrorMessage = "Chưa đúng địa chỉ web")]
        public string Website { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [CheckBirthDate]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }
        [Display(Name = "Lương")]
        public double Salary { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Số tài khoản")]
        [CreditCard]
        public string BankAccountNumber { get; set; }
        [Display(Name = "Nhập lại Số tài khoản")]
        [Compare("BankAccountNumber", ErrorMessage ="Không khớp")]
        public string BankAccountConfirm { get; set; }
        [Display(Name = "Thông tin thêm")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255, ErrorMessage = "Tối đa 255 kí tự")]
        public string Description { get; set; }
    }
}
