using AnyAnyTest.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnyAnyTest
{
    class Program
    {
        #region Private Fields

        private static string[] _postalCodes    = { "30326", "34953", "11206" };
        private static string[] _states         = { "New York", "Florida", "Georgia", "New Hampshire" };
        private static string[] _cities         = { "Atlanta", "Manhattan", "Miami" };
        private static string[] _firstNames     = { "Carlos", "Brent", "Wes", "Todd", "Yemane", "Steve", "Johnny" };

        #endregion

        static void Main(string[] args)
        {
            List<Address> addresses = new List<Address>();
            Random r = new Random();

            Console.WriteLine("Creating people");

            for (int i = 0; i < 10000; i++)
            {
                addresses.Add(new Address()
                {
                    City = _cities[r.Next(0, 2)],
                    State = _states[r.Next(0, 3)],
                    Street = "123 Anywhere Street",
                    PostalCode = _postalCodes[r.Next(0, 2)],
                });
            }

            List<Person> people = new List<Person>();

            for (int i = 0; i < 1000000; i++)
            {
                var address = addresses[r.Next(0, addresses.Count - 1)];

                Person p = new Person()
                {
                    FirstName = i.ToString(),
                    LastName = "Muentes",
                    Phone = "212-975-4027",
                    Address = address
                };

                address.People.Add(p);
                people.Add(p);
            }
            Console.WriteLine(string.Format("Done creating people.  Total count: {0}", people.Count));
            Console.WriteLine("Getting run averages, please hold ...");

            Console.WriteLine("Getting results for 1 million");

            ThreadPool.QueueUserWorkItem(x =>
            {
                Console.WriteLine("Thread 1 started");

                var person = r.Next(0, people.Count - 1);
                for (int i = 0; i <= 5000; i++)
                {
                    FindPerson(people, person.ToString());
                }

                Console.WriteLine("Thread 1 complete");
            });

            ThreadPool.QueueUserWorkItem(x =>
            {
                Console.WriteLine("Thread 2 started");

                for (int i = 0; i <= 5000; i++)
                {
                    var person = r.Next(0, people.Count - 1);
                    FindPerson(people, person.ToString());
                }

                Console.WriteLine("Thread 2 complete");
            });

            ThreadPool.QueueUserWorkItem(x =>
            {
                Console.WriteLine("Thread 3 started");

                for (int i = 0; i <= 5000; i++)
                {
                    var person = r.Next(0, people.Count - 1);
                    FindPerson(people, person.ToString());
                }

                Console.WriteLine("Thread 3 complete");
            });

            Console.Read();
        }

        private static bool FindPerson(List<Person> people, string personNumber)
        {
            var person = people.Any(p => p.Address.People.Any(pr => pr.FirstName == personNumber));
            return person;
        }
    }
}