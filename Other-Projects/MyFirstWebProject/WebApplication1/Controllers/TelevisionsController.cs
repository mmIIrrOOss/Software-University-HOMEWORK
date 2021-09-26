using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TelevisionsController:Controller
    {
        public IActionResult Index()
        {
            var allTvs = TVData.GetAll();
            return View(allTvs);
        }
        public IActionResult Details(int id)
        {
            return View(TVData.TVs.First(tv => tv.Id == id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TV tv)
        {
            TVData.Add(tv);
            return RedirectToAction("index");
        } 
       
        public IActionResult Delete(int id)
        {
            TVData.Delete(id);
            return RedirectToAction("index");
        }
    }
}