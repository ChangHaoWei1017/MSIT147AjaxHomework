using Microsoft.AspNetCore.Mvc;
using MSIT14720230714.Models;

namespace MSIT14720230714.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        public ApiController(DemoContext context,IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        public IActionResult Index()
        {
            return Content("Hello Ajex");
        }
        //載入縣市
        public IActionResult Cities()
        {
            var cities = _context.Address.Select(c => c.City).Distinct();
            return Json(cities);

        }
        //根據縣市載入鄉鎮區
        public IActionResult Districts(string city)
        {
            var districts = _context.Address.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);

        }
        //根據鄉鎮區載入路名
        public IActionResult Roads(string SiteId)
        {
            var roads = _context.Address.Where(a => a.SiteId == SiteId).Select(a => a.Road);
            return Json(roads);
        }
        public IActionResult AjaxEvent(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                userName = "Guest";
            }
            System.Threading.Thread.Sleep(10000);//延遲10秒鐘出現
            return Content("Hello "+ userName);
        }
        [HttpPost]
        public IActionResult Register(Members member,IFormFile Photo)
        {
            //string photoInfo = $"{ Photo.FileName} - { Photo.Length} - { Photo.ContentType}";
            //檔案上傳
            string rootPath = Path.Combine(_host.WebRootPath, "uploads", Photo.FileName);
            using(var fileStream = new FileStream(rootPath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            //寫進資料庫
            member.FileName = Photo.FileName;
            byte[]? photoByte = null;
            using(var memoryStream = new MemoryStream())
            {
                Photo.CopyTo(memoryStream);
                photoByte = memoryStream.ToArray();
            }
            member.FileData = photoByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            //return Content($"Hello{member.Name}");
            return Content(rootPath);
        }

        public IActionResult GetImageByte(int id=0)
        {
            Members? _member = _context.Members.Find(id);
            byte[]? img = _member.FileData;
            return File(img, "image/jpeg");
        }
        
    }
}
