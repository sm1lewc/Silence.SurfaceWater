namespace Silence.SurfaceWater.Core.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ICwqi
{
    /// <summary>
    /// 
    /// </summary>
    string FactroCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    string FactorName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    decimal? FactorValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    decimal? FactorCwqi { get; set; }
}