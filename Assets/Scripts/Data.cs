using UnityEngine;

[CreateAssetMenu]
public class Data : ScriptableObject
{
    public ColorPick FirstColor;
    //public Color FirstColor;
    public float StartSpeed;

    //public static Color[] Colors = new Color[] { Color.red, Color.green, Color.blue };


    public enum ColorPick
    {
        Red,
        Magenta,
        Yellow,
        Green,
        Blue,
        Cyan
    }

    public static Color GetColor(ColorPick color)
    {
        switch (color)
        {
            case ColorPick.Red:
                return Color.red;
            case ColorPick.Magenta:
                return Color.magenta;
            case ColorPick.Yellow:
                return Color.yellow;
            case ColorPick.Green:
                return Color.green;
            case ColorPick.Blue:
                return Color.blue;
            case ColorPick.Cyan:
                return Color.cyan;
            default:
                return Color.white;
        }
    }
}
