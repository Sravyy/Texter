﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Texter.Models
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }

        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/\" + EnvironmentVariables.AccountSid + \"/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator("AC29dc178aaa9ea62d10b534837c8fffdb", "060922ea280ad0e05491e22c34dca699");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse["messages"].ToString());
            return messageList;
        }

        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/AC29dc178aaa9ea62d10b534837c8fffdb/Messages", Method.POST);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body);
            client.Authenticator = new HttpBasicAuthenticator("AC29dc178aaa9ea62d10b534837c8fffdb", "060922ea280ad0e05491e22c34dca699");
            client.ExecuteAsync(request, response => {
                Console.WriteLine(response.Content);
            });
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