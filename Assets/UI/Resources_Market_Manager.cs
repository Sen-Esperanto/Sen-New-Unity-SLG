using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Resources_Market_Manager : MonoBehaviour
{
    //資源の種類の数
    public const int Number_of_Kind_of_Resources = 20;
    public static int[,] Saving_Resources = new int[Number_of_Kind_of_Resources,TurnEndManager.Number_of_Country];
   //左が資源、右が国名

    //左が資源、右は国
    public static int[][] Market_Size = new int[Number_of_Kind_of_Resources][];//「int[]」の配列(ジャグ配列)

    //一番左は資源、真ん中は市場になる国、右は供給元の国
    public static int[][][] Market_Influence = new int[Number_of_Kind_of_Resources][][];
    //Price[資源][市場になる国] Demand[資源][市場になる国]
    public static int[][] Price = new int[Number_of_Kind_of_Resources][];

    public static int[][] Demand = new int[Number_of_Kind_of_Resources][];


    /*
    public static void Price_and_Demand_Decide(int[][] Market_Size_Clone)//左は価格、右は需要
        //Price[資源][市場になる国] Demand[資源][市場になる国]
    {
        for (int m = 1; m < Number_of_Kind_of_Resources; m++)
        {
            for (int k = 1; k < TurnEndManager.Number_of_Country; k++)
            {
                Price[m][k] = 110 - Market_Size_Clone[m][k];//市場サイズ10なら価格100 50なら価格60　80で30

                //需要決定(真の需要はこれにPOP数をかける)
                if (10 <= Market_Size_Clone[m][k] && Market_Size_Clone[m][k] >= 19)
                {
                    Demand[m][k] = Market_Size_Clone[m][k];//10～19
                }
                if (20 <= Market_Size_Clone[m][k] && Market_Size_Clone[m][k] >= 29)
                {
                    Demand[m][k] = 2 * Market_Size_Clone[m][k] - 20;//20,22,24…38
                }
                if (30 <= Market_Size_Clone[m][k] && Market_Size_Clone[m][k] >= 39)
                {
                    Demand[m][k] = 4 * Market_Size_Clone[m][k] - 80;//40,44,48…76
                }
                if (40 <= Market_Size_Clone[m][k] && Market_Size_Clone[m][k] >= 49)
                {
                    Demand[m][k] = 8 * Market_Size_Clone[m][k] - 240;//80,88,96…152
                }
                if (50 <= Market_Size_Clone[m][k] && Market_Size_Clone[m][k] >= 59)
                {
                    Demand[m][k] = 16 * Market_Size_Clone[m][k] - 640;//160,176,192…304
                }
                if (60 <= Market_Size_Clone[m][k] && Market_Size_Clone[m][k] >= 69)
                {
                    Demand[m][k] = 32 * Market_Size_Clone[m][k] - 1600;//320,352,384…608
                }
                if (70 <= Market_Size_Clone[m][k] && Market_Size_Clone[m][k] >= 80)
                {
                    Demand[m][k] = 64 * Market_Size_Clone[m][k] - 3840;//640,704,768…1216,1280
                }

            }
        }
    }*/

    public static void Price_and_Demand(int[] Market_Size_Clone ,int[] Demand ,int[] Price)//左は価格、右は需要
                //Price[市場になる国] Demand[市場になる国]
    {
            for (int k = 1; k < TurnEndManager.Number_of_Country; k++)
            {
                Price[k] = 110 - Market_Size_Clone[k];//市場サイズ10なら価格100 50なら価格60　80で30

                //需要決定(真の需要はこれにPOP数をかける)
                if (10 <= Market_Size_Clone[k] && Market_Size_Clone[k] >= 19)
                {
                    Demand[k] = Market_Size_Clone[k];//10～19
                }
                if (20 <= Market_Size_Clone[k] && Market_Size_Clone[k] >= 29)
                {
                    Demand[k] = 2 * Market_Size_Clone[k] - 20;//20,22,24…38
                }
                if (30 <= Market_Size_Clone[k] && Market_Size_Clone[k] >= 39)
                {
                    Demand[k] = 4 * Market_Size_Clone[k] - 80;//40,44,48…76
                }
                if (40 <= Market_Size_Clone[k] && Market_Size_Clone[k] >= 49)
                {
                    Demand[k] = 8 * Market_Size_Clone[k] - 240;//80,88,96…152
                }
                if (50 <= Market_Size_Clone[k] && Market_Size_Clone[k] >= 59)
                {
                    Demand[k] = 16 * Market_Size_Clone[k] - 640;//160,176,192…304
                }
                if (60 <= Market_Size_Clone[k] && Market_Size_Clone[k] >= 69)
                {
                    Demand[k] = 32 * Market_Size_Clone[k] - 1600;//320,352,384…608
                }
                if (70 <= Market_Size_Clone[k] && Market_Size_Clone[k] >= 80)
                {
                    Demand[k] = 64 * Market_Size_Clone[k] - 3840;//640,704,768…1216,1280
                }

            }
        
    }

    public static void Sort(int[]Main_list,int[][]Sub_list,int[]Main_list_Sorted , int[][] Sub_list_Sorted)
    {
        //メインはソート元(市場)　サブはそれに連動させるもの(影響力)
        //Main_list[市場にになる国] Sub_list[市場になる国][供給する国]
        int k;
        int j = 0;

        int[] Main_list_clone = new int[TurnEndManager.Number_of_Country];//産物を抜いて市場国のサイズのみ
        for(int i = 1; i < TurnEndManager.Number_of_Country; i++)
        {
            Main_list_clone[i] = Main_list[i];//クローン作成
        }
        //Main_list_clone = Main_list.Clone() as int[];

        int[][] Sub_list_clone = new int[TurnEndManager.Number_of_Country][];
        for(int i =1; i < TurnEndManager.Number_of_Country; i++)
        {
            Sub_list_clone[i] = new int[TurnEndManager.Number_of_Country];
            for(int i2 = 1; i2<TurnEndManager.Number_of_Country; i2++)
            {
                Sub_list_clone[i][i2] = Sub_list[i][i2];//クローン作成
            }
        }
        //Sub_list_clone = Sub_list.Clone() as int[][];

        Main_list_clone[0] = 10000;

        for (int h = 1; h < TurnEndManager.Number_of_Country; h++)//下のことを配列の長さ分(市場の数の分)繰り返す
        {
            k = Math_Myself.Min(Main_list_clone);
            if (k != 10000)
            {
                //最小値と一致するものを探索してソイツをSortedの先頭に持ってくる、Subの方も連動させる
                //
                for (int i = 1; i < TurnEndManager.Number_of_Country; i++)
                {
                    if (Main_list_clone[i] == k)
                    {
                        j = j + 1;
                        //Debug.Log(k.ToString() + " " + j.ToString() + "　" + Main_list_clone[1].ToString());
                        Main_list_Sorted[j] = Main_list_clone[i];//最小値はSortedの1番に　２番目に小さい値は２番に
                        for (int m = 1; m < Sub_list_clone[i].Length; m++)
                        {
                            Sub_list_Sorted[j][m] = Sub_list_clone[i][m];//Mainと連動
                        }
                        Main_list_clone[i] = 10000;
                        TurnEndManager.Market_Min_to_MAX[j] = i;//最小値の入って居た場所を１，２…と代入していく
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("Miss in Sort");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i<Number_of_Kind_of_Resources; i++)
        {
            Market_Size[i] = new int[TurnEndManager.Number_of_Country];
            for(int j = 1; j < TurnEndManager.Number_of_Country; j++)
            {
                Market_Size[i][j] = 0;//とりあえずMarket_Sizeには0を代入
            }
        }
        for (int i = 1; i < Number_of_Kind_of_Resources; i++)
        {
            Market_Influence[i] = new int[TurnEndManager.Number_of_Country][];
            for (int j = 1; j < TurnEndManager.Number_of_Country; j++)
            {
                    Market_Influence[i][j] = new int[TurnEndManager.Number_of_Country];
                for (int k = 1; k < TurnEndManager.Number_of_Country; k++)
                {
                    Market_Influence[i][j][k] = 0;//Influenceにもとりあえず０を代入
                }
            }
        }

        //Market_Size[0] = new int[TurnEndManager.Number_of_Country];//必ず0
        Market_Size[1][1] = 25;//穀物の陽帝国の市場レベル
        Market_Size[1][2] = 1;
        Market_Size[1][3] = 1;
        Market_Size[1][4] = 1;
        Market_Size[1][5] = 1;



        //Market_Influence[0] = new int[][] { };//必ず０　左列もずっと０

        //Market_Influence[1] = new int[][] { };//穀物
        //Market_Influence[1][0] = new int[TurnEndManager.Number_of_Country];//ここも０
        Market_Influence[1][1][1] = 40;//穀物の陽帝国における市場に働く影響力(左列は相変わらず0)
        //40の影響力を持ってる、市場サイズを見ると100%の需要を得ている



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
