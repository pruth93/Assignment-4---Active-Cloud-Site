using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Smithsonian.Models;

namespace Smithsonian.APIHandlerManager
{
    public class APIHandler
    {
        // Obtaining the API key is easy. The same key should be usable across the entire
        // data.gov developer network, i.e. all data sources on data.gov.
        // https://www.nps.gov/subjects/developer/get-started.htm

        static string BASE_URL = "https://api.si.edu/saam/v1/books?api_key=SDcZsmPGAanWbKi7xC91h9QrBuRGLUtsAh4ektdb";
        static string API_KEY = "SDcZsmPGAanWbKi7xC91h9QrBuRGLUtsAh4ektdb"; //Add your API key here inside ""


        HttpClient httpClient;

        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>
        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public Rootobject GetData()
        {
            string API_PATH = BASE_URL + "";
            string data = "";

            Rootobject art = null;
            string[] descdat = new string[50];



            httpClient.BaseAddress = new Uri(API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string pattern = @"<(.|\n)*?>";

                    data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    //data = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase).Replace(data);
                    data = Regex.Replace(data, pattern, string.Empty);
                }

                if (!data.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    art = JsonConvert.DeserializeObject<Rootobject>(data);

                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }
                       
            return art;
        }
    }
}