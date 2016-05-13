using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace Hotel.Client
{
    public class RoomClient : BaseClient
    {
        public void CreateRoom(RoomDto room)
        {
            param.Clear();
            param["room"] = room;
            Post("Room/CreateRoom");
        }

        public void Update(RoomDto room)
        {
            param.Clear();
            param["room"] = room;
            Post("Room/Update");
        }

        public void Delete(int id)
        {
            param.Clear();
            param["id"] = id;
            Post("Room/Delete");
        }

        public List<RoomDto> GetAllRooms()
        {
            var response = Get<List<RoomDto>>("Room/GetAllRooms");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                return new List<RoomDto>();
            }
        }

        public RoomDto GetById(int id)
        {
            param.Clear();
            param["id"] = id;
            var response = Get<RoomDto>("Room/GetById");
            return response.Data;
        }

        public List<RoomDto> GetAvailable(DateTime startDate, DateTime endDate)
        {
            param.Clear();
            param["startDate"] = startDate;
            param["endDate"] = endDate;
            var response = Get<List<RoomDto>>("Room/GetAvailable");
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                return new List<RoomDto>();
            }
        }
    }
}
