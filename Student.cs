using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Student:Person
    {
        public byte maths { get; set; }
        public byte physics { get; set; }
        public Student() { }
        public Student(int id, string name, string address, byte maths, byte physics) : base(id, name, address)
        {
            this.maths = maths;
            this.physics = physics;
        }

        public override void Input()
        {
            try
            {
                base.Input();
                Console.Write("Nhap diem toan: ");
                maths=byte.Parse(Console.ReadLine());
                Console.Write("Nhap diem ly: ");
                physics=byte.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public override void Output()
        {
            base.Output();
            Console.WriteLine(" {0,-10} {1,-10} {2,-10}", maths, physics, Total());
        }

        public int Total()
        {
            return maths + physics;
        }

        //public override bool Equals(object obj)
        //{
        //    Employee e = (Employee)obj;
        //    return (this.id.Equals(e.id));
        //}

        //    public int CompareTo(object obj)
        //    {
        //        Employee e = (Employee)obj;
        //        //return (this.id.CompareTo(e.id));
        //        // tang dan
        //        //return (this.salary.CompareTo(e.salary));
        //        //giam dan
        //        return (e.salary.CompareTo(this.salary));

        //    }
        //}
        //class SortByAddress : IComparer<Employee>
        //{
        //    public int Compare(Employee x, Employee y)
        //    {
        //        return (x.address.CompareTo(y.address));
        //    }
        //}
        //class SortByID : IComparer<Employee>
        //{
        //    public int Compare(Employee x, Employee y)
        //    {
        //        return (x.id.CompareTo(y.id));
        //    }
        //}
        // li.Sort(new SortByID());
        //Console.WriteLine("Check equals: " + e.Equals(e2));
    }
}
