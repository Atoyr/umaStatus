using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using umaStatus.Models;
using umaStatus.Utilities;

namespace umaStatus.Pages
{
  public partial class Index : ComponentBase
  {
    [Parameter]
    public List<Status> umas {set;get;} = new List<Status>();

    protected string TableClassname =>
      ClassBuilder.Default("frame")
      .AddClass(color)
      .Build();


    protected int GateCount { set; get; } = 9;
    protected IEnumerable<string> GateNoList 
    {
      get
      {
        return Enumerable.Range(1, GateCount).Select(x => x.ToString());
      }
    }


    protected GateStatus gateStatus { set; get; }= new GateStatus();
    protected string color { set; get; }

    protected override void OnInitialized()
    {
      while (umas.Count() < 18)
      {
        umas.Add(new Status());
      }
    }

    protected void UpdateState()
    {
      if ( string.IsNullOrEmpty(gateStatus.GateNo )) return;
      Console.WriteLine(gateStatus.GateNo);
      var s = umas[Int32.Parse(gateStatus.GateNo) - 1];

      s.Speed = gateStatus.Speed;
      s.Stamina = gateStatus.Stamina;
      s.Power = gateStatus.Power;
      s.Guts = gateStatus.Guts;
      s.Intelligence = gateStatus.Intelligence;

      gateStatus.Reset();
    }
  }
}
