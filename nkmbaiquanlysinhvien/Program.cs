using System;
using System.Collections.Generic;
using System.Linq;

namespace nkmbaiquanlysinhvien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;

            List<student> students = new List<student>()
            {
                new student
                {
                    masinhvien = "SV001",
                    hoten = "Nguyen Van A",
                    ngaysinh = new DateTime(2005, 5, 10),
                    gioitinh = true,
                    email = "nguyenvana@gmail.com",
                    sodienthoai = "0123456789",
                    nganhhoc = "CNTT",
                    dtb = 8.5f,
                    trangthai = true
                },

                new student
                {
                    masinhvien = "SV002",
                    hoten = "Tran Thi B",
                    ngaysinh = new DateTime(2005, 8, 20),
                    gioitinh = false,
                    email = "tranthib@gmail.com",
                    sodienthoai = "0987654321",
                    nganhhoc = "Kinh te",
                    dtb = 7.8f,
                    trangthai = true
                },

                new student
                {
                    masinhvien = "SV003",
                    hoten = "Le Van C",
                    ngaysinh = new DateTime(2004, 3, 15),
                    gioitinh = true,
                    email = "levanc@gmail.com",
                    sodienthoai = "0912345678",
                    nganhhoc = "CNTT",
                    dtb = 9.2f,
                    trangthai = true
                }
            };

            do
            {
                Console.Clear();

                menu();
                Console.Write("Nhap lua chon cua ban: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        themsinhvien(students);
                        break;

                    case "2":
                        hienthithongtin(students);
                        break;

                    case "3":
                        timkiemtheoma(students);
                        break;

                    case "4":
                        timkiemtheoten(students);
                        break;

                    case "5":
                        capnhatsinhvien(students);
                        break;

                    case "6":
                        xoasinhvien(students);
                        break;

                    case "7":
                        sapxeptheoten(students);
                        break;

                    case "8":
                        sapxeptheodiem(students);
                        break;

                    case "9":
                        sinhviendiemtroilen(students);
                        break;

                    case "10":
                        sinhviendiemcaonhat(students);
                        break;

                    case "11":
                        tinhdtb(students);
                        break;

                    case "12":
                        thongketheonganh(students);
                        break;

                    case "13":
                        thongketheotrangthai(students);
                        break;

                    case "0":
                        Console.WriteLine("Thoat chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                if (choice != "0")
                {
                    Console.WriteLine("\nNhan Enter de tiep tuc...");
                    Console.ReadLine();
                }

            } while (choice != "0");
        }
        static void menu()
        {
            Console.WriteLine("---QUAN LY SINH VIEN BANG OOP---");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim gan dung theo ho ten");
            Console.WriteLine("5. Cap nhat sinh vien");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo ho ten");
            Console.WriteLine("8. Sap xep theo diem trung binh");
            Console.WriteLine("9. Hien thi sinh vien co diem tu 8 tro len");
            Console.WriteLine("10. Hien thi sinh vien co diem cao nhat");
            Console.WriteLine("11. Tinh diem trung binh toan bo sinh vien");
            Console.WriteLine("12. Thong ke sinh vien theo nganh");
            Console.WriteLine("13. Thong ke sinh vien theo trang thai");
            Console.WriteLine("0. Thoat");
        }

        static void themsinhvien(List<student> students)
        {
            Console.WriteLine("\n--- THEM SINH VIEN ---");

            Console.Write("Ma sinh vien: ");
            string masinhvien = Console.ReadLine();
            if (students.Any(x => x.masinhvien == masinhvien))
            {
                Console.WriteLine("Ma sinh vien da ton tai!");
                return;
            }
            Console.Write("Ho ten: ");
            string hoten = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(hoten))
            {
                Console.WriteLine("Ho ten khong duoc rong!");
                return;
            }
            Console.Write("Ngay sinh (dd/MM/yyyy): ");
            DateTime? ngaysinh;

            DateTime tempDate;

            if (DateTime.TryParse(Console.ReadLine(), out tempDate))
            {
                ngaysinh = tempDate;
            }
            else
            {
                Console.WriteLine("Ngay sinh khong hop le!");
                return;
            }

            Console.Write("Gioi tinh (1.Nam / 0.Nu): ");
            bool gioitinh = Console.ReadLine() == "1";

            Console.Write("Email: ");
            string email = Console.ReadLine();

            if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Email khong dung dinh dang!");
                return;
            }

            Console.Write("So dien thoai: ");
            string sodienthoai = Console.ReadLine();

            Console.Write("Nganh hoc: ");
            string nganhhoc = Console.ReadLine();

            Console.Write("Diem trung binh: ");

            float dtb;

            if (!float.TryParse(Console.ReadLine(), out dtb))
            {
                Console.WriteLine("Diem khong hop le!");
                return;
            }

            if (dtb < 0 || dtb > 10)
            {
                Console.WriteLine("Diem phai nam trong khoang 0 den 10!");
                return;
            }

            Console.Write("Trang thai (1.Dang hoc / 0.Da nghi): ");
            bool trangthai = Console.ReadLine() == "1";

            students.Add(new student
            {
                masinhvien = masinhvien,
                hoten = hoten,
                ngaysinh = ngaysinh,
                gioitinh = gioitinh,
                email = email,
                sodienthoai = sodienthoai,
                nganhhoc = nganhhoc,
                dtb = dtb,
                trangthai = trangthai
            });

            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void hienthithongtin(List<student> students)
        {
            Console.WriteLine("\n--- DANH SACH SINH VIEN ---");

            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            foreach (var s in students)
            {
                string gioitinh = s.gioitinh ? "Nam" : "Nu";

                string trangthai = s.trangthai
                    ? "Dang hoc"
                    : "Da nghi";

                Console.WriteLine(
                    $"Ma: {s.masinhvien} | " +
                    $"Ten: {s.hoten} | " +
                    $"Ngay sinh: {s.ngaysinh:dd/MM/yyyy} | " +
                    $"Gioi tinh: {gioitinh} | " +
                    $"Email: {s.email} | " +
                    $"SDT: {s.sodienthoai} | " +
                    $"Nganh: {s.nganhhoc} | " +
                    $"Diem: {s.dtb} | " +
                    $"Trang thai: {trangthai}"
                );
            }
        }

        static void timkiemtheoma(List<student> students)
        {
            Console.WriteLine("\n--- TIM KIEM THEO MA ---");

            Console.Write("Nhap ma sinh vien: ");
            string ma = Console.ReadLine();

            var sv = students.FirstOrDefault(
                x => x.masinhvien == ma);

            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            Console.WriteLine("Tim thay sinh vien:");

            List<student> ketqua = new List<student>();
            ketqua.Add(sv);

            hienthithongtin(ketqua);
        }

        static void timkiemtheoten(List<student> students)
        {
            Console.WriteLine("\n--- TIM KIEM GAN DUNG THEO TEN ---");

            Console.Write("Nhap ten can tim: ");
            string ten = Console.ReadLine();

            var ketqua = students
                .Where(x => x.hoten
                .ToLower()
                .Contains(ten.ToLower()))
                .ToList();

            if (ketqua.Count == 0)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            hienthithongtin(ketqua);
        }

        static void capnhatsinhvien(List<student> students)
        {
            Console.WriteLine("\n--- CAP NHAT SINH VIEN ---");

            Console.Write("Nhap ma sinh vien can cap nhat: ");
            string ma = Console.ReadLine();

            var sv = students.FirstOrDefault(
                x => x.masinhvien == ma);

            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            Console.Write("Ho ten moi: ");
            string hoten = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(hoten))
            {
                Console.WriteLine("Ho ten khong duoc rong!");
                return;
            }

            Console.Write("Ngay sinh moi (dd/MM/yyyy): ");

            DateTime ngaySinh;

            if (!DateTime.TryParse(
                Console.ReadLine(),
                out ngaySinh))
            {
                Console.WriteLine("Ngay sinh khong hop le!");
                return;
            }

            Console.Write("Gioi tinh moi (1.Nam / 0.Nu): ");
            sv.gioitinh = Console.ReadLine() == "1";

            Console.Write("Email moi: ");
            string email = Console.ReadLine();

            if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Email khong dung dinh dang!");
                return;
            }

            Console.Write("So dien thoai moi: ");
            string sodienthoai = Console.ReadLine();

            Console.Write("Nganh hoc moi: ");
            string nganhhoc = Console.ReadLine();

            Console.Write("Diem trung binh moi: ");

            float dtb;

            if (!float.TryParse(
                Console.ReadLine(),
                out dtb))
            {
                Console.WriteLine("Diem khong hop le!");
                return;
            }

            if (dtb < 0 || dtb > 10)
            {
                Console.WriteLine(
                    "Diem phai tu 0 den 10!");
                return;
            }

            Console.Write("Trang thai moi (1.Dang hoc / 0.Da nghi): ");
            bool trangthai = Console.ReadLine() == "1";

            sv.hoten = hoten;
            sv.ngaysinh = ngaySinh;
            sv.email = email;
            sv.sodienthoai = sodienthoai;
            sv.nganhhoc = nganhhoc;
            sv.dtb = dtb;
            sv.trangthai = trangthai;

            Console.WriteLine("Cap nhat thanh cong!");
        }

        static void xoasinhvien(List<student> students)
        {
            Console.WriteLine("\n--- XOA SINH VIEN ---");

            Console.Write("Nhap ma sinh vien can xoa: ");
            string ma = Console.ReadLine();

            var sv = students.FirstOrDefault(
                x => x.masinhvien == ma);

            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            students.Remove(sv);

            Console.WriteLine("Xoa sinh vien thanh cong!");
        }
        static void sapxeptheoten(List<student> students)
        {
            Console.WriteLine("\n--- SAP XEP THEO HO TEN ---");

            var ketqua = students
                .OrderBy(x => x.hoten)
                .ToList();

            hienthithongtin(ketqua);
        }

        static void sapxeptheodiem(List<student> students)
        {
            Console.WriteLine("\n--- SAP XEP THEO DIEM ---");

            var ketqua = students
                .OrderByDescending(x => x.dtb)
                .ToList();

            hienthithongtin(ketqua);
        }

        static void sinhviendiemtroilen(List<student> students)
        {
            Console.WriteLine(
                "\n--- SINH VIEN CO DIEM TU 8 TRO LEN ---");

            var ketqua = students
                .Where(x => x.dtb >= 8)
                .ToList();

            if (ketqua.Count == 0)
            {
                Console.WriteLine(
                    "Khong co sinh vien nao!");
                return;
            }

            hienthithongtin(ketqua);
        }

        static void sinhviendiemcaonhat(
            List<student> students)
        {
            Console.WriteLine(
                "\n--- SINH VIEN CO DIEM CAO NHAT ---");

            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            float diemcao = students.Max(
                x => x.dtb);

            var ketqua = students
                .Where(x => x.dtb == diemcao)
                .ToList();

            Console.WriteLine(
                "Diem cao nhat: " + diemcao);

            hienthithongtin(ketqua);
        }
        static void tinhdtb(List<student> students)
        {
            Console.WriteLine(
                "\n--- DIEM TRUNG BINH TOAN BO SINH VIEN ---");

            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            double diem = students
                .Average(x => x.dtb);

            Console.WriteLine(
                "Diem trung binh: " + diem);
        }
        static void thongketheonganh(
            List<student> students)
        {
            Console.WriteLine(
                "\n--- THONG KE THEO NGANH HOC ---");

            var ketqua = students
                .GroupBy(x => x.nganhhoc)
                .Select(x => new
                {
                    Nganh = x.Key,
                    SoLuong = x.Count()
                });

            foreach (var item in ketqua)
            {
                Console.WriteLine(
                    "Nganh: " + item.Nganh +
                    " | So luong: " + item.SoLuong);
            }
        }

        static void thongketheotrangthai(
            List<student> students)
        {
            Console.WriteLine(
                "\n--- THONG KE THEO TRANG THAI ---");

            int danghoc = students
                .Count(x => x.trangthai == true);

            int danghi = students
                .Count(x => x.trangthai == false);

            Console.WriteLine(
                "Dang hoc: " + danghoc + " sinh vien");

            Console.WriteLine(
                "Da nghi: " + danghi + " sinh vien");
        }
    }
}