# 样例项目说明

本项目中包含两个 `sln` 文件，一般项目使用 `Example.sln`，直接引用 `nuget` 上编译好的包。 `Example.dev.sln` 中引用了 `../src` 中的 `PureCode.Core` 源码，如果你有修改或调试包内代码时，可以使用此解决方案。

## 配置说明

```jsonc
{
  // 监听地址，多个地址可以用“;”分割。如果不是直接使用本项目新建项目，请参考 `Program.cs` 中的 `UseUrls` 部分修改你的代码。
  "Urls":  "http://127.0.0.1:7827",
  // 日志配置
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  // PureCode Core 数据库类型
  // 支持 'mysql', 'oracle', 'mssql'。
  "DatabaseType":  "mysql",
  // 连接字符串，PureCode Core 只会调用 Key 为 'Default' 的连接字符串。
  "ConnectionStrings": {
    "Default": "Server=81.70.127.60;Database=purecodeV6;Uid=root;CharSet=utf8;Pwd=PureC0de=8"
  },
  // 密码安全配置项，目前没使用到。
  "PasswordSecretOptions": {
    "AesKey": "9FG6TvQKov!CXF@j*rW8ozqIA!$iG0ra"
  },
  // JWT 相关配置
  "JwtIssuerOptions": {
    "Issuer": "purecode",
    "Audience": "purecode",
    "SecretKey": "9FG6TvQKov!CXF@j*rW8ozqIA!$iG0ra",
    "AccessTokenExpiredMinutes": 30,
    "RefreshTokenExpiredDays": 30
  },
  // 缓存配置
  "CacheOptions": {
    // Redis 缓存配置，Instance 一定要根据实际项目进行修改，保证使用同一个Redis服务的不同应用不会发生冲突。
    "RedisCache": {
      "Server": "127.0.0.1:6379",
      //"Password": "PureC0de=8",
      "Instance": "PureCode:Example"
    },
    // 开发时没有 Redis 时使用的文件缓存，不建议部署环境使用，如果和 RedisCache 并存时，只会使用 RedisCache。
    "FileCache": {
      "CacheFolder": "caches"
    }
  },
  // 上传位置配置
  "UploadOptions": {
    // Web 请求的根路径
    "WebRoot": "/uploads",
    // 服务器存储的物理路径
    "Path": "./uploads",
    // 上传文件重命名的方式，重命名不会修改文件扩展名。
    // 支持 'uuid', 'guid', 'md5', 'time'
    "FileNameGenerator": "uuid"
  },
  // 允许访问的域名
  "AllowedHosts": "*"
}
```