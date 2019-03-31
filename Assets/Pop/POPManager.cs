using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class POPManager : MonoBehaviour
{
    public static int Population_Count(int i)//iは国名
    {
        int POP = 0;
        for(int j=1; j<Province1Manager.Number_of_Province; j++)
        {
            if (TurnEndManager.Donating_Country[j] == i)
            {
                POP = POP + Province_MAX_POP[j];
            }
        }
        return POP;

    }

    public static int Job_Count(int i,int[]job)//iは国名、jobは(細かい)職の配列
    {
        int POP = 0;

        for (int j = 1; j < Province1Manager.Number_of_Province; j++)
        {
            if (TurnEndManager.Donating_Country[j] == i)
            {
                POP = POP + job[j];
            }
        }
        return POP;
    }

    public const int Number_of_Detail_Job = 30;
    public static int[][] Job_Detail_List = new int[Number_of_Detail_Job][];//左は詳細な職、右はプロビ
        //startで一つ一つの配列がプロビ数分の長さを持つように定義済み

    public static int[][] Job_Produce_Efficiency = new int[Number_of_Detail_Job][];//左は詳細な職　右は国
         //startで一つ一つの配列がプロビ数分の長さを持つように定義済み



    public static int[] Province_Farmer_Number_List = new int[100] { //プロビ数
        0, // Province0なので0にしておく
        20, // Province1のFarmer
        2,  //行を見てFarmer数書き込み
        3,
        4,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
    };

    public static int[] Province_Craftsmen_Number_List = new int[100] { //プロビ数
        0, // Province0なので0にしておく
        0, // Province1の工員
        0,  //行を見て工員数書き込み
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
    };

    public static int[] Province_Soldier_Number_List = new int[100] { //プロビ数
        0, // Province0なので0にしておく
        3, // Province1の兵士
        0,  //行を見て兵士数書き込み
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
    };

    public static int[] Province_Miner_Number_List = new int[100] { //プロビ数
        0, // Province0なので0にしておく
        7, // Province1の鉱夫
        0,  //行を見て鉱夫数書き込み
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
    };

    // []の中の数はプロビ名になるので[0]はずっと0のまま
    public static int[] Province_MAX_POP = new int[Province1Manager.Number_of_Province]; //人口から算出されるPOP最大数(人口÷1万の切り捨て)
    public static int[] Province_MAX_Farmer = new int[Province1Manager.Number_of_Province];//建造物と特徴から算出されるそれぞれの職に就けるPOP最大数

    //ある二次元配列の中のi列目に何個の"x"があるかカウントする関数
    public static void Count_Building_or_Feature(string[,] list, string x , int[] MAX, int supply)
    //二次元string配列listと整数iと文字列xと1次元int配列MAXが引数の関数
    //二次元string配列list　は　プロビ建造物or特徴の2次元配列、Province_Building_Managerからとってくる
    //string x　は　カウントしたい建造物名or特徴名、"農地"とか
    //一次元int配列MAX　は　職に就ける最大POPの配列、すぐ上から取ってくる
    //int supply　は　建造物の提供する職数、Province_Building_Managerに書いてある
    {
        for (int i = 1; i < MAX.Length; i++)
        {
            MAX[i] = 0; //計算前に初期化
        }
        for (int j = 1; j < list.GetLength(0); j++) { //jはプロビ名、１から
            for (int k = 0; k < list.GetLength(1); k++) { //kは建造物名、０から
                if (list[j,k] == x)
                {
                    MAX[j] = MAX[j] + supply;


                }
            }
        }
    }
    /*
             for (int i = 1; i < Province_Building_Manager.Province_Fearture.GetLength(0); i++)
            for(int j=1; j<Province_Building_Manager.Province_Fearture.GetLength(1); j++ )
            if (Province_Building_Manager.Province_Fearture[i,j] == "農地")
     */

    // Start is called before the first frame update
    void Start()
    {
        //POP最大数計算
        for (int i = 1; i < Province_MAX_POP.Length; i++)
            Province_MAX_POP[i] = Convert.ToInt32(Math.Floor((decimal)PopulationManager.Province_Population_List[i] / 10000));
        //職に就けるPOP最大数計算
        Count_Building_or_Feature(Province_Building_Manager.Province_Fearture, "農地", Province_MAX_Farmer,Province_Building_Manager.Farm_Supply_Farmer);

        for(int i = 1; i < Number_of_Detail_Job; i++)
        {
            Job_Detail_List[i] = new int[Province1Manager.Number_of_Province];
        }
        Job_Detail_List[1][1] = 15;//穀物農家(左の１)のプロビ１(右の１)のPOP数は15


        for (int i = 1; i < Number_of_Detail_Job; i++)
        {
            Job_Produce_Efficiency[i] = new int[TurnEndManager.Number_of_Country];
        }

        for (int j = 1; j < TurnEndManager.Number_of_Country; j++)
        {
            Job_Produce_Efficiency[1][j] = 100; //穀物農民のデフォルト生産効率
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
