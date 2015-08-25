using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumLib
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class EnumDisplayName : Attribute
    {
        string m_DisplayName = string.Empty;
        public EnumDisplayName(string DisplayName)
        {
            m_DisplayName = DisplayName;
        }
        public override string ToString()
        {
            return m_DisplayName;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class EnumDBValue : Attribute
    {
        string m_DBValue = string.Empty;
        public EnumDBValue(string DBValue)
        {
            m_DBValue = DBValue;
        }
        public override string ToString()
        {
            return m_DBValue;
        }
    }
}
