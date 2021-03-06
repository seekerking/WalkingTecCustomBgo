﻿using System;
using System.Linq;
using AppSys.Framework.Validator;
using Microsoft.AspNetCore.Http;

namespace AppSys.Framework
{
    public static class HttpContextExtension
    {
        private static IpValidator ipValidator = new IpValidator();
        public static string GetClientIP(this HttpContext context)
        {
            string ip = string.Empty;            
            if (context.Request.Headers.TryGetValue("x-forwarded-for", out var xff))
            {
                ip = xff.FirstOrDefault().Split(',')[0];
            }
            else
            {
                ip = context.Connection.RemoteIpAddress?.ToString().Split(',')[0];
            }

            if ("::1".Equals(ip))
                return "127.0.0.1";
            if (!ipValidator.Verify(ip.Trim()))
                throw new Exception($"客户端IP地址格式错误({ip})");
            return ip;
        }
        /// <summary>
        /// 获取默认hashvalue
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetHashValue(this HttpContext context)
        {
            //TODO 先根据路径、查询字符串、方法简单处理，待优化
            return (context.Request.Path + context.Request.QueryString.Value + context.Request.Method).GetHashCode().ToString();
        }
        /// <summary>
        /// 获取服务器ip
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetServerIp(this HttpContext context)
        {
            string serverIp = context.Connection?.LocalIpAddress?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(serverIp))
            {
                serverIp = context.Request.Host.Host;
            }
            return serverIp;
        }
    }
}
