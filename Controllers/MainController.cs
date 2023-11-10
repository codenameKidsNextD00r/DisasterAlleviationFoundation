using DisasterAlleviationFoundationWebApp.Entity;
using DisasterAlleviationFoundationWebApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace DisasterAlleviationFoundationWebApp.Controllers
{
    public class MainController : Controller
    {
        UserServices userServices = new UserServices();
        CategoryServices categoryServices = new CategoryServices();
        DisasterServices disasterServices = new DisasterServices();
        DonationServices donationServices = new DonationServices();
      

        public IActionResult Index(User user)
        {

            return View(user);
        }


        public IActionResult Login(User user)
        {
            return View("Login");
        }
        public IActionResult SignUp()
        {
            return View();

        }
        public IActionResult ProcessLogin(User user)
        {
            if (userServices.Login(user) != null)
            {
                user = userServices.Login(user);
                return View("Index", user);
            }
            else { return View(); }

        }
        public IActionResult ProcessSignUp(User user)
        {
            userServices.Insert(user);
            return View("Login");

        }
        public IActionResult GoodDonation
            ()
        {
            return View();
        }
        public IActionResult ProcessGoodDonation(GoodsDonation goodsDonation)
        {
            donationServices.Insert(goodsDonation);
            return View("GoodDonation");
        }
        public IActionResult FundsDonation
          ()
        {
            return View();
        }
        public IActionResult ProcessFundsDonation (FundDonation funds)
        {
            if (funds != null)
                donationServices.Insert(funds);
            return View("FundsDonation");
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        public IActionResult AddCategory(Category category)
        {
            if (category != null)
                categoryServices.Insert(category);
            return View("CreateCategory");
        }
        public IActionResult CreateDisasters()
        {
            return View();
        }
        public IActionResult AddDisaster(Disaster disasters)
        {
            if (disasters != null)
                disasterServices.Insert(disasters);
            return View("CreateDisasters");
        }
        public IActionResult ViewGoodsDonations()
        {
            List<GoodsDonation> goodsDonation = donationServices.ReadGood();
            return View(goodsDonation);
        }
        public IActionResult ViewFundsDonations()
        {
            List<FundDonation> funds = donationServices.ReadFund();
            return View(funds);
        }
        public IActionResult ViewDisasters()
        {
            List<Disaster> disasters = disasterServices.Read();
            return View(disasters);
        }
        public IActionResult AllocateDisasterFund(int id)
        {
            Disaster disaster = disasterServices.View(id);
            if (disaster == null)
            {
                return NotFound();
            }
            return View(disaster);
        }
        public IActionResult AllocateDisasterGoods(int id)
        {
            Disaster disaster = disasterServices.View(id);
            if (disaster == null)
            {
                return NotFound();
            }
            return View(disaster);
        }
        public IActionResult AllocateDisaster()
        {
            List<Disaster> disasters = disasterServices.Read();
            return View(disasters);
        }
        public IActionResult AllocateFund(Disaster disaster)
        {
      disasterServices.AllocateFunds(disaster);
            return View();
        }
        public IActionResult AllocateGoods(Disaster disaster)
        {
            disasterServices.AllocateFunds(disaster);
            return View();
        }
    }
}
