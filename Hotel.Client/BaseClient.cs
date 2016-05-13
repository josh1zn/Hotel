using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Configuration;

namespace Hotel.Client
{
    public class BaseClient
    {
        protected RestClient client;
        protected RestRequest request;
        protected Dictionary<string, object> param;

        public BaseClient()
        {
            client = new RestClient(ConfigurationSettings.AppSettings["HotelAPI"].ToString());
            param = new Dictionary<string, object>();
            request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
        }

        protected IRestResponse<T> Get<T>(string resource) where T : new()
        {
            request.Resource = resource;
            request.Method = Method.GET;
            addParameters();

            return client.Execute<T>(request);
        }

        protected IRestResponse Get(string resource)
        {
            request.Resource = resource;
            request.Method = Method.GET;
            addParameters();

            return client.Execute(request);
        }

        protected IRestResponse Post(string resource)
        {
            request.Resource = resource;
            request.Method = Method.POST;
            addParameters();
            
            return client.Execute(request);
        }

        protected IRestResponse<T> Post<T>(string resource) where T : new()
        {
            request.Resource = resource;
            request.Method = Method.POST;
            addParameters();

            return client.Execute<T>(request);
        }



        private bool isPrimitive(object obj)
        {
            Type type = obj.GetType();
            return type.IsPrimitive || type == typeof(String) || type == typeof(Decimal) || type == typeof(DateTime);
        }

        private void addParameters()
        {
            foreach (var key in param.Keys)
            {
                if (isPrimitive(param[key]))
                {
                    request.AddParameter(key, param[key], ParameterType.QueryString);
                }
                else
                {
                    request.AddJsonBody(param[key]);
                }
            }
        }
    }
}
