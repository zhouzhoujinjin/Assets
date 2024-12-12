using PureCode.Core;
using PureCode.Core.DepartmentFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManage.Entites
{
  public class AssetEntity: IEntity
  {
    public ulong Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public ulong CategoryId { get; set; }
    public bool Enable { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }

    [JsonIgnore]
    public ICollection<AssetPropEntity>? Props { get; set; }

    [JsonIgnore]
    public ICollection<ItemEntity>? Items { get; set; }

  }


}
