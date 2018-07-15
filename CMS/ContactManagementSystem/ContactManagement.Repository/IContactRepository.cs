using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Repository
{
    interface IContactRepository
    {
        // Methods need to be implemented by Repository class to perform operations on DB entities.

        // Insert
        object InsertData(object contactObj);

        // Update
        object UpdateData(object contactObj);

        // Delete
        bool DeleteData(int contactID);

        // Select by ID
        object GetContactById(int contactID);

        // Select All
        IEnumerable<object> ListContacts();

    }
}
