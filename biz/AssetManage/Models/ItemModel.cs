using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManage.Models
{
  public class ItemModel
  {
    [JsonPropertyName("id")]
    public ulong Id { get; set; }
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    public ulong AssetId { get; set; }
    public bool Enable { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
  }
}
