using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        private readonly ISubscribeService _subscribeService;

        public DefaultController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Subscribe(Subscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return RedirectToAction("Index", "Default");
        }

        // Kullanıcı girişi yap.
        // datetimeların validasyonları kontrol et.
        // odaların sayısı düşürmek
    }
}
