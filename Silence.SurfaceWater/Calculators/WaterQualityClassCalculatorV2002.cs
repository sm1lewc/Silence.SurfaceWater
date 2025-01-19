using System.Diagnostics.CodeAnalysis;
using Silence.SurfaceWater.Core.Validators;
using Silence.SurfaceWater.Standard;

namespace Silence.SurfaceWater.Calculators;

/// <summary>
/// 2002版水质类别计算器
/// </summary>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class WaterQualityClassCalculatorV2002
{
    /// <summary>
    /// 获取pH的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetPHClass(decimal value) => value >= QualityStandardV2002.PH.min && value <= QualityStandardV2002.PH.max ? 1 : 6;


    /// <summary>
    /// 获取溶解氧的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetDOClass(decimal value)
    {
        if (value < QualityStandardV2002.DO.Class5) return 6;
        if (value < QualityStandardV2002.DO.Class4) return 5;
        if (value < QualityStandardV2002.DO.Class3) return 4;
        if (value < QualityStandardV2002.DO.Class2) return 3;
        return value < QualityStandardV2002.DO.Class1 ? 2 : 1;
    }

    /// <summary>
    /// 获取高锰酸盐指数的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetCODMNClass(decimal value) =>  GetFactorClass(FactorInfo.CODMN.Code, value);
  
    /// <summary>
    /// 获取化学需氧量的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetNH3NClass(decimal value) => GetFactorClass(FactorInfo.NH3N.Code, value);

    /// <summary>
    /// 获取总氮的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetTNClass(decimal value) => GetFactorClass(FactorInfo.TN.Code, value);

    /// <summary>
    /// 获取总磷的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isLake"></param>
    /// <returns></returns>
    public static int GetTPClass(decimal value, bool isLake = false) => GetFactorClass(FactorInfo.TP.Code, value, isLake);

    /// <summary>
    /// 获取五日生化需氧量的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetBOD5Class(decimal value) => GetFactorClass(FactorInfo.BOD5.Code, value);

    /// <summary>
    /// 获取化学需氧量的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetCODClass(decimal value) => GetFactorClass(FactorInfo.COD.Code, value);

    /// <summary>
    /// 获取铜的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetCUClass(decimal value) => GetFactorClass(FactorInfo.CU.Code, value);

    /// <summary>
    /// 获取锌的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetZNClass(decimal value) => GetFactorClass(FactorInfo.ZN.Code, value);

    /// <summary>
    /// 获取氟化物的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetFLClass(decimal value) => GetFactorClass(FactorInfo.FL.Code, value);

    /// <summary>
    /// 获取硒的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetSEClass(decimal value) => GetFactorClass(FactorInfo.SE.Code, value);

    /// <summary>
    /// 获取砷的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetASClass(decimal value) => GetFactorClass(FactorInfo.AS.Code, value);

    /// <summary>
    /// 获取汞的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetHGClass(decimal value) => GetFactorClass(FactorInfo.HG.Code, value);

    /// <summary>
    /// 获取镉的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetCDClass(decimal value) => GetFactorClass(FactorInfo.CD.Code, value);

    /// <summary>
    /// 获取六价铬的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetCR6Class(decimal value) => GetFactorClass(FactorInfo.CR6.Code, value);

    /// <summary>
    /// 获取铅的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetPBClass(decimal value) => GetFactorClass(FactorInfo.PB.Code, value);

    /// <summary>
    /// 获取氰化物的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetCNClass(decimal value) => GetFactorClass(FactorInfo.CN.Code, value);

    /// <summary>
    /// 获取挥发酚的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetVPClass(decimal value) => GetFactorClass(FactorInfo.VP.Code, value);

    /// <summary>
    /// 获取石油类的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetPETROClass(decimal value) => GetFactorClass(FactorInfo.PETRO.Code, value);

    /// <summary>
    /// 获取阴离子表面活性剂的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetLASClass(decimal value) => GetFactorClass(FactorInfo.LAS.Code, value);

    /// <summary>
    /// 获取硫化物的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetS2Class(decimal value) => GetFactorClass(FactorInfo.S2.Code, value);

    /// <summary>
    /// 获取粪大肠菌群的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetFCClass(decimal value) => GetFactorClass(FactorInfo.FC.Code, value);

    /// <summary>
    /// 获取指标的水质类别
    /// </summary>
    /// <param name="code"></param>
    /// <param name="value"></param>
    /// <param name="isLake"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int GetFactorClass(string code, decimal value, bool isLake = false)
    {
        if (!WaterQualityClassTable1FactorValidatorV2002.IsValid(code)) throw new ArgumentOutOfRangeException($"{code} 非有效的表1指标编码");

        if (code == FactorInfo.PH.Code)
        {
            return GetPHClass(value);
        }

        if (code == FactorInfo.DO.Code)
        {
            return GetDOClass(value);
        }

        var standardValue = QualityStandardV2002.GetClassStandardValue(code, isLake); //经过校验的code，不用判断是否为null
        if (value <= standardValue.Class1) return 1;
        if (value <= standardValue.Class2) return 2;
        if (value <= standardValue.Class3) return 3;
        if (value <= standardValue.Class4) return 4;
        return value <= standardValue.Class5 ? 5 : 6;
    }


    /*public static WaterQualityClass GetWaterQualityClass(List<(string,decimal,bool)> datas)
    {
        var codes = datas.Select(x => x.Item1).ToList();
        // 判断codes是不是都是有效的表1指标编码
        if (codes.All(Core.Validators.WaterQualityClassFactorValidatorV2002.IsValid))
        {
            var classes = datas.Where(x=>x.Item3).Select(x => GetFactorClass(x.Item1, x.Item2)).ToList();
            return classes.Max();
        }
        else
        {
            throw new ArgumentOutOfRangeException("datas中存在非有效的表1指标编码");
        }
    }*/


    /// <summary>
    /// 获取水质类别评价整体水质类别
    /// </summary>
    /// <param name="phValue"></param>
    /// <param name="doValue"></param>
    /// <param name="codmnValue"></param>
    /// <param name="codValue"></param>
    /// <param name="bod5Value"></param>
    /// <param name="nh3nValue"></param>
    /// <param name="tpValue"></param>
    /// <param name="cuValue"></param>
    /// <param name="znValue"></param>
    /// <param name="flValue"></param>
    /// <param name="seValue"></param>
    /// <param name="asValue"></param>
    /// <param name="hgValue"></param>
    /// <param name="cdValue"></param>
    /// <param name="cr6Value"></param>
    /// <param name="pbValue"></param>
    /// <param name="cnValue"></param>
    /// <param name="vpValue"></param>
    /// <param name="petroValue"></param>
    /// <param name="lasValue"></param>
    /// <param name="s2Value"></param>
    /// <param name="isLake">是否为湖库,默认不是湖库false</param>
    /// <param name="tnValue"></param>
    /// <param name="isCalTn">总氮是否参与水质类别计算</param>
    /// <param name="fcValue"></param>
    /// <param name="isCalfc">粪大肠菌群是否参与水质类别计算</param>
    /// <returns></returns>
    public static int GetWaterQualityClass(decimal phValue,
        decimal doValue,
        decimal codmnValue,
        decimal codValue,
        decimal bod5Value,
        decimal nh3nValue,
        decimal tpValue,
        decimal cuValue,
        decimal znValue,
        decimal flValue,
        decimal seValue,
        decimal asValue,
        decimal hgValue,
        decimal cdValue,
        decimal cr6Value,
        decimal pbValue,
        decimal cnValue,
        decimal vpValue,
        decimal petroValue,
        decimal lasValue,
        decimal s2Value,
        bool isLake = false,
        decimal? tnValue = null,
        bool isCalTn = false,
        decimal? fcValue = null,
        bool isCalfc = false
    )
    {
        var phClass = GetPHClass(phValue);
        var doClass = GetDOClass(doValue);
        var codmnClass = GetCODMNClass(codmnValue);
        var nh3nClass = GetNH3NClass(nh3nValue);
        var tpClass = GetTPClass(tpValue, isLake);
        var bod5Class = GetBOD5Class(bod5Value);
        var codClass = GetCODClass(codValue);
        var cuClass = GetCUClass(cuValue);
        var znClass = GetZNClass(znValue);
        var flClass = GetFLClass(flValue);
        var seClass = GetSEClass(seValue);
        var asClass = GetASClass(asValue);
        var hgClass = GetHGClass(hgValue);
        var cdClass = GetCDClass(cdValue);
        var cr6Class = GetCR6Class(cr6Value);
        var pbClass = GetPBClass(pbValue);
        var cnClass = GetCNClass(cnValue);
        var vpClass = GetVPClass(vpValue);
        var petroClass = GetPETROClass(petroValue);
        var lasClass = GetLASClass(lasValue);
        var s2Class = GetS2Class(s2Value);
        var classes = new List<int>
        {
            phClass, doClass, codmnClass, nh3nClass, tpClass, bod5Class, codClass, cuClass, znClass, flClass, seClass, asClass, hgClass, cdClass, cr6Class, pbClass, cnClass, vpClass, petroClass, lasClass, s2Class
        };
        if (tnValue != null && isCalTn)
        {
            var tnClass = GetTNClass(tnValue.Value);
            classes.Add(tnClass);
        }

        if (fcValue != null && isCalfc)
        {
            var fcClass = GetFCClass(fcValue.Value);
            classes.Add(fcClass);
        }

        return classes.Max();
    }
}