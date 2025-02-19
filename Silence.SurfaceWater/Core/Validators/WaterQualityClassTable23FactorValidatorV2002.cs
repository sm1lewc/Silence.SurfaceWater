using Silence.SurfaceWater.Standard;

namespace Silence.SurfaceWater.Core.Validators;
/// <summary>
/// gb3838 表2 3的指标验证器
/// </summary>
public static class WaterQualityClassTable23FactorValidatorV2002
{
    public static bool IsValid(string factorCode)
    {
        //TODO 丰富表2 3的指标
        var tmp = factorCode.ToLower();
        return tmp == FactorInfo.Mn.Code
               || tmp == FactorInfo.Fe.Code
               || tmp == FactorInfo.Mo.Code
               || tmp == FactorInfo.Co.Code
               || tmp == FactorInfo.Be.Code
               || tmp == FactorInfo.B.Code
               || tmp == FactorInfo.Sb.Code
               || tmp == FactorInfo.Ni.Code
               || tmp == FactorInfo.Ba.Code
               || tmp == FactorInfo.V.Code
               || tmp == FactorInfo.Ti.Code
               || tmp == FactorInfo.Tl.Code;
    }
}
