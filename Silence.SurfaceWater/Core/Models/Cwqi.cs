using Silence.SurfaceWater.Core.Interfaces;

namespace Silence.SurfaceWater.Core.Models;

public class Cwqi : ICwqi
{
    public string FactroCode { get; set; } = null!;
    public string FactorName { get; set; } = null!;
    public decimal? FactorValue { get; set; }
    public decimal? FactorCwqi { get; set; }
}