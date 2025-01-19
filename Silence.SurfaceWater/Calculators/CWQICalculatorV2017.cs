using System.Diagnostics.CodeAnalysis;
using Silence.SurfaceWater.Core.Enums;
using Silence.SurfaceWater.Core.Interfaces;
using Silence.SurfaceWater.Core.Validators;
using Silence.SurfaceWater.Standard;

namespace Silence.SurfaceWater.Calculators;

/// <summary>
/// CWQI计算
/// 2017年《城市地表水环境质量排名技术规定》
/// </summary>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class CWQICalculatorV2017
{
    /// <summary>
    /// 获取pH的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns>不修约</returns>
    public static decimal GetPHCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        FactorValueValidator.ValidatePH(value);
        return value <= 7 ? 7 - value : (value - 7) / 2;
    }

    /// <summary>
    /// 获取溶解氧的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetDOCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        FactorValueValidator.ValidateOtherFactor(value, FactorInfo.DO.Name);
        return QualityStandardV2002.DO.Class3 / value;
    }

    /// <summary>
    /// 获取CODMn的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetCODMNCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.CODMN, false, version);
    }

    /// <summary>
    /// 获取化学需氧量的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetCODCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.COD, false, version);
    }

    /// <summary>
    /// 获取五日生化需氧量的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetBOD5Cwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.BOD5, false, version);
    }

    /// <summary>
    /// 获取氨氮的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetNH3NCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.NH3N, false, version);
    }

    /// <summary>
    /// 获取总磷的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isLake"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetTPCwqi(decimal value, bool isLake = false, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.TP, isLake, version);
    }

    /// <summary>
    /// 获取总氮的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetTNCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.TN, false, version);
    }

    /// <summary>
    /// 获取铜的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetCUCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.CU, false, version);
    }

    /// <summary>
    /// 获取锌的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetZNCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.ZN, false, version);
    }

    /// <summary>
    /// 获取氟化物的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetFLCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.FL, false, version);
    }

    /// <summary>
    /// 获取硒的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetSECwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.SE, false, version);
    }

    /// <summary>
    /// 获取砷的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetASCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.AS, false, version);
    }

    /// <summary>
    /// 获取汞的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetHGCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.HG, false, version);
    }

    /// <summary>
    /// 获取镉的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetCDCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.CD, false, version);
    }

    /// <summary>
    /// 获取六价铬的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetCR6Cwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.CR6, false, version);
    }

    /// <summary>
    /// 获取铅的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetPBCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.PB, false, version);
    }

    /// <summary>
    /// 获取氰化物的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetCNCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.CN, false, version);
    }

    /// <summary>
    /// 获取挥发酚的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetVPCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.VP, false, version);
    }

    /// <summary>
    /// 获取石油类的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetPETROCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.PETRO, false, version);
    }

    /// <summary>
    /// 获取阴离子表面活性剂的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetLASCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.LAS, false, version);
    }

    /// <summary>
    /// 获取硫化物的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetS2Cwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.S2, false, version);
    }

    /// <summary>
    /// 获取粪大肠菌群的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetFCCwqi(decimal value, GB3838Version version = GB3838Version.V2002)
    {
        return GetOtherCwqi(value, FactorInfo.FC, false, version);
    }


    /// <summary>
    /// 获取指标的CWQI,返回值不修约
    /// </summary>
    /// <param name="value"></param>
    /// <param name="factorCode"></param>
    /// <param name="isLake"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal GetFactorCwqi(decimal value, string factorCode, bool isLake = false, GB3838Version version = GB3838Version.V2002)
    {
        if (factorCode.Equals(FactorInfo.PH.Code, StringComparison.CurrentCultureIgnoreCase)) return GetPHCwqi(value, version);

        if (factorCode.Equals(FactorInfo.DO.Code, StringComparison.CurrentCultureIgnoreCase)) return GetDOCwqi(value, version);

        if (!WaterQualityClassTable1FactorValidatorV2002.IsValid(factorCode)) throw new ArgumentOutOfRangeException($"{factorCode} 非有效的表1指标编码");
        return GetOtherCwqi(value, FactorInfo.GetFactorInfo(factorCode)!, isLake, version);
    }

    /// <summary>
    /// 其他指标的CWQI
    /// </summary>
    /// <param name="value"></param>
    /// <param name="factor"></param>
    /// <param name="isLake"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    private static decimal GetOtherCwqi(decimal value, IFactor factor, bool isLake = false, GB3838Version version = GB3838Version.V2002)
    {
        FactorValueValidator.ValidateOtherFactor(value, factor.Name);
        var standard3Value = QualityStandardV2002.GetClassStandardValue(factor.Code, isLake).Class3;
        return value / standard3Value;
    }
}