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
            throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "小数位不能为负数");

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

    /// <summary>
    /// 计算PH的均值(氢离子浓度算术平均值的负对数),结果不修约
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static decimal GetPHAvg(List<decimal> values)
    {
        if (values == null || values.Count == 0)
            throw new ArgumentNullException(nameof(values), "该集合为空");
        var tmp = values.Where(x => x > 0).ToList();
        if (tmp.Count == 0)
            throw new ArgumentNullException(nameof(values), "所有值都小于或等于 0");
        // 氢离子浓度集合
        List<double> hValues = [];
        tmp.ForEach(x => hValues.Add(Math.Pow(10, -Convert.ToDouble(x))));
        // 氢离子浓度均值
        var hAvg = hValues.Average();
        // 返回PH值
        return Convert.ToDecimal(-Math.Log10(hAvg));
    }
}