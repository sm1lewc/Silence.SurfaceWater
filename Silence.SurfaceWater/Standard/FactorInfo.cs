using System.Diagnostics.CodeAnalysis;
using Silence.SurfaceWater.Core.Enums;
using Silence.SurfaceWater.Core.Interfaces;
using Silence.SurfaceWater.Core.Models;

namespace Silence.SurfaceWater.Standard;

/// <summary>
/// 指标信息
/// </summary>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public static class FactorInfo
{
    private static readonly IReadOnlyDictionary<string, IFactor> _factors;

    static FactorInfo()
    {
        _factors = new Dictionary<string, IFactor>
        {
            [PH.Code] = PH,
            [DO.Code] = DO,
            [CODMN.Code] = CODMN,
            [COD.Code] = COD,
            [BOD5.Code] = BOD5,
            [NH3N.Code] = NH3N,
            [TP.Code] = TP,
            [TN.Code] = TN,
            [CU.Code] = CU,
            [ZN.Code] = ZN,
            [FL.Code] = FL,
            [SE.Code] = SE,
            [AS.Code] = AS,
            [HG.Code] = HG,
            [CD.Code] = CD,
            [CR6.Code] = CR6,
            [PB.Code] = PB,
            [CN.Code] = CN,
            [VP.Code] = VP,
            [PETRO.Code] = PETRO,
            [LAS.Code] = LAS,
            [S2.Code] = S2,
            [FC.Code] = FC,
            [WT.Code] = WT,
            [EC.Code] = EC,
            [TURB.Code] = TURB,
            [SO42.Code] = SO42,
            [CL.Code] = CL,
            [NO3.Code] = NO3,
            [FE.Code] = FE,
            [MN.Code] = MN
        };
    }

    /// <summary>
    /// 获取指标信息
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static IFactor? GetFactorInfo(string code) => _factors.GetValueOrDefault(code.ToLower());

    /// <summary>
    /// pH
    /// </summary>
    public static readonly IFactor PH = new Factor
    {
        Code = "w01001",
        Name = "pH",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.Dimensionless,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 0
        }
    };


    /// <summary>
    /// 溶解氧
    /// </summary>
    public static readonly IFactor DO = new Factor
    {
        Code = "w01009",
        Name = "溶解氧",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 1
        }
    };

    /// <summary>
    /// 高锰酸盐指数
    /// </summary>
    public static readonly IFactor CODMN = new Factor
    {
        Code = "w01019",
        Name = "高锰酸盐指数",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 1
        }
    };

    /// <summary>
    /// 化学需氧量
    /// </summary>
    public static readonly IFactor COD = new Factor
    {
        Code = "w01018",
        Name = "化学需氧量",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 1
        }
    };

    /// <summary>
    /// 五日生化需氧量
    /// </summary>
    public static readonly IFactor BOD5 = new Factor
    {
        Code = "w01017",
        Name = "五日生化需氧量",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            AssessmentData = 1
        }
    };

    /// <summary>
    /// 氨氮
    /// </summary>
    public static readonly IFactor NH3N = new Factor
    {
        Code = "w21003",
        Name = "氨氮",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 3,
            AssessmentData = 2
        }
    };

    /// <summary>
    /// 总磷
    /// </summary>
    public static readonly IFactor TP = new Factor
    {
        Code = "w21011",
        Name = "总磷",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 3,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 总氮
    /// </summary>
    public static readonly IFactor TN = new Factor
    {
        Code = "w21001",
        Name = "总氮",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 2
        }
    };

    /// <summary>
    /// 铜
    /// </summary>
    public static readonly IFactor CU = new Factor
    {
        Code = "w20122",
        Name = "铜",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 锌
    /// </summary>
    public static readonly IFactor ZN = new Factor
    {
        Code = "w20123",
        Name = "锌",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 氟化物
    /// </summary>
    public static readonly IFactor FL = new Factor
    {
        Code = "w21017",
        Name = "氟化物",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 硒
    /// </summary>
    public static readonly IFactor SE = new Factor
    {
        Code = "w20128",
        Name = "硒",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 5,
            AssessmentData = 4
        }
    };

    /// <summary>
    /// 砷
    /// </summary>
    public static readonly IFactor AS = new Factor
    {
        Code = "w20141",
        Name = "砷",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 5,
            AssessmentData = 4
        }
    };

    /// <summary>
    /// 汞
    /// </summary>
    public static readonly IFactor HG = new Factor
    {
        Code = "w20111",
        Name = "汞",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 6,
            AssessmentData = 5
        }
    };

    /// <summary>
    /// 镉
    /// </summary>
    public static readonly IFactor CD = new Factor
    {
        Code = "w20115",
        Name = "镉",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 6,
            AssessmentData = 5
        }
    };

    /// <summary>
    /// 六价铬
    /// </summary>
    public static readonly IFactor CR6 = new Factor
    {
        Code = "w20117",
        Name = "铬（六价）",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 铅
    /// </summary>
    public static readonly IFactor PB = new Factor
    {
        Code = "w20120",
        Name = "铅",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 氰化物
    /// </summary>
    public static readonly IFactor CN = new Factor
    {
        Code = "w21016",
        Name = "氰化物",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 挥发酚
    /// </summary>
    public static readonly IFactor VP = new Factor
    {
        Code = "w23002",
        Name = "挥发酚",
        FactorType = FactorType.酚.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 5,
            AssessmentData = 4
        }
    };

    /*
     *  https://www.mee.gov.cn/ywgz/fgbz/bz/bzwb/jcffbz/201810/t20181016_662396.shtml
     *  水质 石油类的测定 紫外分光光度法（试行）
     *  Water quality — Determination of petroleum — Ultraviolet spectrophotometric method
     *  https://www.mee.gov.cn/ywgz/fgbz/bz/bzwb/jcffbz/201810/t20181016_662395.shtml
     *  水质 石油类和动植物油类的测定 红外分光光度法
     *  Water quality — Determination of petroleum, animal fats and vegetable oils — Infrared spectrophotometry
     */

    /// <summary>
    /// 石油类
    /// </summary>
    public static readonly IFactor PETRO = new Factor
    {
        Code = "w22001",
        Name = "石油类",
        FactorType = FactorType.油类.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 3,
            AssessmentData = 2
        }
    };

    /// <summary>
    /// 阴离子表面活性剂
    /// </summary>
    public static readonly IFactor LAS = new Factor
    {
        Code = "w19002",
        Name = "阴离子表面活性剂",
        FactorType = FactorType.其他指标.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 3,
            AssessmentData = 2
        }
    };

    /// <summary>
    /// 硫化物
    /// </summary>
    public static readonly IFactor S2 = new Factor
    {
        Code = "w21019",
        Name = "硫化物",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 粪大肠菌群
    /// </summary>
    public static readonly IFactor FC = new Factor
    {
        Code = "w02003",
        Name = "粪大肠菌群",
        FactorType = FactorType.生物指标.ToString(),
        Unit = Units.NumPerL,
        Precision = new Precision
        {
            HourData = 0,
            AssessmentData = 0
        }
    };

    /// <summary>
    /// 水温
    /// </summary>
    public static readonly IFactor WT = new Factor
    {
        Code = "w01010",
        Name = "水温",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.Celsius,
        Precision = new Precision
        {
            HourData = 1,
            AssessmentData = 1
        }
    };

    /// <summary>
    /// 电导率
    /// </summary>
    public static readonly IFactor EC = new Factor
    {
        Code = "w01014",
        Name = "电导率",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.USPerCM,
        Precision = new Precision
        {
            HourData = 1,
            AssessmentData = 1
        }
    };

    /// <summary>
    /// 浊度
    /// </summary>
    public static readonly IFactor TURB = new Factor
    {
        Code = "w01003",
        Name = "浊度",
        FactorType = FactorType.物理和综合指标.ToString(),
        Unit = Units.NTU,
        Precision = new Precision
        {
            HourData = 1,
            AssessmentData = 1
        }
    };

    /// <summary>
    /// 硫酸盐
    /// </summary>
    public static readonly IFactor SO42 = new Factor
    {
        Code = "w21038",
        Name = "硫酸盐",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 2
        }
    };

    /// <summary>
    /// 氯化物
    /// </summary>
    public static readonly IFactor CL = new Factor
    {
        Code = "w21022",
        Name = "氯化物",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 2
        }
    };

    /// <summary>
    /// 硝酸盐
    /// </summary>
    public static readonly IFactor NO3 = new Factor
    {
        Code = "w21007",
        Name = "硝酸盐",
        FactorType = FactorType.无机污染物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 2,
            AssessmentData = 2
        }
    };

    /// <summary>
    /// 铁
    /// </summary>
    public static readonly IFactor FE = new Factor
    {
        Code = "w20125",
        Name = "铁",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 3,
            AssessmentData = 3
        }
    };

    /// <summary>
    /// 锰
    /// </summary>
    public static readonly IFactor MN = new Factor
    {
        Code = "w20124",
        Name = "锰",
        FactorType = FactorType.金属及金属化合物.ToString(),
        Unit = Units.MgPerL,
        Precision = new Precision
        {
            HourData = 4,
            AssessmentData = 4
        }
    };
}
