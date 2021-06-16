using System;

namespace umaStatus.Models
{
  public class Status
  {
    public string Name {set;get;}
    public int Speed {set;get;}
    public int Stamina {set;get;}
    public int Power {set;get;}
    public int Guts {set;get;}
    public int Intelligence {set;get;}

    public int LegQuality { set; get; }
    public string RangeStatus { set; get; }
    public string GroundStatus { set; get; }

    public Status(){}
  }
}
