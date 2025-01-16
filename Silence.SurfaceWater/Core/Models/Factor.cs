using Silence.SurfaceWater.Core.Interfaces;

namespace Silence.SurfaceWater.Core.Models;

/// <summary>
/// 指标信息
/// </summary>
internal class Factor : IFactor
{
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; init; } = null!;
    /// <summary>
    /// 指标名
    /// </summary>
    public string Name { get; init; } = null!;
    /// <summary>
    /// 指标类别
    /// </summary>
    public string FactorType { get; init; } = null!;
    /// <summary>
    /// 单位
    /// </summary>
    public string Unit { get; init; } = null!;
    /// <summary>
    /// 数据精度
    /// </summary>
    public IPrecision Precision { get; init; } = null!;
}

