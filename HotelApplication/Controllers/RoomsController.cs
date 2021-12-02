using Microsoft.AspNetCore.Mvc;
using HotelApplication.Models;
using HotelApplication.Services.Interfaces;
using HotelApplication.ViewModels;

namespace HotelApplication.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsData _roomsData;

        public RoomsController(IRoomsData roomsData) => _roomsData = roomsData;

        public IActionResult Index() => View(_roomsData.GetAll());

        public IActionResult Details(int id)
        {
            var room = _roomsData.Get(id);

            if (room == null)
                return NotFound();

            return View(room);
        }

        public IActionResult Create() => View("Edit", new RoomViewModel());

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new RoomViewModel());

            var room = _roomsData.Get((int)id);
            if (room is null)
                return NotFound();

            var view_model = new RoomViewModel
            {
                Id = room.Id,
                Capacity = room.Capacity,
                Comfort = room.Comfort,
                Price = room.Price,
            };
            return View(view_model);
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel Model)
        {
            var room = new Room
            {
                Id = Model.Id,
                Capacity = Model.Capacity,
                Comfort = Model.Comfort,
                Price = Model.Price,
            };

            if (room.Id == 0)
                _roomsData.Add(room);
            else
                _roomsData.Update(room);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var room = _roomsData.Get(id);
            if (room is null)
                return NotFound();

            return View(new RoomViewModel
            {
                Id = room.Id,
                Capacity = room.Capacity,
                Comfort = room.Comfort,
                Price = room.Price,
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _roomsData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
