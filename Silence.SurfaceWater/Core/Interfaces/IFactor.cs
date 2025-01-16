namespace Silence.SurfaceWater.Core.Interfaces;

/// <summary>
/// 指标信息
/// </summary>
public interface IFactor
{ /// <summary>
    /// 编码
    /// </summary>
    string Code { get; }

    /// <summary>
    ///  指标名
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// 指标类别
    /// </summary>
    string FactorType { get; }

    /// <summary>
    /// 单位
    /// </summary>
    string Unit { get; }

    /// <summary>
    /// 数据精度
    /// </summary>
    IPrecision Precision { get; }
}
