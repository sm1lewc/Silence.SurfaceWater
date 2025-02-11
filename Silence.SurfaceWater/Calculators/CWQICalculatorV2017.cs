using System.Diagnostics.CodeAnalysis;
using Silence.SurfaceWater.Core.Enums;
using Silence.SurfaceWater.Core.Interfaces;
using Silence.SurfaceWater.Core.Models;
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

        if (!WaterQualityClassTable1FactorValidatorV2002.IsValid(factorCode)) throw new ArgumentOutOfRangeException($"{factorCode} 非有效的CWQI指标编码");
        if (factorCode.Equals(FactorInfo.TN.Code, StringComparison.CurrentCultureIgnoreCase) || factorCode.Equals(FactorInfo.FC.Code, StringComparison.CurrentCultureIgnoreCase))
            throw new ArgumentOutOfRangeException($"{factorCode} 非有效的CWQI指标编码");
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
        var class3Value = QualityStandardV2002.GetClassStandardValue(factor.Code, isLake).Class3;
        return value / class3Value;
    }

    /// <summary>
    /// 计算21项指标的CWQI之和,返回值不修约
    /// </summary>
    /// <param name="ph"></param>
    /// <param name="do"></param>
    /// <param name="codmn"></param>
    /// <param name="cod"></param>
    /// <param name="bod5"></param>
    /// <param name="nh3n"></param>
    /// <param name="tp"></param>
    /// <param name="cu"></param>
    /// <param name="zn"></param>
    /// <param name="fl"></param>
    /// <param name="se"></param>
    /// <param name="as"></param>
    /// <param name="hg"></param>
    /// <param name="cd"></param>
    /// <param name="cr6"></param>
    /// <param name="pb"></param>
    /// <param name="cn"></param>
    /// <param name="vp"></param>
    /// <param name="petro"></param>
    /// <param name="las"></param>
    /// <param name="s2"></param>
    /// <param name="isLake"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    public static decimal? GetTotalCwqi(decimal? ph,
        decimal? @do,
        decimal? codmn,
        decimal? cod,
        decimal? bod5,
        decimal? nh3n,
        decimal? tp,
        decimal? cu,
        decimal? zn,
        decimal? fl,
        decimal? se,
        decimal? @as,
        decimal? hg,
        decimal? cd,
        decimal? cr6,
        decimal? pb,
        decimal? cn,
        decimal? vp,
        decimal? petro,
        decimal? las,
        decimal? s2,
        bool isLake = false,
        GB3838Version version = GB3838Version.V2002)
    {
        var cwqiList = new List<decimal?>
        {
            ph.HasValue ? GetPHCwqi(ph.Value, version) : null,
            @do.HasValue ? GetDOCwqi(@do.Value, version) : null,
            codmn.HasValue ? GetCODMNCwqi(codmn.Value, version) : null,
            cod.HasValue ? GetCODCwqi(cod.Value, version) : null,
            bod5.HasValue ? GetBOD5Cwqi(bod5.Value, version) : null,
            nh3n.HasValue ? GetNH3NCwqi(nh3n.Value, version) : null,
            tp.HasValue ? GetTPCwqi(tp.Value, isLake, version) : null,
            cu.HasValue ? GetCUCwqi(cu.Value, version) : null,
            zn.HasValue ? GetZNCwqi(zn.Value, version) : null,
            fl.HasValue ? GetFLCwqi(fl.Value, version) : null,
            se.HasValue ? GetSECwqi(se.Value, version) : null,
            @as.HasValue ? GetASCwqi(@as.Value, version) : null,
            hg.HasValue ? GetHGCwqi(hg.Value, version) : null,
            cd.HasValue ? GetCDCwqi(cd.Value, version) : null,
            cr6.HasValue ? GetCR6Cwqi(cr6.Value, version) : null,
            pb.HasValue ? GetPBCwqi(pb.Value, version) : null,
            cn.HasValue ? GetCNCwqi(cn.Value, version) : null,
            vp.HasValue ? GetVPCwqi(vp.Value, version) : null,
            petro.HasValue ? GetPETROCwqi(petro.Value, version) : null,
            las.HasValue ? GetLASCwqi(las.Value, version) : null,
            s2.HasValue ? GetS2Cwqi(s2.Value, version) : null
        };
        return cwqiList.Sum();
    }

    /// <summary>
    /// 计算21项指标的CWQI,返回值不修约
    /// </summary>
    /// <param name="ph"></param>
    /// <param name="do"></param>
    /// <param name="codmn"></param>
    /// <param name="cod"></param>
    /// <param name="bod5"></param>
    /// <param name="nh3n"></param>
    /// <param name="tp"></param>
    /// <param name="cu"></param>
    /// <param name="zn"></param>
    /// <param name="fl"></param>
    /// <param name="se"></param>
    /// <param name="as"></param>
    /// <param name="hg"></param>
    /// <param name="cd"></param>
    /// <param name="cr6"></param>
    /// <param name="pb"></param>
    /// <param name="cn"></param>
    /// <param name="vp"></param>
    /// <param name="petro"></param>
    /// <param name="las"></param>
    /// <param name="s2"></param>
    /// <param name="isLake"></param>
    /// <param name="version"></param>
    /// <returns>(cwqi之和，ICwqi集合)</returns>
    public static (decimal? total, List<ICwqi>) GetIndividualCwqi(decimal? ph,
        decimal? @do,
        decimal? codmn,
        decimal? cod,
        decimal? bod5,
        decimal? nh3n,
        decimal? tp,
        decimal? cu,
        decimal? zn,
        decimal? fl,
        decimal? se,
        decimal? @as,
        decimal? hg,
        decimal? cd,
        decimal? cr6,
        decimal? pb,
        decimal? cn,
        decimal? vp,
        decimal? petro,
        decimal? las,
        decimal? s2,
        bool isLake = false,
        GB3838Version version = GB3838Version.V2002)
    {
        List<ICwqi> list =
        [
            new Cwqi() { FactroCode = FactorInfo.PH.Code, FactorValue = ph, FactorName = FactorInfo.PH.Name, FactorCwqi = ph.HasValue ? GetPHCwqi(ph.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.DO.Code, FactorValue = @do, FactorName = FactorInfo.DO.Name, FactorCwqi = @do.HasValue ? GetDOCwqi(@do.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.CODMN.Code, FactorValue = codmn, FactorName = FactorInfo.CODMN.Name, FactorCwqi = codmn.HasValue ? GetCODMNCwqi(codmn.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.COD.Code, FactorValue = cod, FactorName = FactorInfo.COD.Name, FactorCwqi = cod.HasValue ? GetCODCwqi(cod.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.BOD5.Code, FactorValue = bod5, FactorName = FactorInfo.BOD5.Name, FactorCwqi = bod5.HasValue ? GetBOD5Cwqi(bod5.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.NH3N.Code, FactorValue = nh3n, FactorName = FactorInfo.NH3N.Name, FactorCwqi = nh3n.HasValue ? GetNH3NCwqi(nh3n.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.TP.Code, FactorValue = tp, FactorName = FactorInfo.TP.Name, FactorCwqi = tp.HasValue ? GetTPCwqi(tp.Value, isLake, version) : null },
            new Cwqi() { FactroCode = FactorInfo.CU.Code, FactorValue = cu, FactorName = FactorInfo.CU.Name, FactorCwqi = cu.HasValue ? GetCUCwqi(cu.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.ZN.Code, FactorValue = zn, FactorName = FactorInfo.ZN.Name, FactorCwqi = zn.HasValue ? GetZNCwqi(zn.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.FL.Code, FactorValue = fl, FactorName = FactorInfo.FL.Name, FactorCwqi = fl.HasValue ? GetFLCwqi(fl.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.SE.Code, FactorValue = se, FactorName = FactorInfo.SE.Name, FactorCwqi = se.HasValue ? GetSECwqi(se.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.AS.Code, FactorValue = @as, FactorName = FactorInfo.AS.Name, FactorCwqi = @as.HasValue ? GetASCwqi(@as.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.HG.Code, FactorValue = hg, FactorName = FactorInfo.HG.Name, FactorCwqi = hg.HasValue ? GetHGCwqi(hg.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.CD.Code, FactorValue = cd, FactorName = FactorInfo.CD.Name, FactorCwqi = cd.HasValue ? GetCDCwqi(cd.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.CR6.Code, FactorValue = cr6, FactorName = FactorInfo.CR6.Name, FactorCwqi = cr6.HasValue ? GetCR6Cwqi(cr6.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.PB.Code, FactorValue = pb, FactorName = FactorInfo.PB.Name, FactorCwqi = pb.HasValue ? GetPBCwqi(pb.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.CN.Code, FactorValue = cn, FactorName = FactorInfo.CN.Name, FactorCwqi = cn.HasValue ? GetCNCwqi(cn.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.VP.Code, FactorValue = vp, FactorName = FactorInfo.VP.Name, FactorCwqi = vp.HasValue ? GetVPCwqi(vp.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.PETRO.Code, FactorValue = petro, FactorName = FactorInfo.PETRO.Name, FactorCwqi = petro.HasValue ? GetPETROCwqi(petro.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.LAS.Code, FactorValue = las, FactorName = FactorInfo.LAS.Name, FactorCwqi = las.HasValue ? GetLASCwqi(las.Value, version) : null },
            new Cwqi() { FactroCode = FactorInfo.S2.Code, FactorValue = s2, FactorName = FactorInfo.S2.Name, FactorCwqi = s2.HasValue ? GetS2Cwqi(s2.Value, version) : null }
        ];
        var total = list.Select(x => x.FactorCwqi).Sum();
        return (total, list);
    }
}