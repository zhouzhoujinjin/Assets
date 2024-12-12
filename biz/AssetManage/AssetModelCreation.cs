
using AssetManage.Entites;
using Microsoft.EntityFrameworkCore;
using PureCode.Core;
using PureCode.Core.DepartmentFeature;

namespace AssetManage
{
  public class AssetModelCreation : IModelCreation
  {
    public int Seq => (int)ModelCreatingPriority.Level2;

    public static void OnModelCreating(ModelBuilder builder, string? dbType = null)
    {
      builder.Entity<CategoryEntity>(entity =>
      {
        entity.ToTable("Biz_Category").HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
      });

      builder.Entity<AssetEntity>(entity =>
      {
        entity.ToTable("Biz_Asset").HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
      });

      builder.Entity<AssetPropEntity>(entity =>
      {
        entity.ToTable("Biz_AssetProp").HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.HasOne(e => e.Asset).WithMany(e => e.Props).HasForeignKey(e => e.AssetId);

      });

      builder.Entity<ItemEntity>(entity =>
      {
        entity.ToTable("Biz_Item").HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.HasOne(e => e.Asset).WithMany(e => e.Items).HasForeignKey(e => e.AssetId);
      });

      builder.Entity<ItemPropEntity>(entity =>
      {
        entity.ToTable("Biz_ItemProp").HasKey(e => e.Id);
        entity.Property(e => e.Id).ValueGeneratedOnAdd();
        entity.HasOne(e => e.Item).WithMany(e => e.Props).HasForeignKey(e => e.ItemId);
      });
    }
  }
}
