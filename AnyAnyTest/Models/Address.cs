using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyAnyTest.Models
{
    class Address
    {
        #region Ctor

        public Address()
        {
            this.People = new List<Person>();
        }

        #endregion

        #region Public Properties

        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public List<Person> People { get; set; }

        #endregion
    }
}
