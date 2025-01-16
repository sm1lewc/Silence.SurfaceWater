using System.Diagnostics.CodeAnalysis;
using Silence.SurfaceWater.Core.Enums;

namespace Silence.SurfaceWater.Extensions;

/// <summary>
/// 水质类别扩展
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class WaterQualityClassExtension
{
    /// <summary>
    /// 获取水质类别的描述
    /// </summary>
    /// <param name="waterQualityClass"></param>
    /// <returns></returns>
    public static string ToDescription(this WaterQualityClass waterQualityClass)
    {
        return waterQualityClass switch
        {
            WaterQualityClass.Class1 => "I类",
            WaterQualityClass.Class2 => "II类",
            WaterQualityClass.Class3 => "III类",
            WaterQualityClass.Class4 => "IV类",
            WaterQualityClass.Class5 => "V类",
            WaterQualityClass.Class6 => "劣V类",
            _ => throw new ArgumentOutOfRangeException(nameof(waterQualityClass), waterQualityClass, null)
        };
    }
}