using Silence.SurfaceWater.Standard;

namespace Silence.SurfaceWater.Core.Validators;

/// <summary>
/// 是否为水质类别指标的验证器
/// 是否为表1中的指标
/// </summary>
public static class WaterQualityClassTable1FactorValidatorV2002
{
    public static bool IsValid(string factorCode)
    {
        var tmp = factorCode.ToLower();
        return tmp == FactorInfo.PH.Code
               || tmp == FactorInfo.DO.Code
               || tmp == FactorInfo.CODMN.Code
               || tmp == FactorInfo.COD.Code
               || tmp == FactorInfo.BOD5.Code
               || tmp == FactorInfo.NH3N.Code
               || tmp == FactorInfo.TP.Code
               || tmp == FactorInfo.TN.Code
               || tmp == FactorInfo.CU.Code
               || tmp == FactorInfo.ZN.Code
               || tmp == FactorInfo.FL.Code
               || tmp == FactorInfo.SE.Code
               || tmp == FactorInfo.AS.Code
               || tmp == FactorInfo.HG.Code
               || tmp == FactorInfo.CD.Code
               || tmp == FactorInfo.CR6.Code
               || tmp == FactorInfo.PB.Code
               || tmp == FactorInfo.CN.Code
               || tmp == FactorInfo.VP.Code
               || tmp == FactorInfo.PETRO.Code
               || tmp == FactorInfo.LAS.Code
               || tmp == FactorInfo.S2.Code
               || tmp == FactorInfo.FC.Code;
    }
}