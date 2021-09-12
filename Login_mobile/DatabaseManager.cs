using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Login_mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Login_mobile
{
    class DatabaseManager
    {
        public static List<Property> GetPropertyData()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync("http://10.0.2.2:33869/api/Properties");
            var Property_Obj = JsonConvert.DeserializeObject<List<Property>>(response.Result);
            return Property_Obj.ToList();
        }
        public static void AddProperty(string WeeklyRent, string Bedrooms, string Bathrooms, string Location)
        {
            try
            {
                Property Property_Obj = new Property
                {
                    Property_WeeklyRent = WeeklyRent,
                    Property_Number_of_Bedrooms = Bedrooms,
                    Property_Number_of_Bathrooms = Bathrooms,
                    Property_Location = Location
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(Property_Obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PostAsync(string.Format("http://10.0.2.2:33869/api/Properties"), httpContent);

            }
            catch (Exception e)
            {
                Console.WriteLine("Insert Property Data Error " + e.Message);
            }
        }
        public static void EditProperty1(string WeeklyRent, string Bedrooms, string Bathrooms, string Location, int Property_Id)
        {
            try
            {
                // Define the object of student class and pass the values of the parameters to object variables.

                Property Property_Obj = new Property
                {
                    Property_WeeklyRent = WeeklyRent,
                    Property_Number_of_Bedrooms = Bedrooms,
                    Property_Number_of_Bathrooms = Bathrooms,
                    Property_Location = Location,
                    Id = Property_Id
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(Property_Obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PutAsync(string.Format("http://10.0.2.2:33869/api/Properties/{0}", Property_Id), httpContent);

            }
            catch (Exception e)
            {
                Console.WriteLine("Update Property Data Error " + e.Message);
            }
        }

        public static void DeleteProperty1(int Property_Id)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DeleteAsync(string.Format("http://10.0.2.2:33869/api/Properties/{0}", Property_Id));
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete Property Data Error " + e.Message);
            }
        }
        public static List<Agent> GetAgentData()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync("http://10.0.2.2:33869/api/Agents");
            var Agent_Obj = JsonConvert.DeserializeObject<List<Agent>>(response.Result);
            return Agent_Obj.ToList();
        }
        public static void AddAgent(string Name, string Email, string Mobile, string Location)
        {
            try
            {
                Agent Agent_Obj = new Agent
                {
                    Agent_Name = Name,
                    Agent_Email = Email,
                    Agent_Mobile = Mobile,
                    Office_Location = Location
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(Agent_Obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PostAsync(string.Format("http://10.0.2.2:33869/api/Agents"), httpContent);

            }
            catch (Exception e)
            {
                Console.WriteLine("Insert Agent Data Error " + e.Message);
            }
        }
        public static void EditProperty2(string Name, string Email, string Mobile, string Location, int Agent_Id)
        {
            try
            {
                // Define the object of student class and pass the values of the parameters to object variables.

                Agent Agent_Obj = new Agent
                {
                    Agent_Name = Name,
                    Agent_Email = Email,
                    Agent_Mobile = Mobile,
                    Office_Location = Location,
                    Id = Agent_Id
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(Agent_Obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PutAsync(string.Format("http://10.0.2.2:33869/api/Agents/{0}", Agent_Id), httpContent);

            }
            catch (Exception e)
            {
                Console.WriteLine("Update Property Data Error " + e.Message);
            }
        }

        public static void DeleteProperty2(int Agent_Id)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DeleteAsync(string.Format("http://10.0.2.2:33869/api/Agents/{0}", Agent_Id));
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete Agent Data Error " + e.Message);
            }
        }
    }
}