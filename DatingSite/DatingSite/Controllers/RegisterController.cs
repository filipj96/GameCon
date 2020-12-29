﻿using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using DatingSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingSite.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DatingSiteContext _context;

        public RegisterController(DatingSiteContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var userRepo = new UserRepository(_context);
            var nationalityRepo = new NationalityRepository(_context);
            var personalityRepo = new PersonalityRepository(_context);
            var user = new User();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Mail = User.Identity.Name;
            user.Age = model.Age;
            user.Gender = model.Gender;
            user.PreferedLanguage = model.Language;
            user.NationalityId = nationalityRepo.GetNationalityIdByName(model.Nationality);
            user.PersonalityId = personalityRepo.GetPersonalityIdByName(model.Personality);
            user.Active = true;
            user.Online = true;
            user.ImgUrl = "Default";

            userRepo.AddUser(user);
            return RedirectToAction("Index", "Home");
        }
    }
}