using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using Ames.Entities;

namespace Ames.Component.Web {

    
    
    class HttpPostMultiPart {

        public EFileInfo UploadFile(string WebApiBaseAddress, string WebApiServiceUrl, WebApiParameters webParams) {
            EFileInfo eFile = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(WebApiBaseAddress);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync(WebApiServiceUrl, webParams).Result;
            if (response.IsSuccessStatusCode) {
                // Parse the response body. 
                eFile = response.Content.ReadAsAsync<EFileInfo>().Result;
            }
            return eFile;
        }
       
    }
}
