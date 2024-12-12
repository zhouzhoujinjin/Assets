using Example.Managers;
using Example.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PureCode.Core;
using PureCode.Core.Kernel;

namespace Example.Controllers;

[ApiController]
[Route("/api/config", Name = "系统设置")]
public class ConfigController : ControllerBase
{
  private readonly ConfigManager configManager;

  public ConfigController(ConfigManager configManager)
  {
    this.configManager = configManager;
  }

  [HttpGet("/WW_verify_{code}.txt")]
  public string Index([FromRoute] string code)
  {
    return code;
  }

  [HttpGet(Name = "系统设置")]
  public async Task<AjaxResponse<SystemConfigModel>> IndexAsync()
  {
    var config = await configManager.GetAllConfigAsync();
    return new AjaxResponse<SystemConfigModel> { Data = config };
  }

  [HttpPost("/api/admin/config/update", Name = "更新系统设置")]
  //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
  //  Policy = PermissionClaimNames.ApiPermission)]
  public async Task<AjaxResponse> Save([FromBody] SystemConfigModel config)
  {
    await configManager.SaveConfigAsync(config);
    return new AjaxResponse
    {
      Message = "操作完成",
      Data = null
    };
  }
}