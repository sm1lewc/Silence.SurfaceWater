namespace Silence.SurfaceWater.Calculators;

/// <summary>
/// 数据计算辅助类
/// </summary>
public static class MathUtility
{
    /// <summary>
    /// 四舍六入五成双
    /// 当修约后结果为 0 时，保留一位有效数字
    /// </summary>
    /// <param name="value"></param>
    /// <param name="decimalPlaces"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static decimal BankersRound(decimal value, int decimalPlaces)
    {
        if (decimalPlaces < 0)
            throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Decimal places cannot be negative.");
        
        if (value == 0) return 0;
    
        // 第一位非零数字的位置
        var firstNonZeroDigitPosition = 0;
        var tmp = Math.Abs(value);
    
        while (tmp < 1 && firstNonZeroDigitPosition < 28) // 添加上限检查
        {
            tmp *= 10;
            firstNonZeroDigitPosition++;
        }
    
        decimalPlaces = Math.Max(decimalPlaces, firstNonZeroDigitPosition);
        return Math.Round(value, decimalPlaces, MidpointRounding.ToEven);
    }
}