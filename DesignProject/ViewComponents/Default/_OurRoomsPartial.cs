using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Default
{
    public class _OurRoomsPartial : ViewComponent
    {
        private readonly IRoomService _roomService;

        public _OurRoomsPartial(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _roomService.TGetList();
            return View(values);
        }
    }
}
