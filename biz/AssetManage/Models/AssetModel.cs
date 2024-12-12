using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManage.Models
{
  public class AssetModel
  {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("categoryId")]
    public ulong CategoryId { get; set; }

    public bool Enable { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    [JsonPropertyName("assetProps")]
    public List<AssetPropModel>? AssetProps { get; set; }
  }
}
