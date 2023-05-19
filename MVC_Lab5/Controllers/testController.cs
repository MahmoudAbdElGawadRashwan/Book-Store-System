using MVC_Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Lab5.Controllers
{
    public class testController : Controller
    {
        public void MyFun()
        {
            ITIDbContext db = new ITIDbContext();
           
        } 
    }
}
