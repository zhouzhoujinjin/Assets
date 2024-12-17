using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManage.Models
{
  public class AssetPropModel
  {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
    [JsonPropertyName("propType")]
    public required string PropType { get; set; }
    [JsonPropertyName("defaultValue")]
    public string? DefaultValue{ get; set; }
    public ulong AssetId { get; set; }
  }
}
