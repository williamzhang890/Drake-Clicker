using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTIL
{
    /*
     * Credit goes to https://forum.unity.com/threads/outlined-text.43698/
         */
    public static void drawOutline(Rect r, string text, GUIStyle style, Color c)
    {
        
        Color old = style.normal.textColor;
        c.a = old.a;
        // draw to the left
        r.x--;
        GUI.Label(r, text, style);
        // draw to the right
        r.x += 2;
        GUI.Label(r, text, style);
        // draw below
        r.x--;
        r.y--;
        GUI.Label(r, text, style);
        // draw above
        r.y += 2;
        GUI.Label(r, text, style);

        style.normal.textColor = old;
        // revert to previous
        r.y--;
        GUI.Label(r, text, style);
    }

    struct Coin
    {
        public static Coin SENTINEL = new Coin("", Mathf.NegativeInfinity);
        public string name;
        public float value;
        public Coin(string name, float value)
        {
            this.name = name;
            this.value = value;
        }
    }
    static Coin[] coins = new Coin[] {
        new Coin("trillion", 1000000000),
        new Coin("billion", 1000000000),
        new Coin("million", 1000000),
        new Coin("thousand", 1000)
    };

    public static string formatNumber(float number, int decimals, bool displayZeros)
    {
        float multiplier = number;
        bool found = false;
        Coin coin = Coin.SENTINEL;

        // greedy look for highest coin value less than number
        foreach (Coin c in coins)
        {
            if (c.value <= number)
            {
                multiplier = number / c.value;
                coin = c;
                found = true;
                break;
            }
        }

        // create format
        string format;
        if (displayZeros)
        {
            format = "0.";
            for (int i = 0; i < decimals; i++)
            {
                format += "0";
            }
        }
        else
        {
            format = "0.";
            for (int i = 0; i < decimals; i++)
            {
                format += "#";
            }
        }


        string output = multiplier.ToString(format);
        if (found)
        {
            output += " " + coin.name;
        }
        return output;
        
    }
}
