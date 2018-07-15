using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManagement.Repository.EntityDataModel;
using ContentManagement.API.Models;
using ContactManagement.Repository;

namespace ContentManagement.API.Controllers
{
    public class ContactAPIController : ApiController
    {
        ContactRepository CR = new ContactRepository();
        // GET: api/ContactAPI
        public IEnumerable<ContactAPIViewModel> Get()
        {
            List<ContactAPIViewModel> DisplayContactList = new List<ContactAPIViewModel>();
            List<T_CONTACTS> ContactEntity = (List<T_CONTACTS>)CR.ListContacts();
            foreach (var item in ContactEntity)
            {
                DisplayContactList.Add(
                    new ContactAPIViewModel()
                    {
                        ContactId = item.contact_id,
                        FirstName = item.first_name,
                        LastName = item.last_name,
                        Email = item.email,
                        Phone = item.phone,
                        Status = item.status.ToUpper()
                    }
                    );
            }

            return DisplayContactList;
        }

        // GET: api/ContactAPI/5
        public ContactAPIViewModel Get(int id)
        {
            ContactAPIViewModel DisplayContact = new ContactAPIViewModel();
            T_CONTACTS Contact = (T_CONTACTS)CR.GetContactById(id);

            DisplayContact.ContactId = Contact.contact_id;
            DisplayContact.FirstName = Contact.first_name;
            DisplayContact.LastName = Contact.last_name;
            DisplayContact.Email = Contact.email;
            DisplayContact.Phone = Contact.phone;
            DisplayContact.Status = Contact.status;

            return DisplayContact;
        }

        // POST: api/ContactAPI
        public void Post([FromBody]ContactAPIViewModel model)
        {
            if (model!=null)
            {
                T_CONTACTS DbContactModel = new T_CONTACTS();

                DbContactModel.first_name = model.FirstName;
                DbContactModel.last_name = model.LastName;
                DbContactModel.email = model.Email;
                DbContactModel.phone = model.Phone;
                DbContactModel.status = model.Status.ToUpper();

                CR.InsertData(DbContactModel);
            }
        }

        // PUT: api/ContactAPI/5
        public void Put(int id, [FromBody]ContactAPIViewModel model)
        {
            if (model!=null)
            {
                T_CONTACTS DbContactModel = new T_CONTACTS();

                DbContactModel.contact_id = id;
                DbContactModel.first_name = model.FirstName;
                DbContactModel.last_name = model.LastName;
                DbContactModel.email = model.Email;
                DbContactModel.phone = model.Phone;
                DbContactModel.status = model.Status.ToUpper();

                CR.UpdateData(DbContactModel);
            }
        }

        // DELETE: api/ContactAPI/5
        public void Delete(int id)
        {
            CR.DeleteData(id);

        }
    }
}
