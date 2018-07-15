using ContactManagement.ClientUI.Models;
using ContentManagement.API;
using ContentManagement.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ContactManagement.ClientUI.Controllers
{
    public class ContactController : Controller
    {
        string url = Global.webClient.BaseAddress.ToString();
        // GET: Contact
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await Global.webClient.GetAsync("ContactAPI");
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("NoData");
            }
            var responseData = response.Content.ReadAsStringAsync().Result;
            var contactData = JsonConvert.DeserializeObject<IEnumerable<ContactUIViewModel>>(responseData);
            
            return View(contactData);
        }

        // GET: Contact/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await Global.webClient.GetAsync("ContactAPI/" + id);
            var responseData = response.Content.ReadAsStringAsync().Result;
            var contactData = JsonConvert.DeserializeObject<ContactUIViewModel>(responseData);
            return View(contactData);
        }

        // GET: Contact/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContactUIViewModel());
        }

        // POST: Contact/Create
        [HttpPost]
        public async Task<ActionResult> Create(ContactUIViewModel model)
        {
            try
            {
                HttpResponseMessage responseMessage = await Global.webClient.PostAsJsonAsync(url,model);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Error");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = Global.webClient.GetAsync("ContactAPI/" + id).Result;
            var responseData = response.Content.ReadAsStringAsync().Result;
            var contactData = JsonConvert.DeserializeObject<ContactUIViewModel>(responseData);
            return View(contactData);
        
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ContactUIViewModel contactModel)
        {
            try
            {
                HttpResponseMessage responseMessage = await Global.webClient.PutAsJsonAsync(url + "/" + id, contactModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Contact/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await Global.webClient.DeleteAsync(url + "/" + id);
            return RedirectToAction("Index");
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NoData()
        {
            return View();
        }
    }
}
