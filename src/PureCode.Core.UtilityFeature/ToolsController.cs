using Microsoft.AspNetCore.Mvc;
using TinyPinyin;

namespace PureCode.Core.Controllers
{
  public class ToolsController : ControllerBase
  {
    [HttpGet("/api/tools/pinyin/{chinese}", Name = "拼音转换")]
    public AjaxResponse<string> Pinyin(string chinese)
    {
      var data = PinyinHelper.GetPinyin(chinese, "").ToLower();
      return new AjaxResponse<string> { Data = data };
    }
  }
}