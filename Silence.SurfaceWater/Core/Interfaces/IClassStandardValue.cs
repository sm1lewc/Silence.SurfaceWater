namespace Silence.SurfaceWater.Core.Interfaces;

/// <summary>
/// 不同水质类别的标准值
/// </summary>
public interface IClassStandardValue
{
    /// <summary>
    /// Ⅰ类
    /// </summary>
    decimal Class1 { get; }
    /// <summary>
    /// Ⅱ类
    /// </summary>
    decimal Class2 { get; }
    /// <summary>
    /// Ⅲ类
    /// </summary>
    decimal Class3 { get; }
    /// <summary>
    /// Ⅳ类
    /// </summary>
    decimal Class4 { get; }
    /// <summary>
    /// Ⅴ类
    /// </summary>
    decimal Class5 { get; }
}
