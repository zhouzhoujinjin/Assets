using PureCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManage.Entites
{
  public class AssetPropEntity: IEntity
  {
    public ulong Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public required string PropType { get; set; }
    public ulong AssetId { get; set; }
    public bool Enable { get; set; }
    public string? DefaultValue {  get; set; } 

    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }

    public AssetEntity? Asset { get; set; }
  }
}
