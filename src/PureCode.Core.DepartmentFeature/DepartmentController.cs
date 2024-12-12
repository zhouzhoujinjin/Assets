using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PureCode.Core.Kernel;
using PureCode.Core.Models;

namespace PureCode.Core.DepartmentFeature
{
  [ApiController]
  [Route("", Name = "部门管理")]
  //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = PermissionClaimNames.ApiPermission)]
  public partial class DepartmentController(DepartmentManager departmentManager) : ControllerBase
  {
    [HttpGet("/api/departments", Name = "用户 - 部门列表")]
    public async Task<AjaxResponse<ICollection<DepartmentModel>?>> ListAsync()
    {
      var departments = await departmentManager.ListAllAsync();
      return new AjaxResponse<ICollection<DepartmentModel>?> { Data = departments };
    }

    [HttpGet("/api/departments/users", Name = "用户 - 全部用户（部门）列表")]
    public async Task<AjaxResponse<ICollection<UserModel>?>> ListWithDepartment()
    {
      var userList = await departmentManager.GetAllUsersWithDepartmentsRolesAsync();
      return new AjaxResponse<ICollection<UserModel>?>
      {
        Data = userList,
      };
    }

  }
}
