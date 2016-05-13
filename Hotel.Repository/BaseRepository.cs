using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotel.Repository
{
    public class BaseRepository<T> where T : class
    {
        private SqlConnection con;

        public BaseRepository()
        {
            con = new SqlConnection(ConfigurationSettings.AppSettings["HotelDB"].ToString());         
        }

        protected T Get(string storedProc, object param = null)
        {
            con.Open();
            var response = con.Query<T>(storedProc, param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            con.Close();
            return response;
        }

        protected IEnumerable<T> GetAll(string storedProc, object param = null)
        {
            con.Open();
            var response = con.Query<T>(storedProc, param, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            return response;
        }

        protected int Execute(string storedProc, object param = null)
        {
            con.Open();
            var response = con.Execute(storedProc, param, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            return response;
        }

        protected U Execute<U>(string storedProc, object param = null) where U : new()
        {
            con.Open();
            var response = con.ExecuteScalar<U>(storedProc, param, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            return response;
        }
    }
}
