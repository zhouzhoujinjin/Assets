﻿using PureCode.WeChat.Payment.Domain;
using System.Text.Json.Serialization;

namespace PureCode.WeChat.Payment
{
  /// <summary>
  /// WeChatPay V3 通知对象
  /// </summary>
  public abstract class WeChatPayNotify : WeChatPayObject
  {
    /// <summary>
    /// 通知原始内容
    /// </summary>
    [JsonIgnore]
    public string Body { get; set; }

    /// <summary>
    /// 通知密文
    /// </summary>
    [JsonIgnore]
    public NotifyCiphertext NotifyCiphertext { get; set; }

    /// <summary>
    /// 通知明文内容
    /// </summary>
    [JsonIgnore]
    public string ResourcePlaintext { get; set; }
  }
}