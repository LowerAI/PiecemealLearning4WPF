using System.ComponentModel;

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
