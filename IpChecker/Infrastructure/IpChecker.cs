using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IpChecker.Infrastructure;
public static class IpData {
    private static string _url = "http://ipwho.is/";
    private static HttpClient _httpClient = new();
    private static string json;

    public static async Task<string> GetJson(string ip) {
        using var response = await _httpClient.GetAsync(_url + ip);
        if (response is null) {
            return null;
        }

        json = await response.Content.ReadAsStringAsync();
        return json;
    }

    public static async Task<string> GetLocation(string ip) {
        var res = await GetJson(ip);
        if (JObject.Parse(res)["success"].ToString() == "False")
            return "Invalid ip";

        return JObject.Parse(res)["country_code"].ToString();
    }
}