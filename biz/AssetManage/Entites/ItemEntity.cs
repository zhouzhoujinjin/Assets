using PureCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManage.Entites
{
  public class ItemEntity: IEntity
  {
    public ulong Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public ulong AssetId { get; set; }
    public bool Enable { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }

    [JsonIgnore]
    public ICollection<ItemPropEntity>? Props { get; set; }

    [JsonIgnore]
    public AssetEntity? Asset { get; set; }

  }
}
