namespace Silence.SurfaceWater.Core.Interfaces;

/// <summary>
/// 数据精度
/// </summary>
public interface IPrecision
{
    /// <summary>
    /// 小时数据经度
    /// </summary>
    int HourData { get; }

    /// <summary>
    /// 评价数据经度
    /// </summary>
    int AssessmentData { get; }
}

