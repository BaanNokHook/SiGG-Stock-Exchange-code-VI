using System;

namespace SiGGTransactionFinancialVI.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeFromInsert : Attribute
    {

    }
}