using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PureCode.Core.Managers;
using PureCode.Core.Models;

namespace PureCode.Core.Controllers;

public partial class MenuController : ControllerBase
{
  [HttpGet("/api/admin/nav", Name = "管理员 - 菜单树")]
  public async Task<AjaxResponse<ICollection<MenuItemModel>?>> ListAllAsync()
  {
    var menuItems = await menuManager.GetMenuAsync();
    return new AjaxResponse<ICollection<MenuItemModel>?> { Data = menuItems };
  }

  [HttpPost("/api/admin/nav/update", Name = "管理员 - 更新菜单项")]
  public async Task<AjaxResponse> UpdateAsync([FromBody] MenuItemModel item)
  {
    await menuManager.UpdateMenuItemAsync(item);

    return new AjaxResponse { Message = $"更新菜单成功" };
  }

  [HttpPost("/api/admin/nav/{id}/parent", Name = "管理员 - 更新菜单项位置")]
  public async Task<AjaxResponse> UpdateAsync(ulong id, [FromBody] ulong? parentId)
  {
    await menuManager.UpdateHierarchicalAsync(id, parentId);
    return new AjaxResponse { };
  }

  [HttpPost("/api/admin/nav/create", Name = "管理员 - 新建菜单项")]
  public async Task<AjaxResponse> CreateAsync([FromBody] MenuItemModel item)
  {
    if (!string.IsNullOrEmpty(item.Uri))
    {
      var uriAvalible = await menuManager.ExistUri(item.Uri);
      if (uriAvalible) { return new AjaxResponse { Message = $"路由地址已存在", Code = 500 }; }
      await menuManager.AddMenuAsync(item);
      return new AjaxResponse { Message = $"新建菜单成功" };
    }
    return new AjaxResponse { Message = $"路由地址不能为空" };
  }

  [HttpPost("api/admin/nav/{menuId}/delete", Name = "管理员 - 删除菜单项")]
  public async Task<AjaxResponse> DeleteAsync(ulong menuId)
  {
    await menuManager.DeleteMenuAsync(menuId);
    return new AjaxResponse { Message = "删除成功" };
  }

  /// <summary>
  /// 获取所有后端的权限点
  /// </summary>
  /// <returns></returns>
  [HttpGet("/api/admin/permissions", Name = "管理员 - 权限点列表")]
  public async Task<AjaxResponse<IEnumerable<PermissionModel>>> GetAllPermissions()
  {
    var allPermissions = new List<PermissionModel>();
    var rolePermissions = roleManager.GetPermissionActions();
    var menuPermissions = await menuManager.GetMenuListAsync();
    allPermissions.AddRange(rolePermissions);
    allPermissions.AddRange(menuPermissions);
    return new AjaxResponse<IEnumerable<PermissionModel>>
    {
      Data = allPermissions,
    };
  }



}