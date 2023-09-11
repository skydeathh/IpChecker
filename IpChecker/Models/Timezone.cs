using Newtonsoft.Json;

namespace IpChecker.Models;
public class Timezone {
    [JsonProperty("current_time")]
    public string CurrentTime { get; set; }
}