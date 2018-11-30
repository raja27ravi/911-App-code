
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmsApplication.Controllers
{
    public class EMSController : Controller
    {
        //
        // GET: /EMS/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult EmployeeCalculator()
        {
            return View();
        }


        public ActionResult ByCity()
        {
            return View();
        }

        public ActionResult Maps()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult CategoryCount()
        {
            return View();
        }
        public ActionResult HourWise()
        {
            return View();
        }
        public ActionResult MonthVsCategory()
        {
            return View();
        }
        public ActionResult MonthDayCategory()
        {
            return View();
        }
        public ActionResult TitleMonthCategory()
        {
            return View();
        }


        //public string GetZipCode(string city)
        //{
        //    if (city != null)
        //    {
        //        ZipcodeContext zipcon = new ZipcodeContext();
        //        Zipcode zipdata = zipcon.Zipcode.Single(x => x.city == city);
        //        if (zipdata.zipcode != null) {
        //            return zipdata.zipcode;
        //        }
        //        return "19004";//Bala Cynwyd

        //    }
        //    return "City data Not available!!!";
        //}

        public string GetUri(int type)
        {
            if (type == 0)
            {
                return "ByCity";

            }
            else if (type == 1)
            {
                return "Maps";

            }
            else if (type == 2)
            {
                return "Category";

            }
            else if (type == 3)
            {
                return "CategoryCount";

            }
            else if (type == 4)
            {
                return "HourWise";

            }
            else if (type == 5)
            {
                return "MonthVsCategory";

            }
            else if (type == 6)
            {
                return "MonthDayCategory";

            }
            else if (type == 7)
            {
                return "TitleMonthCategory";

            }
            else {
                return "Not Found";
            }
           
        }

    }
}
