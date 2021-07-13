﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Senparc.CO2NET.WebApi
{
    public static class ApiBindExtensions
    {
        /// <summary>
        /// 获取动态程序集的命名空间
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        public static string GetDynamicCategory(this ApiBindAttribute attr, MethodInfo methodInfo)
        {
            string newNameSpace;
            if (!string.IsNullOrEmpty(attr.Category))
            {
                newNameSpace = $"Senparc.DynamicWebApi.{Regex.Replace(attr.Category, @"[\s\.\(\)]", "")}";//TODO:可以换成缓存命名空间等更加特殊的前缀
            }
            else
            {
                newNameSpace = $"Senparc.DynamicWebApi.{methodInfo.DeclaringType.Assembly.GetName().Name}";
            }
            return newNameSpace;
        }


        ///// <summary>
        ///// 获取
        ///// </summary>
        ///// <param name="methodInfo"></param>
        ///// <returns></returns>
        //public string GetCategory(MethodInfo methodInfo)
        //{
        //    return Category ?? $"{methodInfo.DeclaringType.Namespace}";
        //}
    }
}
