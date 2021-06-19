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

    protected int no {set;get;}
    protected int speed {set;get;}
    protected int stamina {set;get;}
    protected int power {set;get;}
    protected int guts {set;get;}
    protected int intelligence {set;get;}
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
      var s = new Status();
      s.Speed = speed;
      s.Stamina = stamina;
      s.Power = power;
      s.Guts = guts;
      s.Intelligence = intelligence;
      umas.Add(s);

    }
  }
}
