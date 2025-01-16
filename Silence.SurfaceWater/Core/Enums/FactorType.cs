using System.Diagnostics.CodeAnalysis;

namespace Silence.SurfaceWater.Core.Enums;

/// <summary>
/// 指标类别
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum FactorType
{
    /// <summary>
    /// 物理和综合指标
    /// </summary>
    物理和综合指标 = 1,

    /// <summary>
    /// 生物指标
    /// </summary>
    生物指标 = 2,

    /// <summary>
    /// 放射性指标
    /// </summary>
    放射性指标 = 3,

    /// <summary>
    /// 其他指标
    /// </summary>
    其他指标 = 4,

    /// <summary>
    /// 金属及金属化合物
    /// </summary>
    金属及金属化合物 = 5,

    /// <summary>
    /// 无机污染物
    /// </summary>
    无机污染物 = 6,

    /// <summary>
    /// 油类
    /// </summary>
    油类 = 7,

    /// <summary>
    /// 酚
    /// </summary>
    酚 = 8,

    /// <summary>
    /// 脂肪烃和卤代脂肪烃
    /// </summary>
    脂肪烃和卤代脂肪烃 = 9,

    /// <summary>
    /// 芳香族化合物
    /// </summary>
    芳香族化合物 = 10,

    /// <summary>
    /// 胺
    /// </summary>
    胺 = 11,

    /// <summary>
    /// 多氯联苯
    /// </summary>
    多氯联苯 = 12,

    /// <summary>
    /// 醚
    /// </summary>
    醚 = 13,

    /// <summary>
    /// 酯
    /// </summary>
    酯 = 14,

    /// <summary>
    /// 醇
    /// </summary>
    醇 = 15,

    /// <summary>
    /// 醛
    /// </summary>
    醛 = 16,

    /// <summary>
    /// 有机酸
    /// </summary>
    有机酸 = 17,

    /// <summary>
    /// 农药
    /// </summary>
    农药 = 18,

    /// <summary>
    /// 消毒剂及其副产物
    /// </summary>
    消毒剂及其副产物 = 19,

    /// <summary>
    /// 其他有机物
    /// </summary>
    其他有机物 = 20
}
