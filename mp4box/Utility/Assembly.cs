using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.Utility
{
    public static class Assembly
    {
        public static DateTime GetAssemblyVersionTime()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
        }

        public static string GetAssemblyFileVersion()
        {
            return GetAssembly(typeof(System.Reflection.AssemblyInformationalVersionAttribute));
        }

        /// <summary>
        /// 获取程序集项目属性内容
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetAssembly(Type type)
        {
            if (type.ToString() == "System.Reflection.AssemblyVersionAttribute")
            {//程序集版本号，要用这个方法获取，无法用下边的方法获取，原因不知
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            object[] attributes = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(type, false);
            if (attributes.Length > 0)
            {
                if (type.ToString() == "System.Reflection.AssemblyCompanyAttribute")
                {
                    #region//公司
                    System.Reflection.AssemblyCompanyAttribute company = (System.Reflection.AssemblyCompanyAttribute)attributes[0];
                    if (company.Company != "")
                    {
                        return company.Company;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyCopyrightAttribute")
                {
                    #region//版权
                    System.Reflection.AssemblyCopyrightAttribute company = (System.Reflection.AssemblyCopyrightAttribute)attributes[0];
                    if (company.Copyright != "")
                    {
                        return company.Copyright;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyTitleAttribute")
                {
                    #region//标题
                    System.Reflection.AssemblyTitleAttribute company = (System.Reflection.AssemblyTitleAttribute)attributes[0];
                    if (company.Title != "")
                    {
                        return company.Title;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyDescriptionAttribute")
                {
                    #region//备注
                    System.Reflection.AssemblyDescriptionAttribute company = (System.Reflection.AssemblyDescriptionAttribute)attributes[0];
                    if (company.Description != "")
                    {
                        return company.Description;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyProductAttribute")
                {
                    #region//产品名称
                    System.Reflection.AssemblyProductAttribute company = (System.Reflection.AssemblyProductAttribute)attributes[0];
                    if (company.Product != "")
                    {
                        return company.Product;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyTrademarkAttribute")
                {
                    #region//商标
                    System.Reflection.AssemblyTrademarkAttribute company = (System.Reflection.AssemblyTrademarkAttribute)attributes[0];
                    if (company.Trademark != "")
                    {
                        return company.Trademark;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyConfigurationAttribute")
                {
                    #region//获取程序集配置信息，具体什么内容，不清楚
                    System.Reflection.AssemblyConfigurationAttribute company = (System.Reflection.AssemblyConfigurationAttribute)attributes[0];
                    if (company.Configuration != "")
                    {
                        return company.Configuration;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyCultureAttribute")
                {
                    #region//获取属性化程序集支持的区域性，具体什么内容，不清楚
                    System.Reflection.AssemblyCultureAttribute company = (System.Reflection.AssemblyCultureAttribute)attributes[0];
                    if (company.Culture != "")
                    {
                        return company.Culture;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyVersionAttribute")
                {
                    #region//程序集版本号
                    System.Reflection.AssemblyVersionAttribute company = (System.Reflection.AssemblyVersionAttribute)attributes[0];
                    if (company.Version != "")
                    {
                        return company.Version;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyFileVersionAttribute")
                {
                    #region//文件版本号
                    System.Reflection.AssemblyFileVersionAttribute company = (System.Reflection.AssemblyFileVersionAttribute)attributes[0];
                    if (company.Version != "")
                    {
                        return company.Version;
                    }
                    #endregion
                }
                else if (type.ToString() == "System.Reflection.AssemblyInformationalVersionAttribute")
                {
                    #region//产品版本号
                    System.Reflection.AssemblyInformationalVersionAttribute company = (System.Reflection.AssemblyInformationalVersionAttribute)attributes[0];
                    if (company.InformationalVersion != "")
                    {
                        return company.InformationalVersion;
                    }
                    #endregion
                }
            }
            //如果没有  属性，或者  属性为一个空字符串，则返回 .exe 的名称  
            return System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }

    }
}
