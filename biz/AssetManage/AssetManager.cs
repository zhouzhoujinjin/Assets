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
    private readonly DbSet<AssetEntity> assetSet = context.Set<AssetEntity>();
    private readonly DbSet<AssetPropEntity> assetPropSet = context.Set<AssetPropEntity>();

    #region Asset
    public async Task<ICollection<AssetModel>?> AssetListAllAsync()
    {
      var entities = await assetSet.Where(x => x.Enable).Include(x => x.Props).ToListAsync();
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
          AssetProps = entity?.Props?.Select(e => new AssetPropModel
          {
            AssetId = e.AssetId,
            Id = e.Id,
            PropType = e.PropType,
            Title = e.Title,
            Description = e.Description,
            Unit = e.Unit,
          }).ToList()
        };
        models.Add(model);
      };
      return models;
    }

    public async Task<AssetModel> AddAssetAsync(AssetModel assetModel)
    {
      var assetEntity = new AssetEntity
      {
        Title = assetModel.Title,
        CategoryId = assetModel.CategoryId,
        Description = assetModel.Description,
        CreatedTime = DateTime.Now,
        Enable = true,
        UpdatedTime = DateTime.Now,
      };
      assetSet.Add(assetEntity);
      await context.SaveChangesAsync();
      assetModel.Id = assetEntity.Id;
      return assetModel;
    }

    public async Task UpdateAssetAsync(ulong assetId, AssetModel assetModel)
    {
      var assetEntity = await assetSet.Where(x => x.Id == assetId).FirstOrDefaultAsync();
      if (assetEntity != null)
      {
        assetEntity.Title = assetModel.Title;
        assetEntity.CategoryId = assetModel.CategoryId;
        assetEntity.Description = assetModel.Description;
        assetEntity.UpdatedTime = DateTime.Now;
        assetSet.Update(assetEntity);
        await context.SaveChangesAsync();
      }
    }

    public async Task DeleteAssetAsync(ulong assetId)
    {
      var assetEntity = await assetSet.Where(x => x.Id == assetId).FirstOrDefaultAsync();
      if (assetEntity != null)
      {
        assetEntity.Enable = false;
        assetSet.Update(assetEntity);
        await context.SaveChangesAsync();
      }
    }
    #endregion

    #region AssetProp
    public async Task<ICollection<AssetPropModel>?> AssetPropListAllAsync(ulong assetId)
    {
      var entities = await assetPropSet.Where(x => x.AssetId == assetId).ToListAsync();
      if (entities != null)
      {
        return entities.Select(e => new AssetPropModel
        {
          AssetId = assetId,
          Title = e.Title,
          PropType = e.PropType,
          Description = e.Description,
          Unit = e.Unit,
          Id = e.Id,
        }).ToList();
      }
      return null;
    }

    public async Task AddAssetProp(ulong assetId, AssetPropModel assetProp)
    {
      var entity = new AssetPropEntity
      {
        PropType = assetProp.PropType,
        AssetId = assetId,
        Title = assetProp.Title,
        Description = assetProp.Description,
        Unit = assetProp.Unit,
        DefaultValue = assetProp.DefaultValue,
        Enable = true,
        CreatedTime = DateTime.Now,
        UpdatedTime = DateTime.Now,
      };
      assetPropSet.Add(entity);
      await context.SaveChangesAsync();
    }

    public async Task UpdateAssetProp(ulong assetPropId, AssetPropModel assetPropModel)
    {
      var propEntity = await assetPropSet.Where(x => x.Id == assetPropId).FirstOrDefaultAsync();
      if (propEntity != null)
      {
        propEntity.Title = assetPropModel.Title;
        propEntity.PropType = assetPropModel.PropType;
        propEntity.Description = assetPropModel.Description;
        propEntity.Unit = assetPropModel.Unit;
        propEntity.UpdatedTime = DateTime.Now;
        assetPropSet.Update(propEntity);
        await context.SaveChangesAsync();
      }
    }

    public async Task DeleteAssetProp(ulong assetPropId)
    {
      var entity = await assetPropSet.Where(x => x.Id == assetPropId).FirstOrDefaultAsync();
      if (entity != null)
      {
        entity.Enable = false;
        assetPropSet.Update(entity);
        await context.SaveChangesAsync();
      }
    }

    #endregion


  }
}
