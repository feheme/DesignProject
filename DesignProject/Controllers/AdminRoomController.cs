using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    
    public class AdminRoomController : Controller
    {
        private readonly IRoomService _roomService;

        public AdminRoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var values = _roomService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            room.Wifi = "1";
            _roomService.TInsert(room);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.TGetByID(id);
            _roomService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRoom(int id)
        {
            var values = _roomService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return RedirectToAction("Index");
        }
        // odanın sayısını tut 
    }
}
