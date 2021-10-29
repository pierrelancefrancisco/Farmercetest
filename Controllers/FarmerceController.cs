using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Farmerce.Data;
using Farmerce.Models;

namespace Farmerce.Controllers
{
    public class FarmerceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FarmerceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Forms.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactForm record)
        {
            var contact = new ContactForm()
            {
                firstName = record.firstName,
                lastName = record.lastName,
                userName = record.userName,
                Email = record.Email,
                mobileNo = record.mobileNo,
                Type = record.Type,
                Message = record.Message
            };

            _context.Forms.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var contact = _context.Forms.Where(i => i.userID == id).SingleOrDefault();
            if(contact == null)
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(int? id, ContactForm record)
        {
            var contact = _context.Forms.Where(i => i.userID == id).SingleOrDefault();
            contact.firstName = record.firstName;
            contact.lastName = record.lastName;
            contact.userName = record.userName;
            contact.Email = record.Email;
            contact.mobileNo = record.mobileNo;
            contact.Type = record.Type;
            contact.Message = record.Message;

            _context.Forms.Update(contact);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var contact = _context.Forms.Where(i => i.userID == id).SingleOrDefault();
            if(contact == null)
            {
                return RedirectToAction("Index");
            }

            _context.Forms.Remove(contact);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
