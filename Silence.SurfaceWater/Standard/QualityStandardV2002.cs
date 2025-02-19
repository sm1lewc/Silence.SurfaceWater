using System.Diagnostics.CodeAnalysis;
using Silence.SurfaceWater.Core.Interfaces;
using Silence.SurfaceWater.Core.Models;
using Silence.SurfaceWater.Core.Validators;

namespace Silence.SurfaceWater.Standard;

/// <summary>
/// 水质标准
/// </summary>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class QualityStandardV2002
{
    /// <summary>
    /// 不同水质类别的标准值
    /// </summary>
    private static readonly IReadOnlyDictionary<string, IClassStandardValue> _ClassStandardValues;

    /// <summary>
    /// 标准值
    /// </summary>
    private static readonly IReadOnlyDictionary<string, IStandardValue> _StandardValues;

    /// <summary>
    /// 
    /// </summary>
    static QualityStandardV2002()
    {
        _ClassStandardValues = new Dictionary<string, IClassStandardValue>
        {
            [FactorInfo.DO.Code] = DO,
            [FactorInfo.CODMN.Code] = CODMN,
            [FactorInfo.COD.Code] = COD,
            [FactorInfo.BOD5.Code] = BOD5,
            [FactorInfo.NH3N.Code] = NH3N,
            [FactorInfo.TN.Code] = TN,
            [FactorInfo.CU.Code] = CU,
            [FactorInfo.ZN.Code] = ZN,
            [FactorInfo.FL.Code] = FL,
            [FactorInfo.SE.Code] = SE,
            [FactorInfo.AS.Code] = AS,
            [FactorInfo.HG.Code] = HG,
            [FactorInfo.CD.Code] = CD,
            [FactorInfo.CR6.Code] = CR6,
            [FactorInfo.PB.Code] = PB,
            [FactorInfo.CN.Code] = CN,
            [FactorInfo.VP.Code] = VP,
            [FactorInfo.PETRO.Code] = PETRO,
            [FactorInfo.LAS.Code] = LAS,
            [FactorInfo.S2.Code] = S2,
            [FactorInfo.FC.Code] = FC
        };
        _StandardValues = new Dictionary<string, IStandardValue>
        {
            [FactorInfo.Mn.Code] = MN,
            [FactorInfo.Fe.Code] = FE,
            [FactorInfo.Mo.Code] = Mo,
            [FactorInfo.Co.Code] = Co,
            [FactorInfo.Be.Code] = Be,
            [FactorInfo.B.Code] = B,
            [FactorInfo.Sb.Code] = Sb,
            [FactorInfo.Ni.Code] = Ni,
            [FactorInfo.Ba.Code] = Ba,
            [FactorInfo.V.Code] = V,
            [FactorInfo.Ti.Code] = Ti,
            [FactorInfo.Tl.Code] = Tl

        };
    }

    /// <summary>
    /// 获取不同水质类别的标准值
    /// 仅限表1且不包含水温、pH
    /// </summary>
    /// <param name="factorCode"></param>
    /// <param name="isLake"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <returns></returns>
    public static IClassStandardValue GetClassStandardValue(string factorCode, bool isLake = false)
    {
        var code = factorCode.ToLower();
        if (!WaterQualityClassTable1FactorValidatorV2002.IsValid(code))
            throw new ArgumentOutOfRangeException($"{factorCode} 非有效的表1指标编码");
        if (code == FactorInfo.TP.Code)
        {
            return isLake ? TP_Lake : TP_River;
        }

        return _ClassStandardValues[code];
    }

    /// <summary>
    /// 获取指标某个水质的标准值
    /// </summary>
    /// <param name="factorCode"></param>
    /// <param name="waterQualityClass"></param>
    /// <param name="isLake"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static decimal GetClassStandardValueByClass(string factorCode, int waterQualityClass, bool isLake = false)
    {
        var code = factorCode.ToLower();
        if (!WaterQualityClassTable1FactorValidatorV2002.IsValid(code))
            throw new ArgumentOutOfRangeException($"{factorCode} 非有效的表1指标编码");
        if (waterQualityClass < 1 || waterQualityClass > 5)
            throw new ArgumentOutOfRangeException($"{waterQualityClass} 非有效的水质类别");
        IClassStandardValue tmp;
        if (code == FactorInfo.TP.Code)
        {
            tmp = isLake ? TP_Lake : TP_River;
        }
        else
        {
            tmp = _ClassStandardValues[code];
        }

        return waterQualityClass switch
        {
            1 => tmp.Class1,
            2 => tmp.Class2,
            3 => tmp.Class3,
            4 => tmp.Class4,
            5 => tmp.Class5,
            _ => throw new ArgumentOutOfRangeException(nameof(waterQualityClass), waterQualityClass, null)
        };
    }


    /// <summary>
    /// 获取标准值
    /// 表2、表3
    /// </summary>
    /// <param name="factorCode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static decimal GetStandardValue(string factorCode)
    {
        if (!WaterQualityClassTable23FactorValidatorV2002.IsValid(factorCode))
            throw new ArgumentOutOfRangeException($"{factorCode} 非有效的表2、表3指标编码");
        return _StandardValues[factorCode].Value;
    }

    /// <summary>
    /// pH范围
    /// </summary>
    public static readonly (decimal min, decimal max) PH = (6, 9);


    /// <summary>
    /// 溶解氧
    /// </summary>
    public static readonly IClassStandardValue DO = new ClassStandardValue
    {
        Class1 = 7.5m,
        Class2 = 6m,
        Class3 = 5m,
        Class4 = 3m,
        Class5 = 2m
    };

    /// <summary>
    /// 高锰酸盐指数 (mg/L)
    /// </summary>
    public static readonly IClassStandardValue CODMN = new ClassStandardValue
    {
        Class1 = 2,
        Class2 = 4,
        Class3 = 6,
        Class4 = 10,
        Class5 = 15
    };

    /// <summary>
    /// 化学需氧量(COD) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue COD = new ClassStandardValue
    {
        Class1 = 15,
        Class2 = 15,
        Class3 = 20,
        Class4 = 30,
        Class5 = 40
    };

    /// <summary>
    /// 五日生化需氧量(BOD5) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue BOD5 = new ClassStandardValue
    {
        Class1 = 3,
        Class2 = 3,
        Class3 = 4,
        Class4 = 6,
        Class5 = 10
    };

    /// <summary>
    /// 氨氮(NH3-N) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue NH3N = new ClassStandardValue
    {
        Class1 = 0.15m,
        Class2 = 0.5m,
        Class3 = 1.0m,
        Class4 = 1.5m,
        Class5 = 2.0m
    };

    /// <summary>
    /// 总磷(以P计) (mg/L) - 湖、库
    /// </summary>
    public static readonly IClassStandardValue TP_Lake = new ClassStandardValue
    {
        Class1 = 0.01m,
        Class2 = 0.025m,
        Class3 = 0.05m,
        Class4 = 0.1m,
        Class5 = 0.2m
    };

    /// <summary>
    /// 总磷(以P计) (mg/L) - 河流
    /// </summary>
    public static readonly IClassStandardValue TP_River = new ClassStandardValue
    {
        Class1 = 0.02m,
        Class2 = 0.1m,
        Class3 = 0.2m,
        Class4 = 0.3m,
        Class5 = 0.4m
    };

    /// <summary>
    /// 总氮(湖、库，以N计) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue TN = new ClassStandardValue
    {
        Class1 = 0.2m,
        Class2 = 0.5m,
        Class3 = 1.0m,
        Class4 = 1.5m,
        Class5 = 2.0m
    };

    /// <summary>
    /// 铜(Cu) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue CU = new ClassStandardValue
    {
        Class1 = 0.01m,
        Class2 = 1.0m,
        Class3 = 1.0m,
        Class4 = 1.0m,
        Class5 = 1.0m
    };

    /// <summary>
    /// 锌(Zn) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue ZN = new ClassStandardValue
    {
        Class1 = 0.05m,
        Class2 = 1.0m,
        Class3 = 1.0m,
        Class4 = 2.0m,
        Class5 = 2.0m
    };

    /// <summary>
    /// 氟化物(以F-计) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue FL = new ClassStandardValue
    {
        Class1 = 1.0m,
        Class2 = 1.0m,
        Class3 = 1.0m,
        Class4 = 1.5m,
        Class5 = 1.5m
    };

    /// <summary>
    /// 硒(Se) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue SE = new ClassStandardValue
    {
        Class1 = 0.01m,
        Class2 = 0.01m,
        Class3 = 0.01m,
        Class4 = 0.02m,
        Class5 = 0.02m
    };

    /// <summary>
    /// 砷(As) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue AS = new ClassStandardValue
    {
        Class1 = 0.05m,
        Class2 = 0.05m,
        Class3 = 0.05m,
        Class4 = 0.1m,
        Class5 = 0.1m
    };

    /// <summary>
    /// 汞(Hg) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue HG = new ClassStandardValue
    {
        Class1 = 0.00005m,
        Class2 = 0.00005m,
        Class3 = 0.0001m,
        Class4 = 0.001m,
        Class5 = 0.001m
    };

    /// <summary>
    /// 镉(Cd) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue CD = new ClassStandardValue
    {
        Class1 = 0.001m,
        Class2 = 0.005m,
        Class3 = 0.005m,
        Class4 = 0.005m,
        Class5 = 0.01m
    };

    /// <summary>
    /// 铬(六价) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue CR6 = new ClassStandardValue
    {
        Class1 = 0.01m,
        Class2 = 0.05m,
        Class3 = 0.05m,
        Class4 = 0.05m,
        Class5 = 0.1m
    };

    /// <summary>
    /// 铅(Pb) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue PB = new ClassStandardValue
    {
        Class1 = 0.01m,
        Class2 = 0.01m,
        Class3 = 0.05m,
        Class4 = 0.05m,
        Class5 = 0.1m
    };

    /// <summary>
    /// 氰化物(CN) (mg/L)
    /// </summary>
    public static readonly IClassStandardValue CN = new ClassStandardValue
    {
        Class1 = 0.005m,
        Class2 = 0.05m,
        Class3 = 0.2m,
        Class4 = 0.2m,
        Class5 = 0.2m
    };

    /// <summary>
    /// 挥发酚 (mg/L)
    /// </summary>
    public static readonly IClassStandardValue VP = new ClassStandardValue
    {
        Class1 = 0.002m,
        Class2 = 0.002m,
        Class3 = 0.005m,
        Class4 = 0.01m,
        Class5 = 0.1m
    };

    /// <summary>
    /// 石油类 (mg/L)
    /// </summary>
    public static readonly IClassStandardValue PETRO = new ClassStandardValue
    {
        Class1 = 0.05m,
        Class2 = 0.05m,
        Class3 = 0.05m,
        Class4 = 0.5m,
        Class5 = 1.0m
    };

    /// <summary>
    /// 阴离子表面活性剂 (mg/L)
    /// </summary>
    public static readonly IClassStandardValue LAS = new ClassStandardValue
    {
        Class1 = 0.2m,
        Class2 = 0.2m,
        Class3 = 0.2m,
        Class4 = 0.3m,
        Class5 = 0.3m
    };

    /// <summary>
    /// 硫化物 (mg/L)
    /// </summary>
    public static readonly IClassStandardValue S2 = new ClassStandardValue
    {
        Class1 = 0.05m,
        Class2 = 0.1m,
        Class3 = 0.2m,
        Class4 = 0.5m,
        Class5 = 1.0m
    };

    /// <summary>
    /// 粪大肠菌群 (个/L)
    /// </summary>
    public static readonly IClassStandardValue FC = new ClassStandardValue
    {
        Class1 = 200,
        Class2 = 2000,
        Class3 = 10000,
        Class4 = 20000,
        Class5 = 40000
    };

    /// <summary>
    /// 铁 (mg/L)
    /// </summary>
    public static readonly IStandardValue FE = new StandardValue() { Value = 0.3m };

    /// <summary>
    /// 锰 (mg/L)
    /// </summary>
    public static readonly IStandardValue MN = new StandardValue() { Value = 0.1m };
    /// <summary>
    /// 钼
    /// </summary>
    public static readonly IStandardValue Mo = new StandardValue() { Value = 0.07m };
    /// <summary>
    /// 钴
    /// </summary>
    public static readonly IStandardValue Co = new StandardValue() { Value = 1m };
    /// <summary>
    /// 铍
    /// </summary>
    public static readonly IStandardValue Be = new StandardValue() { Value = 0.002m };
    /// <summary>
    /// 硼
    /// </summary>
    public static readonly IStandardValue B = new StandardValue() { Value = 0.5m };
    /// <summary>
    /// 锑
    /// </summary>
    public static readonly IStandardValue Sb = new StandardValue() { Value = 0.005m };
    /// <summary>
    /// 镍
    /// </summary>
    public static readonly IStandardValue Ni = new StandardValue() { Value = 0.02m };
    /// <summary>
    /// 钡
    /// </summary>
    public static readonly IStandardValue Ba = new StandardValue() { Value = 0.7m };
    /// <summary>
    /// 钒
    /// </summary>
    public static readonly IStandardValue V = new StandardValue() { Value = 0.05m };
    /// <summary>
    /// 钛
    /// </summary>
    public static readonly IStandardValue Ti = new StandardValue() { Value = 0.1m };
    /// <summary>
    /// 铊
    /// </summary>
    public static readonly IStandardValue Tl = new StandardValue() { Value = 0.0001m };


}