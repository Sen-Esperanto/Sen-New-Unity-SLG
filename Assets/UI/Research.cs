using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Research : MonoBehaviour
{
    public const int Number_of_Research = 100;
    //各ターンにそれぞれの技術が選択される確率
    public static int[][] Research_in_Turn = new int[TurnEndManager.MAX_Turn][];//左がターン数　右が技術番号
    public static int Now_Research_Number = 0;

    
    //上の数値のターンごとの合計
    //public static int[] Sum_Percent_of_Research = new int[TurnEndManager.MAX_Turn];
    public static void Research_Decide(int Turn)
    {
        int j = 0;
        int k = 0;
        System.Random r = new System.Random(Environment.TickCount);
        int Sum_Percent_of_Research = 0;
        for(int i2 = 1; i2 < Number_of_Research; i2++)
        {
            Sum_Percent_of_Research = Sum_Percent_of_Research + Research_in_Turn[Turn][i2];
        }
        //Sumはそのターンに発明される技術の確率(度合い)の合計
        if (Sum_Percent_of_Research == 0)
        {
            Now_Research_Number = 0;
        }
        else
        {
            if (Sum_Percent_of_Research == 1)
            {
                k = 0;
            }
            else
            {
                k = r.Next(Sum_Percent_of_Research - 1);//０からSum-1までの乱数
            }
            for (int i = 1; i < Number_of_Research; i++)
            {
                if (Research_in_Turn[Turn][i] + j > k)//Research_in_Turn[Turn][i]が１０なら、kが０～９だった時発動
                {
                    Now_Research_Number = i;
                    break;
                }
            }
            
        }
    }

    public GameObject Research_Object = null;

    public void Print_Research()
    {
        Text Research_text = Research_Object.GetComponent<Text>();
        if (Now_Research_Number == 0)
        {
            Research_text.text = "発明\nなし";
        }
        if (Now_Research_Number == 1)
        {
            Research_text.text = "発明\n機械化農業";
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < TurnEndManager.MAX_Turn; i++)
        {
            Research_in_Turn[i] = new int[Number_of_Research];
        }
        Research_in_Turn[1][1] = 10;

        Research_Decide(1);

        Print_Research();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
