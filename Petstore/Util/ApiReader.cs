using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Petstore.Model;

namespace Petstore.Util
{
    public class ApiReader
    {
        private const string Url = "https://petstore.swagger.io/v2";

        public static Pet[] GetAvailablePets()
        {
            //Create request for API call
            var request = WebRequest.Create(Url + "/pet/findByStatus?status=available");
            request.Method = "GET";
            request.Timeout = 30000;

            //Get & parse API reqsponse
            try
            {
                using (var webResponse = request.GetResponse())
                {
                    using (var responseStream = webResponse.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                var data = reader.ReadToEnd();
                                return JsonConvert.DeserializeObject<Pet[]>(data);
                            }
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);                
            }
            return new Pet[0];
        }

    }
}
