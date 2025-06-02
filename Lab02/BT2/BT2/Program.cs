using System;
using System.Collections.Generic;
using System.Text;

class MatHang
{
    public int MaMH { get; set; }
    public string TenMH { get; set; }
    public int SoLuong { get; set; }
    public double DonGia { get; set; }

    public MatHang(int ma, string ten, int sl, double gia)
    {
        MaMH = ma;
        TenMH = ten;
        SoLuong = sl;
        DonGia = gia;
    }
    public double ThanhTien()
    {
        return SoLuong * DonGia;
    }
    public void Xuat()
    {
        Console.WriteLine($"Mã: {MaMH}, Tên: {TenMH}, SL: {SoLuong}, Đơn giá: {DonGia}");
    }
}

class Program
{
    static void ThemMatHang(List<MatHang> danhSach)
    {
        Console.WriteLine("Nhập mã mặt hàng: ");
        int ma = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhập tên mặt hàng: ");
        string ten = Console.ReadLine();
        Console.WriteLine("Nhập số lượng: ");
        int sl = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhập đơn giá: ");
        double gia = double.Parse(Console.ReadLine());
        danhSach.Add(new MatHang(ma, ten, sl, gia));
    }
    static bool TimMatHang(List<MatHang> danhSach, int ma)
    {
        return danhSach.Exists(mh => mh.MaMH == ma);
    }
    static void XuatDanhSach(List<MatHang> danhSach)
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sách rỗng!");
            return;
        }

        Console.WriteLine("Danh sách mặt hàng: ");
        foreach (var mh in danhSach)
        {
            mh.Xuat();
        }

    }
    static void XoaMatHang(List<MatHang> danhSach, int ma)
    {
        danhSach.RemoveAll(mh => mh.MaMH == ma);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<MatHang> danhSach = new List<MatHang>();
        string tiepTuc;
        do
        {
            ThemMatHang(danhSach);
            Console.Write("Bạn có muốn nhận tiếp không (Y/N): ");
            tiepTuc = Console.ReadLine().ToLower();
        }
        while (tiepTuc == "y");
        XuatDanhSach(danhSach);
        Console.Write("Nhập mã mặt hàng cần tìm và xóa: ");
        int maCanXoa = int.Parse(Console.ReadLine());
        if (TimMatHang(danhSach, maCanXoa))
        {
            XoaMatHang(danhSach, maCanXoa);
            Console.WriteLine("Đã xóa mặt hàng!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy mặt hàng!");
        }
        XuatDanhSach(danhSach);
    }
}
