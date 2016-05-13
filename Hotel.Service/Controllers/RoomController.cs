using DataTransferObjects;
using Hotel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel.Service.Controllers
{
    public class RoomController : ApiController
    {
        private Room _room = new Room();

        [HttpPost]
        public void CreateRoom([FromBody]RoomDto room)
        {
            _room.CreateRoom(room);
        }

        [HttpPost]
        public void Update(RoomDto room)
        {
            _room.Update(room);
        }

        [HttpPost]
        public void Delete(int id)
        {
            _room.Delete(id);
        }

        [HttpGet]
        public List<RoomDto> GetAllRooms()
        {
            return _room.GetAllRooms().ToList();
        }

        [HttpGet]
        public RoomDto GetById(int id)
        {
            return _room.GetById(id);
        }

        [HttpGet]
        public List<RoomDto> GetAvailable(DateTime startDate, DateTime endDate)
        {
            return _room.GetAvailable(startDate, endDate).ToList();
        }
    }
}
