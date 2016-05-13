using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTransferObjects;
using System.Collections;

namespace Hotel.Repository.Test
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void CreateRoom()
        {
            Room room = new Room();
            RoomDto r = new RoomDto();
            r.Type = "Standard";
            r.Price = 900.00M;
            room.CreateRoom(r);
            r.Type = "Executive";
            r.Price = 1500.00M;
            room.CreateRoom(r);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetAllRooms()
        {
            Room room = new Room();
            IEnumerable rooms = room.GetAllRooms();
            foreach (RoomDto r in rooms)
            {
                Assert.IsNotNull(r);
            }
        }
    }
}
