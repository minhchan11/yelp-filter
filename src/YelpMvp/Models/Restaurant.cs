using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YelpMvp.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public int Rating { get; set; }

        public static List<Restaurant> GetRestaurants()
        {
            var client = new RestClient("http://api.yelp.com/v3");
            var request = new RestRequest("/businesses/search", Method.GET);
            request.AddParameter("term", "food");
            request.AddParameter("location", "San+Francisco");
            request.AddParameter("Authorization", "Bearer Ao9wyNEJi_JdysZZ2BQGr0sG2CgKnj1Pe3QEEjbSa6__mbKWQYitQne4wAJAmWamYagq7-P-4iZb4mzAH6ZIs_bjomtWwuU4XeFck6RhJmuQihOFdWMZqGIWhAUSWXYx", ParameterType.HttpHeader);
            client.Authenticator = new HttpBasicAuthenticator("JWOcCdALwKxh2fMrxv3uOg", "JV4s6u0wZ2AAcLriv4e2zfOCvJye09dWBDuIgKAera5eHwqa3KT2hGm7H5O1DqhL");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var restaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(jsonResponse["restaurants"].ToString());
            return restaurantList;
        }


        


        /// <summary>
        /// //////////////////////////////////////////////////
        /// </summary>
        //    request.AddParameter("term", "food");
        //        request.AddParameter("location", "San+Francisco");
        //        //4
        //        request.AddParameter("Authorization", "Bearer Ao9wyNEJi_JdysZZ2BQGr0sG2CgKnj1Pe3QEEjbSa6__mbKWQYitQne4wAJAmWamYagq7-P-4iZb4mzAH6ZIs_bjomtWwuU4XeFck6RhJmuQihOFdWMZqGIWhAUSWXYx", ParameterType.HttpHeader);

        //        //client.Authenticator = new HttpBasicAuthenticator("JWOcCdALwKxh2fMrxv3uOg", "JV4s6u0wZ2AAcLriv4e2zfOCvJye09dWBDuIgKAera5eHwqa3KT2hGm7H5O1DqhL");
        //        //5
        //        var response = new RestResponse();
        //    //3a
        //    Task.Run(async() =>
        //        {
        //            response = await GetResponseContentAsync(client, request) as RestResponse;
        //        }).Wait();
        ////4
        //JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //Console.WriteLine(jsonResponse["businesses"]);
        //        Console.ReadLine();
        /////////////////////////////////////////////

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
