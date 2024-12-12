using System;
using System.Collections.Generic;

namespace PureCode.Core
{
  public class AjaxResponse<T>
  {
    public int Code { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
  }

  public class AjaxResponse : AjaxResponse<object>
  { }

  public class PagedAjaxResponse<T> : AjaxResponse<IEnumerable<T>>
  {
    /// <summary>
    /// 总记录条数
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// 当前页码
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// 是否还有更多记录
    /// </summary>
    public bool HasMore { get; set; } = false;

    public static PagedAjaxResponse<T> Create(IEnumerable<T> data, int totalRecordCount, int page = 1, int size = 20, int code = 0, string? message = null)
    {
      var total = (int)Math.Ceiling(totalRecordCount / (double)size);
      return new PagedAjaxResponse<T>
      {
        Data = data,
        Page = page,
        Total = totalRecordCount,
        HasMore = page < total,
        Code = code,
        Message = message
      };
    }
  }

  public class PagedAjaxResponse : PagedAjaxResponse<object>
  { }
}