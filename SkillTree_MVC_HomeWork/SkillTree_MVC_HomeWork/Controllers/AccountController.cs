using SkillTree_MVC_HomeWork.Models.ViewModels;
using static SkillTree_MVC_HomeWork.Models.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SkillTree_MVC_HomeWork.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            Random rand = new Random();
            var source = new AccountViewModel
            {
                // Type = "類別",
                //Type = Enum.GetName(typeof(Types), rand.Next(2)),
                Cost = 100,
                Date = DateTime.Now,
                Memo = "TEST"

            };
            int typeFlag = 0;
            DateTime dTime = DateTime.Today;

            var lst = new List<AccountViewModel>();

            for (int i = 0; i < 1000; i++)
            {
                typeFlag = rand.Next(2);

                var temp = new AccountViewModel
                {
                    Type = Enum.GetName(typeof(AccountViewModel.Types), typeFlag),
                    Cost = rand.Next(500),
                    Date = dTime.AddDays(rand.Next(-60,0)),
                    Memo = typeFlag==0? Enum.GetName(typeof(AccountViewModel.incomeRemark), rand.Next(3)) : Enum.GetName(typeof(AccountViewModel.costRemark), rand.Next(4))
                };
                lst.Add(temp);
            }

            //source.dt.Add();

            ViewData["lstAccount"] = lst;

            return View();
        }
    }
}