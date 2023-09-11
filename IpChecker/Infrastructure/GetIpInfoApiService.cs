using IpChecker.Models;
using IpChecker.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IpChecker.Infrastructure;
public class GetIpInfoApiService {
    private static string _url = "http://ipwho.is/";
    private static HttpClient _httpClient = new();

    public static async Task<string> GetJson(string ip) {
        using var response = await _httpClient.GetAsync(_url + ip);
        if (response is null) {
            return null;
        }

        var json = await response.Content.ReadAsStringAsync();
        return json;
    }

    public static async Task<string> GetLocation(string ip) {
        var res = await GetJson(ip);
        if (JObject.Parse(res)["success"].ToString() == "False")
            return "Invalid ip";

        return JObject.Parse(res)["country_code"].ToString();
    }

    public static async Task<IpInformation> GetIpInformation(IpAdressInputViewModel ip) {
        var res = await GetJson(ip.Ip);
        var ipInformation = JsonConvert.DeserializeObject<IpInformation>(res);

        return ipInformation;
    }
}