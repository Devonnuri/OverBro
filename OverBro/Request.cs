using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OverBro {
    class Request {
        public static JObject get(string battleTag) {
            string url = "https://owapi.net/api/v3/u/" + battleTag + "/stats";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.UserAgent = "Mozilla/5.0";

            Stream resStream = req.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return JObject.Parse(reader.ReadToEnd());
        }
    }
}
