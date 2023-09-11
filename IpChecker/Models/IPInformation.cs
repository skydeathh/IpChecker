using IpChecker.Infrastructure;
using IpChecker.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpChecker.Models;
public record IpInformation {
    [JsonProperty("type")]
    public string IPType { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("longitude")]
    public double Longitude { get; set; }   

    public Flag Flag { get; set; }

    public Connection Connection { get; set; }

    public Timezone Timezone { get; set; }

    public string GetInformationString() {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"IPType: \"{IPType}\"");
        sb.AppendLine($"CountryCode: \"{CountryCode}\"");
        sb.AppendLine($"Latitude: {Latitude}");
        sb.AppendLine($"Longitude: {Longitude}");
        sb.AppendLine($"Flag: \"{Flag?.Img}\"");
        sb.AppendLine($"Provider: \"{Connection?.Provider}\"");
        sb.AppendLine($"CurrentTime: \"{Timezone?.CurrentTime}\"");
        return sb.ToString();
    }
}
