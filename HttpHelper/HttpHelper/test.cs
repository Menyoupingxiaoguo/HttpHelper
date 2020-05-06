using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    public class test
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <returns></returns>
        public string GetTest()
        {
            string url = "";
            string strResult = HttpHelper.HttpGet(url, "");
            dynamic objResult = JsonConvert.DeserializeObject<object>(strResult);
            if (objResult != null && objResult.errcode == "0")
            {
                string access_token = objResult.access_token;
                return access_token;
            }
            return "";
        }
        /// <summary>
        /// Post请求
        /// </summary>
        /// <returns></returns>
        public string PostTest()
        {
            string Token = "";
            string data = "{}";
            string path = "";
            HttpHelper httpHelper = new HttpHelper();
            string result = httpHelper.HttpPost(data, new HttpItem
            {
                Headers = new Dictionary<string, string> {
                    { "Authorization" , "Bearer " + Token }
                },
                URL = path,
                ContentType = "application/json",
                Accept = "application/json",
                Method = "POST"
            });

            JObject jsonObj = (JObject)JsonConvert.DeserializeObject(result);
            if (jsonObj != null)
                if (jsonObj["code"].Value<Int32>() == 1)
                    return jsonObj["result"].ToString();

            return null;
        }
    }
}
