namespace Silence.SurfaceWater.Extensions;


/// <summary>
/// 水质类别扩展
/// </summary>
public static class WaterQualityClassIntExtension
{
    /// <summary>
    /// int类型转为水质类别描述
    /// </summary>
    /// <param name="waterQualityClass"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string ToWaterQualityClassDescription(this int waterQualityClass)
    {
        return waterQualityClass switch
        {
            1 => "Ⅰ",
            2 => "Ⅱ",
            3 => "Ⅲ",
            4 => "Ⅳ",
            5 => "Ⅴ",
            6 => "劣Ⅴ",
            _ => throw new ArgumentOutOfRangeException(nameof(waterQualityClass), waterQualityClass, null)
        };
    }
}