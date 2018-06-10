using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace Logger.Extension
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumerationValue)
        {
            Type type = enumerationValue.GetType();
            MemberInfo member = type.GetMembers().Where(w => w.Name == Enum.GetName(type, enumerationValue)).FirstOrDefault();
            var attribute = member?.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description != null ? attribute.Description : enumerationValue.ToString();
        }
    }
}
