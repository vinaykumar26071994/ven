using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Vendor
{
    class Program
    {
        static List<Vendor> vendor = new List<Vendor>();
        static void Main()
        {
        TOP:
            Console.WriteLine("==============");
            Console.WriteLine("Vendor details");
            Console.WriteLine("==============");
            Console.WriteLine("1.AddDetails");
            Console.WriteLine("2.GetDetails");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Enter your option: ");
            string option = Console.ReadLine();
            if (option == "1")
            {
                AddDetails();
            }
            else if (option == "2")
            {
                
                List<Vendor>vendor1 = GetDetails();
                foreach (Vendor i in vendor1)
                {
                    Console.WriteLine("Id is : " + i.Id);
                    Console.WriteLine("First Name : " + i.FirstName);
                    Console.WriteLine("Last Name : " + i.LastName);
                    Console.WriteLine("Company Name : " + i.Company);
                    Console.WriteLine("Phone Number : " + i.PhoneNumber);
                    Console.WriteLine("City : " + i.City);
                    Console.WriteLine("Country : " + i.Country);
                    Console.WriteLine("DetailsAddedBy : " + i.AddedBy);
                    Console.WriteLine("DetailsAddedOn : " + i.AddedOn);
                    Console.WriteLine("Use : " + i.IsInUse);
                    Console.ReadLine();
                }
            }
            else if (option == "3")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Enter valid option");
            }
            goto TOP;
        }

        static void AddDetails()

            {
                Vendor v1 = new Vendor();

                Guid guid = Guid.NewGuid();
                string guid1 = guid.ToString();
                v1.Id = guid1;
                Console.WriteLine(guid1);
                Console.WriteLine("Enter First Name: ");
                v1.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                v1.LastName = Console.ReadLine();
                Console.WriteLine("Enter Company Name: ");
                v1.Company = Console.ReadLine();
                Console.WriteLine("Enter Phone Number: ");
                v1.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Enter City: ");
                v1.City = Console.ReadLine();
                Console.WriteLine("Enter Country Name: ");
                v1.Country = Console.ReadLine();
                Console.WriteLine("Enter AddedBy Name: ");
                v1.AddedBy = Console.ReadLine();
                DateTime dt = DateTime.Today;
                v1.AddedOn = dt;
                Console.WriteLine(dt);
                Console.WriteLine("data saved in Json");

                //Console.WriteLine("Enter IsInUse: ");
                //v1.IsInUse = Convert.ToBoolean(Console.ReadLine());

                vendor.Add(v1);

                //string str1 = File.ReadAllText("vendor.Json");
                //List<Vendor> list = JsonConvert.DeserializeObject<List<Vendor>>(str1);
                //list.Add(v1);

                string str = JsonConvert.SerializeObject(vendor);
                StreamWriter sw = new StreamWriter("vendor.Json");
                sw.WriteLine(str);
                sw.Close();
                Console.ReadLine();
        }

        static List<Vendor> GetDetails()
        {
            string vendorData = File.ReadAllText("vendor.Json");
            List<Vendor> tir = JsonConvert.DeserializeObject<List<Vendor>>(vendorData);
            return tir;
        }
    }
    public class Vendor
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsInUse { get; set; }
    }

}
