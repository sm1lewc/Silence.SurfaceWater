namespace Silence.SurfaceWater.Extensions;

/// <summary>
/// 枚举的扩展
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// 将整数转换为枚举
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static TEnum ToEnum<TEnum>(this int value) where TEnum : struct, Enum
    {
        if (Enum.IsDefined(typeof(TEnum), value))
        {
            return (TEnum)(object)value;
        }
        throw new ArgumentException($"Invalid value for enum {typeof(TEnum).Name}: {value}");
    }
}