﻿using System;
using System.Linq;
using System.Reflection;
using SiGGTransactionFinancialVI.Common.Attributes;

namespace SiGGTransactionFinancialVI.Common.Extensions
{
    public static class TypeExtension
    {

        public static PropertyInfo[] GetInsertableProperties(this Type objectType)
        {
            return objectType.GetProperties()
                             .Where(p =>
                                        p.CustomAttributes
                                         .All(a => a.AttributeType != typeof(ExcludeFromInsert)))
                             .ToArray();
        }
        
        public static PropertyInfo[] GetUpdatableProperties(this Type objectType)
        {
            return objectType.GetProperties()
                             .Where(p =>
                                        p.CustomAttributes
                                         .All(a => a.AttributeType != typeof(ExcludeFromUpdate)))
                             .ToArray();
        }

    }
}