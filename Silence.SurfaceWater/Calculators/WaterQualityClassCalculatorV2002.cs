using System.Diagnostics.CodeAnalysis;
using Silence.SurfaceWater.Core.Enums;
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
    public static WaterQualityClass GetPHClass(decimal value)
    {
        return value >= QualityStandardV2002.PH.min && value <= QualityStandardV2002.PH.max ? WaterQualityClass.Class1 : WaterQualityClass.Class6;
    }

    /// <summary>
    /// 获取溶解氧的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetDOClass(decimal value)
    {
        if (value < QualityStandardV2002.DO.Class5) return WaterQualityClass.Class6;
        if (value < QualityStandardV2002.DO.Class4) return WaterQualityClass.Class5;
        if (value < QualityStandardV2002.DO.Class3) return WaterQualityClass.Class4;
        if (value < QualityStandardV2002.DO.Class2) return WaterQualityClass.Class3;
        return value < QualityStandardV2002.DO.Class1 ? WaterQualityClass.Class2 : WaterQualityClass.Class1;
    }

    /// <summary>
    /// 获取高锰酸盐指数的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetCODMNClass(decimal value)
    {
        return GetFactorClass(FactorInfo.CODMN.Code, value);
    }
     
    /// <summary>
    /// 获取化学需氧量的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetNH3NClass(decimal value)
    {
        return GetFactorClass(FactorInfo.NH3N.Code, value);
    }
    
    /// <summary>
    /// 获取总氮的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetTNClass(decimal value)
    {
        return GetFactorClass(FactorInfo.TN.Code, value);
    }
    
    /// <summary>
    /// 获取总磷的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isLake"></param>
    /// <returns></returns>
    public static WaterQualityClass GetTPClass(decimal value,bool isLake = false)
    {
        return GetFactorClass(FactorInfo.TP.Code, value,isLake);
    }
    
    /// <summary>
    /// 获取五日生化需氧量的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetBOD5Class(decimal value)
    {
        return GetFactorClass(FactorInfo.BOD5.Code, value);
    }
    
    /// <summary>
    /// 获取化学需氧量的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetCODClass(decimal value)
    {
        return GetFactorClass(FactorInfo.COD.Code, value);
    }
    
    /// <summary>
    /// 获取铜的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetCUClass(decimal value)
    {
        return GetFactorClass(FactorInfo.CU.Code, value);
    }
    
    /// <summary>
    /// 获取锌的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetZNClass(decimal value)
    {
        return GetFactorClass(FactorInfo.ZN.Code, value);
    }
    
    /// <summary>
    /// 获取氟化物的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetFLClass(decimal value)
    {
        return GetFactorClass(FactorInfo.FL.Code, value);
    }
    
    /// <summary>
    /// 获取硒的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetSEClass(decimal value)
    {
        return GetFactorClass(FactorInfo.SE.Code, value);
    }
    
    /// <summary>
    /// 获取砷的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetASClass(decimal value)
    {
        return GetFactorClass(FactorInfo.AS.Code, value);
    }
    
    /// <summary>
    /// 获取汞的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetHGClass(decimal value)
    {
        return GetFactorClass(FactorInfo.HG.Code, value);
    }
    
    /// <summary>
    /// 获取镉的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetCDClass(decimal value)
    {
        return GetFactorClass(FactorInfo.CD.Code, value);
    }
    
    /// <summary>
    /// 获取六价铬的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetCR6Class(decimal value)
    {
        return GetFactorClass(FactorInfo.CR6.Code, value);
    }
    
    /// <summary>
    /// 获取铅的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetPBClass(decimal value)
    {
        return GetFactorClass(FactorInfo.PB.Code, value);
    }
    
    /// <summary>
    /// 获取氰化物的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetCNClass(decimal value)
    {
        return GetFactorClass(FactorInfo.CN.Code, value);
    }
    
    /// <summary>
    /// 获取挥发酚的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetVPClass(decimal value)
    {
        return GetFactorClass(FactorInfo.VP.Code, value);
    }
    
    /// <summary>
    /// 获取石油类的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetPETROClass(decimal value)
    {
        return GetFactorClass(FactorInfo.PETRO.Code, value);
    }
    
    /// <summary>
    /// 获取阴离子表面活性剂的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetLASClass(decimal value)
    {
        return GetFactorClass(FactorInfo.LAS.Code, value);
    }
    
    /// <summary>
    /// 获取硫化物的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetS2Class(decimal value)
    {
        return GetFactorClass(FactorInfo.S2.Code, value);
    }
    
    /// <summary>
    /// 获取粪大肠菌群的水质类别
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static WaterQualityClass GetFCClass(decimal value)
    {
        return GetFactorClass(FactorInfo.FC.Code, value);
    }

    /// <summary>
    /// 获取指标的水质类别
    /// </summary>
    /// <param name="code"></param>
    /// <param name="value"></param>
    /// <param name="isLake"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static WaterQualityClass GetFactorClass(string code, decimal value, bool isLake = false)
    {
        if (!WaterQualityClassFactorValidatorV2002.IsValid(code)) throw new ArgumentOutOfRangeException($"{code} 非有效的表1指标编码");
        if (code == FactorInfo.PH.Code)
        {
            return GetPHClass(value);
        }

        if (code == FactorInfo.DO.Code)
        {
            return GetDOClass(value);
        }

        var standardValue = QualityStandardV2002.GetClassStandardValue(code, isLake); //经过校验的code，不用判断是否为null
        if (value <= standardValue!.Class1) return WaterQualityClass.Class1;
        if (value <= standardValue.Class2) return WaterQualityClass.Class2;
        if (value <= standardValue.Class3) return WaterQualityClass.Class3;
        if (value <= standardValue.Class4) return WaterQualityClass.Class4;
        return value <= standardValue.Class5 ? WaterQualityClass.Class5 : WaterQualityClass.Class6;
    }
}