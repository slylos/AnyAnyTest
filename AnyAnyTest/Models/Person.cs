using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyAnyTest.Models
{
    class Person
    {
        #region Public Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        #endregion
    }
}
