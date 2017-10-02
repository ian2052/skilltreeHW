using SkillTree_MVC_HomeWork.Models.ViewModels;
using static SkillTree_MVC_HomeWork.Models.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using SkillTree_MVC_HomeWork.Models;

namespace SkillTree_MVC_HomeWork.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            var lst =new List<AccountViewModel>() ;

            using (Models.SkillTreeHomeworkEntities db = new Models.SkillTreeHomeworkEntities())
            {

                foreach (var item in db.AccountBook.ToList())
                {
                    var temp = new AccountViewModel
                    {
                        Type = Enum.GetName(typeof(AccountViewModel.Types), item.Categoryyy),
                        Cost = item.Amounttt,
                        Date = item.Dateee,
                        Memo = item.Remarkkk
                    };
                    lst.Add(temp);
                }


            }


            //Random rand = new Random();
            //var source = new AccountViewModel
            //{
            //    // Type = "類別",
            //    //Type = Enum.GetName(typeof(Types), rand.Next(2)),
            //    Cost = 100,
            //    Date = DateTime.Now,
            //    Memo = "TEST"

            //};
            //int typeFlag = 0;
            //DateTime dTime = DateTime.Today;

            //var lst = new List<AccountViewModel>();

            //for (int i = 0; i < 1000; i++)
            //{
            //    typeFlag = rand.Next(2);

            //    var temp = new AccountViewModel
            //    {
            //        Type = Enum.GetName(typeof(AccountViewModel.Types), typeFlag),
            //        Cost = rand.Next(500),
            //        Date = dTime.AddDays(rand.Next(-60,0)),
            //        Memo = typeFlag==0? Enum.GetName(typeof(AccountViewModel.incomeRemark), rand.Next(3)) : Enum.GetName(typeof(AccountViewModel.costRemark), rand.Next(4))
            //    };
            //    lst.Add(temp);
            //}

            ////source.dt.Add();

            ViewData["lstAccount"] = lst;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Type,Cost,Date,Memo")] AccountViewModel accountViewModel)
        {
            //AccountViewModel accountViewModel = ViewData["Account"] as SkillTree_MVC_HomeWork.Models.ViewModels.AccountViewModel;
            Models.SkillTreeHomeworkEntities db = new Models.SkillTreeHomeworkEntities();
            Models.AccountBook accountBook = new AccountBook();
            accountBook.Id = Guid.NewGuid();
            accountBook.Categoryyy = accountViewModel.Type=="支出"?1:0;
            accountBook.Amounttt = accountViewModel.Cost;
            accountBook.Dateee = accountViewModel.Date;
            accountBook.Remarkkk = accountViewModel.Memo;
            if (ModelState.IsValid)
            {
                db.AccountBook.Add(accountBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountViewModel);
        }
    }
}