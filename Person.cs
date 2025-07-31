using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Person() { }
        public Person(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public virtual void Input()
        {
            Console.WriteLine("Nhap thong tin");
            try
            {
                Console.Write("Nhap ID: ");
                id=int.Parse(Console.ReadLine());
                Console.Write("Nhap ho ten: ");
                name=Console.ReadLine();
                Console.Write("Nhap dia chi: ");
                address=Console.ReadLine();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public virtual void Output()
        {
            Console.Write("{0,-4} {1,-15} {2,-15}", id, name, address);
        }

    }
}
