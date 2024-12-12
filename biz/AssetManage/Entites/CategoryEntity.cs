using PureCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AssetManage.Entites
{
  public class CategoryEntity: IEntity
  {
    public ulong Id { get; set; }
    public long ParentId { get; set; }
    public required string Title { get; set; }
    public bool Enable { get; set; }

    [JsonIgnore]
    public CategoryEntity? Parent { get; set; }
    [JsonIgnore]
    public List<CategoryEntity>? Children { get; set; }


  }
}
