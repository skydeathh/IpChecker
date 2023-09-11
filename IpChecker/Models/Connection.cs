using Newtonsoft.Json;

namespace IpChecker.Models;
public class Connection {
    [JsonProperty("org")]
    public string Provider { get; set; }
}

