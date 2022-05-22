using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System;

namespace prueba_xcaret.Objects
{
    public class getData
    {
        public List<Models.Entries> GetListEntries()
        {
            var url = Objects.MyConfiguration.MyUrl;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            List<Models.Entries> myListEntries = new List<Models.Entries>();
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream SReader = response.GetResponseStream())
                    {
                        if (SReader == null) return null;
                        using (StreamReader OReader = new StreamReader(SReader))
                        {
                            string content = OReader.ReadToEnd();
                        
                            JsonDocument JDocument = JsonDocument.Parse(content);
                            JsonElement JRoot = JDocument.RootElement;
                            JsonElement jEntries = JRoot.GetProperty("entries");

                            foreach (JsonElement JEntrie in jEntries.EnumerateArray())
                                myListEntries.Add(JsonSerializer.Deserialize<Models.Entries>(JEntrie.ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error",ex);
            }
            return myListEntries;
        }
    }
}
