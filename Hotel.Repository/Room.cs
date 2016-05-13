using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public class Room : BaseRepository<RoomDto>
    {
        public void CreateRoom(RoomDto room)
        {
            Execute("spCreateRoom", ParameterBuilder.BuildInclude(room, "number", "type", "price"));
        }

        public void Update(RoomDto room)
        {
            Execute("spUpdateRoom", ParameterBuilder.BuildExclude(room));
        }

        public void Delete(int id)
        {
            Execute("spDeleteRoom", new { Id = id });
        }

        public IEnumerable<RoomDto> GetAllRooms()
        {
            return GetAll("spGetAllRooms");
        }

        public RoomDto GetById(int id)
        {
            return Get("spGetRoomById", new { Id = id });
        }

        public IEnumerable<RoomDto> GetAvailable(DateTime startDate, DateTime endDate)
        {
            return GetAll("spGetRoomsAvailable", new { StartDate = startDate, EndDate = endDate });
        }
    }
}
