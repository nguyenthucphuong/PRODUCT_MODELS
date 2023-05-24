using Microsoft.AspNetCore.Mvc;
using Product.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product.Controllers
{
	public class SaleController : Controller
	{
		public IActionResult Index()
		{
			List<Handle> handleList = Handle.GetHandleList();
			return View(handleList);
		}

		[HttpPost]
		public ActionResult AddToCart(int stt, string sanpham, decimal soluong, decimal dongia)
		{
			Handle handle = new Handle();
			handle.AddHandle(stt, sanpham, soluong, dongia);
			return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult ThanhToan()
		{
			Handle handle = new Handle();
			handle.Thanhtoan();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult DeleteAction(int id)
		{
			Handle.DeleteHandle(id);
			return RedirectToAction("Index");
		}
	}
}
