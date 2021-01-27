using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboxDemo
{
    public enum Gender
    {
        [Description("未知")]
        Unknown,
        [Description("男")]
        Male,
        [Description("女")]
        Female
    }
}
