using ContactManagement.Repository.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Repository
{
    public class ContactRepository : IContactRepository
    {
        DB_CONTACTSEntities dbContext = new DB_CONTACTSEntities();
        public bool DeleteData(int contactID)
        {
            T_CONTACTS contacts = dbContext.T_CONTACTS.Find(contactID);
            if (contacts != null)
            {
                dbContext.T_CONTACTS.Remove(contacts);
                try
                {
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public object GetContactById(int contactID)
        {
            return dbContext.T_CONTACTS.Find(contactID);
        }

        public object InsertData(object contactObj)
        {
            using (dbContext)
            {
                if (contactObj !=null)
                {
                    // Unboxing as incoming data is object type making it to specific type.
                    T_CONTACTS t_contacts = (T_CONTACTS)contactObj;
                    dbContext.T_CONTACTS.Add(t_contacts);

                    try
                    {
                        dbContext.SaveChanges();
                        return contactObj;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return contactObj;
                    }
                }
                else
                {
                    Console.WriteLine("Null Not Allowed");
                    return contactObj;
                }
            }
            
        }

        public IEnumerable<object> ListContacts()
        {
            return dbContext.T_CONTACTS.ToList();
        }

        public object UpdateData(object contactObj)
        {
            using (dbContext)
            {
                // Unboxing as incoming data is object type making it to specific type.
                T_CONTACTS contacts = (T_CONTACTS)contactObj;
                T_CONTACTS existingContact = dbContext.T_CONTACTS.Find(contacts.contact_id);
                if (existingContact != null)
                {
                        existingContact.first_name = contacts.first_name;
                        existingContact.last_name = contacts.last_name;
                        existingContact.email = contacts.email;
                        existingContact.phone = contacts.phone;
                        existingContact.status = contacts.status;

                    try
                    {
                        dbContext.SaveChanges();
                        return contactObj;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return contactObj;
                    }
                }
                else
                {
                    Console.WriteLine("Null Not Allowed");
                    return contactObj;
                }
            }
        }
    }
}
