using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
// Added for REST API
// We are using C# REST library called RestShap
// See http://restsharp.org/ for detail
//  
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Net; // for HttpStatusCode 

//using RestSharp.Serialization.Json;

/// Revit 2016 has added two methods to help exchange store app publishers 
/// to check a store app entitlement, i.e., to check if the user has purchase or not. 
/// This is a minimum sample to show the usage.
/// 
namespace EntitlementAPIRevit
{
    public class EntitlementAPI
    {
        // Set values specific to the environment 
        public const string _baseApiUrl = @"https://apps.exchange.autodesk.com/";
        // This is the id of your app.
        //public string _appId = "";//@"5234563647474574";

        // Command to check an entitlement 
        public Autodesk.Revit.UI.Result Execute(Application rvtApp, string _appid)
        {
            string userId = rvtApp.LoginUserId;
            //  _appId = appid;
            if (userId == "") { return Result.Cancelled; }

            bool isValid = CheckEntitlement(_appid, userId);
            if (isValid)
            {
                // The usert has a valid entitlement, i.e., 
                // if paid app, purchase the app from the store.
                // For now, display the result
                string msg = "userId = " + userId + "\nappId = " + _appid + "\nisValid = " + isValid.ToString();
                return Result.Succeeded;
            }
            else
            {
                return Result.Failed;
            }

        }

        private bool CheckEntitlement(string appId, string userId)
        {
            // REST API call for the entitlement API.
            // We are using RestSharp for simplicity.
            // You may choose to use other library. 

            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(_baseApiUrl);

            // Set resource/end point
            var request = new RestRequest();
            request.Resource = "webservices/checkentitlement";
            request.Method = Method.GET;

            // Add parameters 
            request.AddParameter("userid", userId);
            request.AddParameter("appid", appId);

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // (3) Parse the response and get the value of IsValid. 
            bool isValid = false;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //TaskDialog.Show("PROISAC", "PASO 4:" + "HttpStatusCode.OK");
                JsonDeserializer deserial = new JsonDeserializer();
                EntitlementResponse entitlementResponse = deserial.Deserialize<EntitlementResponse>(response);
                isValid = entitlementResponse.IsValid;
            }
            return isValid;
        }

        [Serializable]
        public class EntitlementResponse
        {
            public string UserId { get; set; }
            public string AppId { get; set; }
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }

    }
}
