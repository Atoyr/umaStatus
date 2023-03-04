using System;
namespace umaStatus.Models
{
  public class GateStatus : Status
  {
    public string GateNo { set; get; }

    public GateStatus():base()
    {
      Reset();
    }

    public void Reset()
    {
      GateNo = string.Empty;
      Name = string.Empty;
      Speed = 600;
      Stamina = 600;
      Power = 600;
      Guts = 600;
      Intelligence = 600;
      LegQuality = 0;
      RangeStatus = "A";
      GroundStatus = "A";
    }
  }
}

