using AssetManage.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManage.Models
{
  public class ItemPropModel
  {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }
    [JsonPropertyName("itemId")]
    public ulong ItemId { get; set; }
    [JsonPropertyName("propId")]
    public ulong PropId { get; set; }
    [JsonPropertyName("isNull")]
    public bool IsNull { get; set; }
    [JsonPropertyName("propValue")]
    public string? PropValue { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }

    public ItemEntity? Item { get; set; }
  }
}
