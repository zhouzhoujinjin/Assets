﻿using System;

namespace PureCode.WeChat.Payment
{
  /// <summary>
  /// 敏感信息字段
  /// </summary>
  /// <remarks>
  /// 该字段提交请求前，将自动进行加密处理。
  /// </remarks>
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class WeChatPayPrivacyPropertyAttribute : Attribute
  {
  }
}