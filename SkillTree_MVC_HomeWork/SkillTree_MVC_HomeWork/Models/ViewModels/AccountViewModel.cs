using SkillTree_MVC_HomeWork.ValidateAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillTree_MVC_HomeWork.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        public string Type { get; set; }

        //[DisplayName("SDFSDFSDFSDF")]
        [Range(0,99999,ErrorMessage ="需為正整數")]
        public int Cost { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DayRange(-9999, 0)]
        public DateTime Date { get; set; }
        [StringLength(100, MinimumLength = 0, ErrorMessage = "此欄位僅接受100個字")]
        public string Memo { get; set; }

        //public List<AccountViewModel> dt { get; set; }
        public enum Types { 收入, 支出 }

        public enum incomeRemark { 薪水, 發票中獎, 彩券中獎 }
        public enum costRemark { 服裝, 飲食, 娛樂, 旅遊 }
    }
}