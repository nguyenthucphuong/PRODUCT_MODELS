using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;

namespace Product.Models
{
	public class Handle
	{
		private static List<Handle> handleList = new List<Handle>();
		public int SoThuTu { get; set; }
		public string TenSanPham { get; set; }
		public decimal SoLuong { get; set; }
		public decimal DonGia { get; set; }
		public int Count { get; set; }
		public decimal TamTinh { get; set; }
		public decimal TongTien { get; set; }

		public Handle()
		{
			this.SoThuTu = 0;
			this.TenSanPham = "";
			this.SoLuong = 1;
			this.DonGia = 1;
		}

		public static List<Handle> GetHandleList()
		{
			return handleList;
		}

		public void AddHandle(int stt, string sanpham, decimal soluong, decimal dongia)
		{
			Handle handle = new Handle
			{
				SoThuTu = handleList.Count + 1,
				TenSanPham = sanpham,
				SoLuong = soluong,
				DonGia = dongia,
				TamTinh = soluong * dongia
			};
			handleList.Add(handle);
			TongTien = handleList.Sum(h => h.SoLuong * h.DonGia);
		}
		public static decimal tinhTongTien => handleList.Sum(h => h.TamTinh);
		public void Thanhtoan()
		{
			if (handleList != null)
			{
				handleList.Clear();
			}	
			TongTien = 0;
		}
		public static void DeleteHandle(int id)
		{
			var handle = handleList.FirstOrDefault(h => h.SoThuTu == id);
			if (handle != null)
			{
				handleList.Remove(handle);
			}

			for (int i = 0; i < handleList.Count; i++)
			{
				handleList[i].SoThuTu = i + 1;
			}
		}
	}
}
