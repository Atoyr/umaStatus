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

namespace umaStatus.Components
{
  public partial class Character : ComponentBase
  {
    [Parameter]
    public Status Status { set; get; } = new Status();

    private int no;
    [Parameter]
    public int No 
    { 
      set
      {
        no = value;
        setColor();
        StateHasChanged();
      }

      get 
      {
        return no;
      }
    }

    private int gateCount;
    [Parameter]
    public int GateCount 
    { 
      set
      {
        gateCount = value;
        setColor();
        StateHasChanged();
      }

      get 
      {
        return gateCount;
      }
    }

    protected string TableClassname =>
      ClassBuilder.Default("frame")
      .AddClass(color)
      .Build();

    protected string NoClassname =>
      ClassBuilder.Default("")
      .AddClass(color)
      .AddValue("-accent")
      .Build();

    protected string color { set; get; }

    public int GateNo 
    { 
      get
      {
        if ( no <= 0 || 18 < no || gateCount <= 0 || 18 < gateCount)
        {
          return 0;
        }

        if (gateCount > 15)
        {
          switch(gateCount % 16)
          {
            case 0:
              return (no % 2 > 0 ? no / 2 + 1 : no / 2);
            case 1:
              if (no == 17) return 8;
              return (no % 2 > 0 ? no / 2 + 1 : no / 2);
            case 2:
              if (no < 13) return (no % 2 > 0 ? no / 2 + 1 : no / 2);
              if (12 < no && no < 16) return 7;
              return 8;
          }
        }
        if (17 - gateCount > no) 
        {
          return no;
        }
        else
        {
          var x = 16 - gateCount;
          var y = no - x;
          return x + (y % 2 > 0 ? y / 2 + 1 : y /2 );
        }
      }
    }

    private void setColor()
    {
      switch (GateNo)
      {
        case 1:
          color = "white";
          break;
        case 2:
          color = "black";
          break;
        case 3:
          color = "red";
          break;
        case 4:
          color = "blue";
          break;
        case 5:
          color = "yellow";
          break;
        case 6:
          color = "green";
          break;
        case 7:
          color = "orange";
          break;
        case 8:
          color = "pink";
          break;
        default:
          color = string.Empty;
          break;
      }
    }
  }
}

