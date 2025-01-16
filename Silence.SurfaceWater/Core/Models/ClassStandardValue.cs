using Silence.SurfaceWater.Core.Interfaces;

namespace Silence.SurfaceWater.Core.Models;

/// <summary>
/// 不同水质类别的标准值
/// </summary>
internal class ClassStandardValue : IClassStandardValue
{
    /// <summary>
    /// Ⅰ类
    /// </summary>
    public decimal Class1 { get; init; }

    /// <summary>
    /// Ⅱ类
    /// </summary>
    public decimal Class2 { get;init;  }

    /// <summary>
    /// Ⅲ类
    /// </summary>
    public decimal Class3 { get;init;  }

    /// <summary>
    /// Ⅳ类
    /// </summary>
    public decimal Class4 { get; init; }

    /// <summary>
    /// Ⅴ类
    /// </summary>
    public decimal Class5 { get; init; }
}

