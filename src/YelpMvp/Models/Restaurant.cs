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
        public string Rating { get; set; }

        //public static string OAuth2 { get; set; }

        //public static void AuthorizeApp()
        //{
        //    var client = new RestClient("http://api.yelp.com/");
        //    var request = new RestRequest("oauth2/token", Method.POST);
        //    request.AddParameter("grant_type", "client_credentials");
        //    request.AddParameter("client_id", "JWOcCdALwKxh2fMrxv3uOg");
        //    request.AddParameter("client_secret", "JV4s6u0wZ2AAcLriv4e2zfOCvJye09dWBDuIgKAera5eHwqa3KT2hGm7H5O1DqhL");
        //    var response = new RestResponse();
        //    Task.Run(async () =>
        //    {
        //        response = await GetResponseContentAsync(client, request) as RestResponse;
        //    }).Wait();
        //    Console.WriteLine(response);
        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //    //OAuth2= jsonResponse["access_token"].ToString();   
        //    OAuth2 = JsonConvert.SerializeObject(jsonResponse["access_token"]);   
        //}
        //public static List<Restaurant> GetRestaurants()
        //{
        //    Restaurant.AuthorizeApp();
        //    var client = new RestClient("http://api.yelp.com/v3");
        //    var request = new RestRequest("/businesses/search", Method.GET);
        //    request.AddParameter("term", "food");
        //    request.AddParameter("location", "San+Francisco");
        //    request.AddParameter("Authorization", "Bearer " + OAuth2, ParameterType.HttpHeader);
        //    var response = new RestResponse();
        //    Task.Run(async () =>
        //    {
        //        response = await GetResponseContentAsync(client, request) as RestResponse;
        //    }).Wait();
        //    Console.WriteLine(response);
        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //    var restaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(jsonResponse["businesses"].ToString());
        //    OAuth2 = JsonConvert.SerializeObject(jsonResponse["access_token"]);
        //    return restaurantList;
        //}


        public static List<Restaurant> GetRestaurants()
        {
            var client = new RestClient("http://api.yelp.com/v3");
            var request = new RestRequest("/businesses/search", Method.GET);
            request.AddParameter("term", "food");
            request.AddParameter("location", "San+Francisco");
            request.AddParameter("Authorization", "Bearer Ao9wyNEJi_JdysZZ2BQGr0sG2CgKnj1Pe3QEEjbSa6__mbKWQYitQne4wAJAmWamYagq7-P-4iZb4mzAH6ZIs_bjomtWwuU4XeFck6RhJmuQihOFdWMZqGIWhAUSWXYx", ParameterType.HttpHeader);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            Console.WriteLine(response);
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var restaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(jsonResponse["businesses"].ToString());
            return restaurantList;
        }
        public static List<Restaurant> GetCustomRestaurants(string cuisine, string location)
        {
            var client = new RestClient("http://api.yelp.com/v3");
            var request = new RestRequest("/businesses/search", Method.GET);
            request.AddParameter("term", cuisine);
            request.AddParameter("location", location);
            request.AddParameter("Authorization", "Bearer Ao9wyNEJi_JdysZZ2BQGr0sG2CgKnj1Pe3QEEjbSa6__mbKWQYitQne4wAJAmWamYagq7-P-4iZb4mzAH6ZIs_bjomtWwuU4XeFck6RhJmuQihOFdWMZqGIWhAUSWXYx", ParameterType.HttpHeader);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            Console.WriteLine(response);
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var restaurantList = JsonConvert.DeserializeObject<List<Restaurant>>(jsonResponse["businesses"].ToString());
            return restaurantList;
        }

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
