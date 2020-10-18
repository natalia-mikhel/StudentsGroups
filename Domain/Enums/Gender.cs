using System.ComponentModel;

namespace Domain.Enums
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female = 2,
    }
}