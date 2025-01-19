namespace Silence.SurfaceWater.Core.Validators;

/// <summary>
/// 指标值验证器
/// </summary>
public static class FactorValueValidator
{
    /// <summary>
    /// 验证pH值
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ValidatePH(decimal value)
    {
        if (value < 0 || value > 14) throw new ArgumentOutOfRangeException(nameof(value), "pH值应在0-14之间");
    }

    /// <summary>
    /// 验证其他指标
    /// </summary>
    /// <param name="value"></param>
    /// <param name="name"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ValidateOtherFactor(decimal value, string name)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), $"{name}值不能小于0");
    }
}