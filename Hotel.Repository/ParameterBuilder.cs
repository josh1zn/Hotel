using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public static class ParameterBuilder
    {
        public static dynamic BuildInclude(object obj, params string[] props)
        {
            var o = new ExpandoObject() as IDictionary<string, object>;
            var t = obj.GetType();
            foreach (var prop in props)
            {
                var propName = toTitleCase(prop);
                object val = t.GetProperty(propName).GetValue(obj);
                if(val.GetType() == typeof(DateTime))
                {
                    val = ((DateTime)val).ToLocalTime();
                }
                o.Add(propName, val);
            }

            return o;
        }

        public static object BuildExclude(object obj, params string[] propsToExclude)
        {
            var o = new ExpandoObject() as IDictionary<string, object>;
            var properties = obj.GetType().GetProperties();

            foreach (var objProp in properties)
            {
                bool add = true;

                foreach (var prop in propsToExclude)
                {
                    if(objProp.Name.Equals(prop, StringComparison.InvariantCultureIgnoreCase))
                    {
                        add = false;
                    }
                }

                if(add)
                {
                    object val = objProp.GetValue(obj);
                    if (val.GetType() == typeof(DateTime))
                    {
                        val = ((DateTime)val).ToLocalTime();
                    }
                    o.Add(objProp.Name, val);
                }
            }

            return o;
        }

        private static string toTitleCase(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
