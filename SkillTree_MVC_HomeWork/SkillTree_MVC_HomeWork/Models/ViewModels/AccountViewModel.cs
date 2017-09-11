using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkillTree_MVC_HomeWork.Models.ViewModels
{
    public class AccountViewModel
    {
        public string Type { get; set; }

        //[DisplayName("SDFSDFSDFSDF")]
        public int Cost { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }
        public string Memo { get; set; }

        //public List<AccountViewModel> dt { get; set; }
        public enum Types { 收入, 支出 }

        public enum incomeRemark { 薪水, 發票中獎, 彩券中獎 }
        public enum costRemark { 服裝, 飲食, 娛樂, 旅遊 }
    }
}