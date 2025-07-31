using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> li = new List<Student>();
            string key;
            do
            {
                Console.WriteLine("============= MENU =============");
                Console.WriteLine("1. Nhap thong tin sinh vien");
                Console.WriteLine("2. Hien thi danh sach sinh vien");
                Console.WriteLine("3. Tim kiem sinh vien theo id");
                Console.WriteLine("4. Tim kiem sinh vien theo address ");
                Console.WriteLine("5. Tim kiem sinh vien tai vi tri");
                Console.WriteLine("6. Xoa sinh vien theo id");
                Console.WriteLine("7. Xoa sinh vien theo name");
                Console.WriteLine("8. Xoa sinh vien tai vi tri");
                Console.WriteLine("9. Sap xep sinh vien theo id");
                Console.WriteLine("10. Sap xep sinh vien theo name");
                Console.WriteLine("11. Cap nhat lai ten cho sinh vien tai vi tri");
                Console.WriteLine("12. Chen thong tin sinh vien vao vi tri");
                Console.WriteLine("13. Ket thuc");
                Console.Write("Nhap lua chon cua ban: ");
                key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        //Student s = new Student();
                        //s.Input();
                        //li.Add(s);
                        li.Add(new Student(4, "Van", "Hung Yen", 8, 9));
                        li.Add(new Student(3, "Thu", "Ha Noi", 7, 8));
                        li.Add(new Student(2, "Hung", "Ha Nam", 6, 7));
                        li.Add(new Student(6, "Linh", "Nam Dinh", 8, 9));
                        Console.WriteLine("Da them sinh vien");
                        break;
                    case "2":
                        Console.WriteLine("Danh sach sinh vien");
                        Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                      "ID", "Name", "Address", "Maths", "Physics", "Total");
                        foreach (var stu in li)
                        {
                            stu.Output();
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Nhap id can tim:");
                            int idSearch = int.Parse(Console.ReadLine());
                            var foundByID = li.Find(stu => stu.id == idSearch);
                            if (foundByID != null)
                            {
                                Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                      "ID", "Name", "Address", "Maths", "Physics", "Total");
                                foundByID.Output();
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay sinh vien co id = " + idSearch);
                            }
                        }
                        catch (Exception e)
                        {

                            throw new Exception(e.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Nhap dia chi can tim: ");
                            string addSearch = Console.ReadLine();
                            var foundByAdd = li.FindAll(stu => stu.address.ToLower().Contains(addSearch.ToLower()));
                            if (foundByAdd.Count > 0)
                            {
                                foreach (var item in foundByAdd)
                                {
                                    Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                      "ID", "Name", "Address", "Maths", "Physics", "Total");
                                    item.Output();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay sinh vien co dia chi " + addSearch);
                            }
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }

                        break;
                    case "5":
                        try
                        {
                            Console.Write("Nhập vị trí (index) của sinh viên trong danh sách: ");
                            int pos = int.Parse(Console.ReadLine());
                            int index = pos - 1;

                            if (index < 0 || index >= li.Count)
                            {
                                throw new Exception("=> Không có sinh viên ở vị trí này.");
                            }

                            Console.WriteLine($"=> Sinh viên ở vị trí {pos}:");
                            Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                                  "ID", "Name", "Address", "Maths", "Physics", "Total");
                            li[index].Output();
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("Nhap id can xoa: ");
                            int idDel = int.Parse(Console.ReadLine());
                            var removed = li.RemoveAll(stu => stu.id == idDel);
                            if (removed > 0)
                            {
                                Console.WriteLine("Da xoa thanh cong");
                            }
                            else
                            {
                                Console.WriteLine("Khong ton tai sinh vien co id = " + idDel);
                            }
                        }
                        catch (Exception e)
                        {

                            throw new Exception(e.Message);
                        }
                        break;
                    case "7":
                        try
                        {
                            Console.WriteLine("Nhap ten sinh vien muon xoa: ");
                            string nameDel = Console.ReadLine();
                            var Removed = li.RemoveAll(stu => stu.name.ToLower().Contains(nameDel.ToLower()));
                            if (Removed > 0)
                            {
                                Console.WriteLine($"Da xoa sinh vien co ten {nameDel}");
                            }
                            else
                            {
                                Console.WriteLine($"Khong ton tai sinh vien co ten {nameDel}");
                            }
                        }
                        catch (Exception e)
                        {

                            throw new Exception(e.Message);
                        }
                        break;
                    case "8":
                        try
                        {
                            Console.Write("Nhập vị trí cần xóa (bắt đầu từ 1): ");
                            int pos = int.Parse(Console.ReadLine());
                            int index = pos - 1;
                            if (index < 0 || index >= li.Count)
                            {
                                Console.WriteLine("=> Không có sinh viên ở vị trí này.");
                            }
                            else
                            {
                                Console.WriteLine("=> Đã xóa sinh viên:");
                                li.RemoveAt(index);
                            }
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        break;
                    case "9":
                        Console.WriteLine("DANH SACH SINH VIEN TRUOC KHI SAP XEP");
                        Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                  "ID", "Name", "Address", "Maths", "Physics", "Total");
                        foreach (var stu in li)
                        {
                            stu.Output();
                        }
                        li.Sort((Student a, Student b) => a.id - b.id);
                        Console.WriteLine("DANH SACH SINH VIEN SAU KHI SAP XEP");
                        Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                  "ID", "Name", "Address", "Maths", "Physics", "Total");
                        foreach (var stu in li)
                        {
                            stu.Output();
                        }
                        break;
                    case "10":
                        Console.WriteLine("DANH SACH SINH VIEN TRUOC KHI SAP XEP");
                        Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                  "ID", "Name", "Address", "Maths", "Physics", "Total");
                        foreach (var stu in li)
                        {
                            stu.Output();
                        }
                        li.Sort((Student a, Student b) => a.name.CompareTo(b.name));
                        //li.Sort((Student a, Student b) =>
                        //{
                        //    string lastNameA = a.name.Trim().Split(' ').Last(); 
                        //    string lastNameB = b.name.Trim().Split(' ').Last();
                        //    return lastNameA.CompareTo(lastNameB);
                        //});

                        // li.Sort((Student a, Student b) =>
                        // var std = a.name.CompareTo(b.name);
                        // if(std!=0) return std;
                        Console.WriteLine("DANH SACH SINH VIEN SAU KHI SAP XEP");
                        Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                  "ID", "Name", "Address", "Maths", "Physics", "Total");
                        foreach (var stu in li)
                        {
                            stu.Output();
                        }
                        break;
                    case "11":
                        try
                        {
                            Console.Write("Nhập vị trí (index) của sinh viên cần cập nhật tên (bắt đầu từ 1): ");
                            int pos = int.Parse(Console.ReadLine());
                            int index = pos - 1;

                            if (index < 0 || index >= li.Count)
                            {
                                Console.WriteLine("=> Không có sinh viên ở vị trí này.");
                            }
                            else
                            {
                                Console.Write("Nhập tên mới: ");
                                string newName = Console.ReadLine();
                                li[index].name = newName;

                                Console.WriteLine("=> Đã cập nhật tên sinh viên:");
                                Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                                      "ID", "Name", "Address", "Maths", "Physics", "Total");
                                li[index].Output();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Lỗi: " + e.Message);
                        }
                        break;
                    case "12":
                        try
                        {
                            Console.Write("Nhập vị trí (index) muốn chèn sinh viên mới (bắt đầu từ 1): ");
                            int pos = int.Parse(Console.ReadLine());
                            int index = pos - 1;

                            if (index < 0 || index > li.Count)
                            {
                                Console.WriteLine("=> Vị trí không hợp lệ.");
                            }
                            else
                            {
                                Console.WriteLine("=> Nhập thông tin sinh viên cần chèn:");
                                Student newStudent = new Student();
                                newStudent.Input();

                                li.Insert(index, newStudent);

                                Console.WriteLine("=> Đã chèn sinh viên vào vị trí " + pos);
                                Console.WriteLine("Danh sách sau khi chèn:");
                                Console.WriteLine("{0,-4} {1,-15} {2,-15} {3,-10} {4,-10} {5,-10}",
                                    "ID", "Name", "Address", "Maths", "Physics", "Total");
                                foreach (var stu in li)
                                {
                                    stu.Output();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Lỗi: " + e.Message);
                        }
                        break;

                    case "13":
                        Console.WriteLine("Ket thuc chuong trinh");
                        break;
                    default:
                        Console.WriteLine("Nhap sai yeu cau nhap lai: ");
                        break;
                }
            } while (key != "13");
            Console.ReadKey();

        }
    }
}
