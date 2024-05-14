using UnityEngine;
using System.Collections.Generic;

public enum ColorList
{ Red, Green, Blue, Yellow, Purple, Count }

public static class AvailableColor
{
    public static readonly Color red = Color.red;
    public static readonly Color blue = Color.blue;
    public static readonly Color green = Color.green;
    public static readonly Color yellow = Color.yellow;
    public static readonly Color purple =
                      new Color(1, 0, 1, 1);
    //ordem fixa:(red, green, blue, alpha)

    public static readonly Dictionary<ColorList, Color>
        colorMap = new Dictionary<ColorList, Color>()
        {
            { ColorList.Red, red },
            { ColorList.Green, green },
            { ColorList.Blue, blue },
            { ColorList.Yellow, yellow },
            { ColorList.Purple, purple }
        };
}