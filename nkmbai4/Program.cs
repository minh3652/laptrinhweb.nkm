using System;
using System.Collections.Generic;
using System.Linq;

namespace nkmbai4
{
    internal class Program
    {
        static List<qlkhoahoc > danhSachKhoaHoc = new List<qlkhoahoc >();

        static void Main(string[] args)
        {
            while (true)
            {
                khoahoc();
                Console.Write("Nhap lua chon: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ThemKhoaHoc();
                        break;
                    case "2":
                        SuaKhoaHoc();
                        break;
                    case "3":
                        XoaKhoaHoc();
                        break;
                    case "4":
                        TimKiemKhoaHoc();
                        break;
                    case "5":
                        SapXepKhoaHoc();
                        break;
                    case "6":
                        LocTrangThai();
                        break;
                    case "7":
                        ThongKeHocPhi();
                        break;
                    case "8":
                        Console.WriteLine("Thoat chuong trinh.");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
                Console.WriteLine("\nNhan Enter de tiep tuc...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void khoahoc()
        {
            Console.WriteLine("--- CHUC NANG QUAN LY KHOA HOC ---");

            Console.WriteLine("1. Them khoa hoc");
            Console.WriteLine("2. Sua khoa hoc");
            Console.WriteLine("3. Xoa khoa hoc");
            Console.WriteLine("4. Tim kiem khoa hoc");
            Console.WriteLine("5. Sap xep theo hoc phi");
            Console.WriteLine("6. Loc theo trang thai");
            Console.WriteLine("7. Thong ke hoc phi");
            Console.WriteLine("8. Thoat chuong trinh");
        }

        static void ThemKhoaHoc()
        {
            Console.WriteLine("\n--- THEM KHOA HOC ---");

            qlkhoahoc  khoaHoc = new qlkhoahoc ();

            Console.Write("Ma khoa hoc: ");
            khoaHoc.MaKhoaHoc = Console.ReadLine();

            if (danhSachKhoaHoc.Any(x => x.MaKhoaHoc == khoaHoc.MaKhoaHoc))
            {
                Console.WriteLine("Ma khoa hoc da ton tai!");
                return;
            }

            Console.Write("Ten khoa hoc: ");
            khoaHoc.TenKhoaHoc = Console.ReadLine();

            Console.Write("Hoc phi: ");
            khoaHoc.HocPhi = int.Parse(Console.ReadLine());

            Console.Write("Thoi luong: ");
            khoaHoc.ThoiLuong = int.Parse(Console.ReadLine());

            Console.Write("Mo ta: ");
            khoaHoc.MoTa = Console.ReadLine();

            Console.Write("Trang thai: ");
            khoaHoc.TrangThai = Console.ReadLine();

            danhSachKhoaHoc.Add(khoaHoc);

            Console.WriteLine("Them khoa hoc thanh cong!");
        }

        static void SuaKhoaHoc()
        {
            Console.WriteLine("\n--- SUA KHOA HOC ---");

            Console.Write("Nhap ma khoa hoc can sua: ");
            string ma = Console.ReadLine();

            qlkhoahoc  khoaHoc = danhSachKhoaHoc
                .FirstOrDefault(x => x.MaKhoaHoc == ma);

            if (khoaHoc == null)
            {
                Console.WriteLine("Khong tim thay khoa hoc!");
                return;
            }

            Console.Write("Ten khoa hoc moi: ");
            khoaHoc.TenKhoaHoc = Console.ReadLine();

            Console.Write("Hoc phi moi: ");
            khoaHoc.HocPhi = int.Parse(Console.ReadLine());

            Console.Write("Thoi luong moi: ");
            khoaHoc.ThoiLuong = int.Parse(Console.ReadLine());

            Console.Write("Mo ta moi: ");
            khoaHoc.MoTa = Console.ReadLine();

            Console.Write("Trang thai moi: ");
            khoaHoc.TrangThai = Console.ReadLine();

            Console.WriteLine("Sua khoa hoc thanh cong!");
        }

        static void XoaKhoaHoc()
        {
            Console.WriteLine("\n--- XOA KHOA HOC ---");

            Console.Write("Nhap ma khoa hoc can xoa: ");
            string ma = Console.ReadLine();

            qlkhoahoc  khoaHoc = danhSachKhoaHoc
                .FirstOrDefault(x => x.MaKhoaHoc == ma);

            if (khoaHoc == null)
            {
                Console.WriteLine("Khong tim thay khoa hoc!");
                return;
            }

            danhSachKhoaHoc.Remove(khoaHoc);

            Console.WriteLine("Xoa khoa hoc thanh cong!");
        }

        static void TimKiemKhoaHoc()
        {
            Console.WriteLine("\n--- TIM KIEM KHOA HOC ---");

            Console.Write("Nhap ma hoac ten khoa hoc: ");
            string tuKhoa = Console.ReadLine();

            var ketQua = danhSachKhoaHoc
                .Where(x =>
                    x.MaKhoaHoc.Contains(tuKhoa) ||
                    x.TenKhoaHoc.Contains(tuKhoa))
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay khoa hoc!");
                return;
            }

            HienThiDanhSach(ketQua);
        }

        static void SapXepKhoaHoc()
        {
            Console.WriteLine("\n--- SAP XEP KHOA HOC ---");

            Console.WriteLine("1. Hoc phi tang dan");
            Console.WriteLine("2. Hoc phi giam dan");

            Console.Write("Nhap lua chon: ");
            string choice = Console.ReadLine();

            List<qlkhoahoc > ketQua;

            if (choice == "1")
            {
                ketQua = danhSachKhoaHoc
                    .OrderBy(x => x.HocPhi)
                    .ToList();
            }
            else
            {
                ketQua = danhSachKhoaHoc
                    .OrderByDescending(x => x.HocPhi)
                    .ToList();
            }

            HienThiDanhSach(ketQua);
        }

        static void LocTrangThai()
        {
            Console.WriteLine("\n--- LOC THEO TRANG THAI ---");

            Console.Write("Nhap trang thai can loc: ");
            string trangThai = Console.ReadLine();

            var ketQua = danhSachKhoaHoc
                .Where(x => x.TrangThai == trangThai)
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co khoa hoc nao!");
                return;
            }

            HienThiDanhSach(ketQua);
        }
        static void ThongKeHocPhi()
        {
            Console.WriteLine("\n--- THONG KE HOC PHI ---");

            if (danhSachKhoaHoc.Count == 0)
            {
                Console.WriteLine("Chua co khoa hoc!");
                return;
            }

            int tongHocPhi = danhSachKhoaHoc.Sum(x => x.HocPhi);

            double hocPhiTrungBinh =
                danhSachKhoaHoc.Average(x => x.HocPhi);

            int hocPhiCaoNhat =
                danhSachKhoaHoc.Max(x => x.HocPhi);

            int hocPhiThapNhat =
                danhSachKhoaHoc.Min(x => x.HocPhi);

            Console.WriteLine("Tong hoc phi: " + tongHocPhi);
            Console.WriteLine("Hoc phi trung binh: " + hocPhiTrungBinh);
            Console.WriteLine("Hoc phi cao nhat: " + hocPhiCaoNhat);
            Console.WriteLine("Hoc phi thap nhat: " + hocPhiThapNhat);
        }
        static void HienThiDanhSach(List<qlkhoahoc > danhSach)
        {
            Console.WriteLine("\n--- DANH SACH KHOA HOC ---");

            foreach (qlkhoahoc  khoaHoc in danhSach)
            {
                Console.WriteLine(
                    "Ma: " + khoaHoc.MaKhoaHoc +
                    " | Ten: " + khoaHoc.TenKhoaHoc +
                    " | Hoc phi: " + khoaHoc.HocPhi +
                    " | Thoi luong: " + khoaHoc.ThoiLuong +
                    " | Mo ta: " + khoaHoc.MoTa +
                    " | Trang thai: " + khoaHoc.TrangThai
                );
            }
        }
    }
}