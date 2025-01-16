using Silence.SurfaceWater.Core.Interfaces;

namespace Silence.SurfaceWater.Core.Models;

/// <summary>
/// 标准值
/// </summary>
internal class StandardValue : IStandardValue
{
    /// <summary>
    /// 标准值
    /// </summary>
    public decimal Value { get; init; }
}