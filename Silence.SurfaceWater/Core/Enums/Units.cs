using System.Diagnostics.CodeAnalysis;

namespace Silence.SurfaceWater.Core.Enums;

/// <summary>
/// 单位
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class Units
{
    /// <summary>
    ///  无量纲
    /// </summary>
    public const string Dimensionless = "无量纲";

    /// <summary>
    /// 毫克每升
    /// </summary>
    public const string MgPerL = "mg/L";
    
    /// <summary>
    /// 摄氏度
    /// </summary>
    public const string Celsius = "℃";
    
    /// <summary>
    /// NTU
    /// </summary>
    public const string NTU = "NTU";
    
    /// <summary>
    /// μS/cm
    /// </summary>
    public const string USPerCM = "μS/cm";
    
    /// <summary>
    /// 个/L
    /// </summary>
    public const string NumPerL = "个/L";
    
    /// <summary>
    /// %
    /// </summary>
    public const string Percent = "%";
    
    /// <summary>
    /// 电压 V
    /// </summary>
    public const string Voltage = "V";
    
    /// <summary>
    /// 水压 P
    /// </summary>
    public const string Pressure = "P";
    
    /// <summary>
    /// 米
    /// </summary>
    public const string Meter = "m";
    
    /// <summary>
    ///  m/s
    /// </summary>
    public const string MPS = "m/s";
    
    /// <summary>
    /// mm
    /// </summary>
    public const string MM = "mm";
}
