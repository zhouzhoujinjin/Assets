using Microsoft.Extensions.Caching.Distributed;
using PureCode.Core.TreeFeature;
using PureCode.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureCode.Core.Managers;
using Microsoft.EntityFrameworkCore;
using PureCode.Core.DepartmentFeature;
using AssetManage.Entites;
using AssetManage.Models;

namespace AssetManage
{
  public class AssetManager(PureCodeDbContext context,
  //TreeNodeManager treeNodeManager,
  IDistributedCache cache,
  UserManager userManager)
  {
    private readonly DbSet<AssetEntity> AssetSet = context.Set<AssetEntity>();
    private readonly DbSet<AssetPropEntity> AssetPropSet = context.Set<AssetPropEntity>();

    public async Task<ICollection<AssetModel>?> ListAllAsync()
    {
      var entities = await AssetSet.Where(x => x.Enable).Include(x => x.Props).ToListAsync();
      if (entities == null) return null;
      var models = new List<AssetModel>();
      foreach (var entity in entities)
      {
        var model = new AssetModel
        {
          Title = entity.Title,
          CategoryId = entity.CategoryId,
          Description = entity.Description,
          Id = entity.Id,
          CreatedTime = entity.CreatedTime,
          UpdatedTime = entity.UpdatedTime,
          AssetProps =entity?.Props?.Select(e=>new AssetPropModel { 
            AssetId = e.AssetId,
            Id = e.Id,
            PropType = e.PropType,
            Title = e.Title,
            Description = e.Description,
            Unit=e.Unit,
          }).ToList()
        };
        models.Add(model);
      };
      return models;
    }
  }
}
