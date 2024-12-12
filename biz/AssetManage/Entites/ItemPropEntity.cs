using PureCode.Core;
using PureCode.Core.DepartmentFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManage.Entites
{
  public class ItemPropEntity:IEntity
  {
    public ulong Id { get; set; }
    public ulong ItemId { get; set; }
    public ulong PropId { get; set; }
    public bool IsNull { get; set; }
    public string? PropValue { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }

    public ItemEntity? Item { get; set; }

  }
}
