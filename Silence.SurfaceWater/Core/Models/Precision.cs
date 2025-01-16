using Silence.SurfaceWater.Core.Interfaces;

namespace Silence.SurfaceWater.Core.Models;

/// <summary>
/// 数据精度
/// </summary>
internal class Precision : IPrecision
{
    /// <summary>
    /// 小时数据经度
    /// </summary>
    public int HourData { get; init; }
    /// <summary>
    /// 评价数据经度
    /// </summary>
    public int AssessmentData { get; init; }
}
