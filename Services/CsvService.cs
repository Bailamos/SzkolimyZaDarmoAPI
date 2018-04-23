using System;
using System.Reflection;
using System.Text;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Services
{
    public class CsvService : ICsvService
    {
        public string ObjectToCsvData(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "Value can not be null or Nothing!");
            }

            StringBuilder sb = new StringBuilder();
            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties();

            for (int index = 0; index < pi.Length; index++)
            {
                if (
                    pi[index].PropertyType == typeof(string) ||
                    pi[index].PropertyType == typeof(int) ||
                    pi[index].PropertyType == typeof(DateTime)) {


                    sb.Append(pi[index].GetValue(obj, null));

                    if (index < pi.Length - 1)
                    {
                        sb.Append(",");
                    }
                } else if (pi[index].PropertyType.GetInterface(nameof(ICsvObject)) != null) {

                    var type = pi[index].PropertyType;
                    var method = type.GetMethod("toCsv");
      
                    var csv = method.Invoke(pi[index].GetValue(obj, null) , new object[] {});

                    sb.Append(csv);     
                    if (index < pi.Length - 1)
                    {
                        sb.Append(",");
                    }
                }
            }

            return sb.ToString();
        }
        public string ObjectToHeader(object obj) {
              if (obj == null)
            {
                throw new ArgumentNullException("obj", "Value can not be null or Nothing!");
            }

            StringBuilder sb = new StringBuilder();
            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties();

            for (int index = 0; index < pi.Length; index++)
            {
                if (
                    pi[index].PropertyType == typeof(string) ||
                    pi[index].PropertyType == typeof(int) ||
                    pi[index].PropertyType == typeof(DateTime)) {


                    sb.Append(pi[index].Name);

                    if (index < pi.Length - 1)
                    {
                        sb.Append(",");
                    }
                }
            }

            return sb.ToString();
        }
    }
}