using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnEndManager : MonoBehaviour
{
    public GameObject gameobject;
    public static int Past_Year_When_Turnend = 1;
    public static int MAX_Turn = 1000;


    public GameObject TurnNumber_Object = null;

    //ターン終了時に使うものとそれに関連する国家の補正の変数置き場

    public static int Start_Year_Number = 1800;
    public static int Now_Year_Number = 1800;
    public static int Start_Turn_Number = 1;
    public static int Now_Turn_Number = 1;

    public static int YOU_Farmer_Improve_Percent = 30;
    public static int YOU_Miner_Improve_Percent = 10;
    public static int YOU_Craftsmen_Improve_Percent = 10;
    public static int YOU_Soldier_Improve_Percent = 10;

    //そのプロビを支配している国家
    public static int[] Donating_Country = new int[Province1Manager.Number_of_Province];

    public const int Number_of_Country = 50; //国の数
    //職の振り分けをNFで変更できる確率
    public static int[,] Job_Improve_Percent = new int[Number_of_Country, 5];//左が国家数、右が職数+1

    public static int[] Demand_for_Calculate = new int[Number_of_Country];
    public static int[] Price_for_Calculate = new int[Number_of_Country];



    public static int[] Market_Sorted = new int[Number_of_Country+1];//市場になる国名
    public static int[][] Influence_Sorted = new int[Number_of_Country+1][];//左は市場になる国名　右は供給する国名

    public static int[] Market_Min_to_MAX = new int[Number_of_Country+1];
    //１番目に小さい数が入っていた場所、２番目に小さい数が入っていた場所…一番大きな数が入っていた場所　を記す配列
    //処理に用いる
    void Start()
    {
        Text TurnNumber_text = TurnNumber_Object.GetComponent<Text>();
        TurnNumber_text.text = "ターン" + Now_Turn_Number + "　" + Now_Year_Number + "年";

        //職変更率の初期設定
        for (int i = 1; i < 50; i++) {
            Job_Improve_Percent[i, 1] = 30;
            Job_Improve_Percent[i, 2] = 20;
            Job_Improve_Percent[i, 3] = 10;
            Job_Improve_Percent[i, 4] = 10;

                }

        //ヌル参照エラー回避のためにジャグ配列をnewしておく
        for(int i = 1; i < Number_of_Country + 1; i++)
        {
            Influence_Sorted[i] = new int[Number_of_Country +1];
            for(int j =1; j <Number_of_Country; j++)
            {
                Influence_Sorted[i][j] = 0;
            }
        }
        for(int i =1; i <Number_of_Country+1; i++)
        {
            Market_Sorted[i] = 0;
        }

        //プロビ支配国家初期設定
        Donating_Country[1] = 1; //1は陽帝国
    }

    public static void Market(int i)//iは生産物名
    {
        Resources_Market_Manager.Sort(Resources_Market_Manager.Market_Size[i],Resources_Market_Manager.Market_Influence[i], Market_Sorted, Influence_Sorted);
        //この時点でMarket_Sortedには生産物iの市場サイズが小さい順に、Influence_Sortedにはそれに連動するようにそれぞれの市場への国家の影響力が載る
        //またMarket_Min_to_MAXには最小値の入って居た場所、…という風な配列が入っている

        Resources_Market_Manager.Price_and_Demand(Market_Sorted, Demand_for_Calculate, Price_for_Calculate); //ソートした順番で資源ごとに需要と価格をジャグ配列に代入
        //Demand_for_Calculate[市場になる国] Price_for_Calculate[市場になる国]
        for (int k = 1; k < Number_of_Country; k++) {// ｋは市場になる国家
            for (int j = 1; j < Number_of_Country; j++) {//　ｊは売る方の国家
                if (Resources_Market_Manager.Saving_Resources[i, j] >= Influence_Sorted[k][j])//もし資源に余裕があるなら
                {
                    //まず貯蓄資源を減らす
                    Resources_Market_Manager.Saving_Resources[i, j] = Resources_Market_Manager.Saving_Resources[i, j] - Influence_Sorted[k][j];
                    //その後資金を追加
                    YOUMoneyManager.Money_in_Country[j] = YOUMoneyManager.Money_in_Country[i] + Price_for_Calculate[k] * Influence_Sorted[k][j];

                }
                else//もし資源に余裕がないなら
                {
                    //持っている限り売って
                    YOUMoneyManager.Money_in_Country[j] = YOUMoneyManager.Money_in_Country[i] + Price_for_Calculate[k] * Resources_Market_Manager.Saving_Resources[i, j];
                    //貯蓄資源を０にする
                    Resources_Market_Manager.Saving_Resources[i, j] = 0;
                    
                }
            }
        }
    }

    public void OnClick()
    {
       //収入を国庫に加算、最初にやる
        //YOUMoneyManager.YOUmoney = YOUMoneyManager.YOUmoney + ProvinceIncomeManager.Province_Income_List[1];//YOUが持ってる領土番号
        //資源を国庫に加算　市場処理の前にやる
        for (int i = 1; i < Resources_Market_Manager.Number_of_Kind_of_Resources; i++)//iは資源名でありそれを生産する職名でもある
        {
            for (int j = 1; j < Number_of_Country; j++) {//jは国名
                Resources_Market_Manager.Saving_Resources[i, j] = POPManager.Job_Produce_Efficiency[i][j] * POPManager.Job_Count(j, POPManager.Job_Detail_List[i]);
        
                    }
        }


        Market(1);//穀物の処理

        //農民の
        //POP最大数計算
        for (int i = 1; i < POPManager.Province_MAX_POP.Length; i++)
            POPManager.Province_MAX_POP[i] = Convert.ToInt32(Math.Floor((decimal)PopulationManager.Province_Population_List[i] / 10000));

        //ターン終了時1年経過
        Now_Year_Number = Now_Year_Number + Past_Year_When_Turnend;
        //ターン数+１
        Now_Turn_Number = Now_Turn_Number + 1;

        //年数とターン数表示
        Text TurnNumber_text = TurnNumber_Object.GetComponent<Text>();
        TurnNumber_text.text = "ターン" + Now_Turn_Number + "　" + Now_Year_Number + "年";

        //職に就けるPOP最大数計算(農民)
        POPManager.Count_Building_or_Feature(Province_Building_Manager.Province_Fearture, "農地", POPManager.Province_MAX_Farmer, Province_Building_Manager.Farm_Supply_Farmer);

        //職の促進の計算
        //国家数の分だけ処理を行う
        for(int h = 1; h < Job_Improve_Percent.GetLength(0); h++){
            //農民
            for (int i = 1; i < Province1Manager.Number_of_Province; i++)
            {
                if (Donating_Country[i] == h)
                {//支配してる国家がhの時なら操作を行う
                    System.Random r = new System.Random(Environment.TickCount + i);
                    System.Random r2 = new System.Random(Environment.TickCount - i);
                    //０から９９までの整数の乱数を生成して確率判定                     //農民の増加確率、hは国家番号で1は農民の番号
                    if (POP_Improve_Toggle.Toggle_Active[i, 1] == true && r.Next(99) < Job_Improve_Percent[h, 1] && POPManager.Province_Farmer_Number_List[i] < POPManager.Province_MAX_POP[i])
                    {
                        POPManager.Province_Farmer_Number_List[i] = POPManager.Province_Farmer_Number_List[i] + 1;
                        //POP総数がMAXを超えた場合の処理
                        if (POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Miner_Number_List[i]
                            + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i] > POPManager.Province_MAX_POP[i])
                        {
                            int j = r2.Next(99);
                            if (j < 100 * POPManager.Province_Miner_Number_List[i] / (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]))
                            {
                                POPManager.Province_Miner_Number_List[i] = POPManager.Province_Miner_Number_List[i] - 1;
                            }
                            else if (j < 100 * (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i]) / (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]))
                            {
                                POPManager.Province_Craftsmen_Number_List[i] = POPManager.Province_Craftsmen_Number_List[i] - 1;
                            }
                            else //if(r2.Next(99) < (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]) / POPManager.Province_MAX_POP[i])
                            {
                                POPManager.Province_Soldier_Number_List[i] = POPManager.Province_Soldier_Number_List[i] - 1;
                            }
                        }
                    }
                }
            }
            //鉱夫
            for (int i = 1; i < Province1Manager.Number_of_Province; i++)
            {
                if (Donating_Country[i] == h)
                {//支配してる国家がhの時なら操作を行う
                    System.Random r = new System.Random(Environment.TickCount + i);
                    System.Random r2 = new System.Random(Environment.TickCount - i);
                    //０から９９までの整数の乱数を生成して確率判定                     //鉱夫の増加確率、hは国家番号で2は鉱夫の番号
                    if (POP_Improve_Toggle.Toggle_Active[i, 2] == true && r.Next(99) < Job_Improve_Percent[h, 2] && POPManager.Province_Miner_Number_List[i] < POPManager.Province_MAX_POP[i])
                    {
                        POPManager.Province_Miner_Number_List[i] = POPManager.Province_Miner_Number_List[i] + 1;
                        //POP総数がMAXを超えた場合の処理
                        if (POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Miner_Number_List[i]
                            + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i] > POPManager.Province_MAX_POP[i])
                        {
                            int j = r2.Next(99);
                            if (j < 100 * POPManager.Province_Farmer_Number_List[i] / (POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]))
                            {
                                POPManager.Province_Farmer_Number_List[i] = POPManager.Province_Farmer_Number_List[i] - 1;
                            }
                            else if (j < 100 * (POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i]) / (POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]))
                            {
                                POPManager.Province_Craftsmen_Number_List[i] = POPManager.Province_Craftsmen_Number_List[i] - 1;
                            }
                            else //if(r2.Next(99) < (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]) / POPManager.Province_MAX_POP[i])
                            {
                                POPManager.Province_Soldier_Number_List[i] = POPManager.Province_Soldier_Number_List[i] - 1;
                            }
                        }
                    }
                }
            }
            //工員
            for (int i = 1; i < Province1Manager.Number_of_Province; i++)
            {
                if (Donating_Country[i] == h)
                { //支配してる国家がhの時なら操作を行う
                    System.Random r = new System.Random(Environment.TickCount + i);
                System.Random r2 = new System.Random(Environment.TickCount - i);
                    //０から９９までの整数の乱数を生成して確率判定                     //工員の増加確率、hは国家番号で3は工員の番号
                    if (POP_Improve_Toggle.Toggle_Active[i, 3] == true && r.Next(99) < Job_Improve_Percent[h, 3] && POPManager.Province_Craftsmen_Number_List[i] < POPManager.Province_MAX_POP[i])
                    {
                        POPManager.Province_Craftsmen_Number_List[i] = POPManager.Province_Craftsmen_Number_List[i] + 1;
                        //POP総数がMAXを超えた場合の処理
                        if (POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Miner_Number_List[i]
                            + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i] > POPManager.Province_MAX_POP[i])
                        {
                            int j = r2.Next(99);
                            if (j < 100 * POPManager.Province_Farmer_Number_List[i] / (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Soldier_Number_List[i]))
                            {
                                POPManager.Province_Farmer_Number_List[i] = POPManager.Province_Farmer_Number_List[i] - 1;
                            }
                            else if (j < 100 * (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Farmer_Number_List[i]) / (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Soldier_Number_List[i]))
                            {
                                POPManager.Province_Miner_Number_List[i] = POPManager.Province_Miner_Number_List[i] - 1;
                            }
                            else //if(r2.Next(99) < (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]) / POPManager.Province_MAX_POP[i])
                            {
                                POPManager.Province_Soldier_Number_List[i] = POPManager.Province_Soldier_Number_List[i] - 1;
                            }
                        }
                    }
                }
            }
            //兵士
            for (int i = 1; i < Province1Manager.Number_of_Province; i++)
            {
                if (Donating_Country[i] == h)
                { //支配してる国家がhの時なら操作を行う
                    System.Random r = new System.Random(Environment.TickCount + i);
                    System.Random r2 = new System.Random(Environment.TickCount - i);
                    //０から９９までの整数の乱数を生成して確率判定                     //兵士の増加確率、hは国家番号で4は兵士の番号
                    if (POP_Improve_Toggle.Toggle_Active[i, 4] == true && r.Next(99) < Job_Improve_Percent[h, 4] && POPManager.Province_Soldier_Number_List[i] < POPManager.Province_MAX_POP[i])
                    {
                        POPManager.Province_Soldier_Number_List[i] = POPManager.Province_Soldier_Number_List[i] + 1;
                        //POP総数がMAXを超えた場合の処理
                        if (POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Miner_Number_List[i]
                            + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i] > POPManager.Province_MAX_POP[i])
                        {
                            int j = r2.Next(99);
                            if (j < 100 * POPManager.Province_Farmer_Number_List[i] / (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i]))
                            {
                                POPManager.Province_Farmer_Number_List[i] = POPManager.Province_Farmer_Number_List[i] - 1;
                            }
                            else if (j < 100 * (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Farmer_Number_List[i]) / (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Farmer_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i]))
                            {
                                POPManager.Province_Miner_Number_List[i] = POPManager.Province_Miner_Number_List[i] - 1;
                            }
                            else //if(r2.Next(99) < (POPManager.Province_Miner_Number_List[i] + POPManager.Province_Craftsmen_Number_List[i] + POPManager.Province_Soldier_Number_List[i]) / POPManager.Province_MAX_POP[i])
                            {
                                POPManager.Province_Craftsmen_Number_List[i] = POPManager.Province_Craftsmen_Number_List[i] - 1;
                            }
                        }
                    }
                }
            }
        }

        int tech = 0;
        int Percent_Tech = 0;
        //技術の取得者の設定
        for(int i =1; i < Number_of_Country; i++)
        {
            tech = tech + Research.Now_Research_Percent[i];//確率度合いを全部足す
        }
        if(tech == 0)
        {
            //誰も投資しなかったらどうなるか
        }
        if(tech == 1)
        {
            Percent_Tech = 0;
        }
        if (tech > 1)
        {
            System.Random r3 = new System.Random();
            Percent_Tech = r3.Next(tech - 1);//０～度合全部の総和-1の中でランダム
            int t2 = 0;
            for (int i = 1; i < Number_of_Country; i++)
            {
                t2 = t2 + Research.Now_Research_Percent[i];
                if (t2 > Percent_Tech)
                {
                    Research.Research_Get_Country[Research.Now_Research_Number] = i;
                    break;
                }
            }
        }
        //技術設定
        Research.Research_Decide(Now_Turn_Number);
        gameobject.GetComponent<Research>().Print_Research();


        //収入計算、最後にやる
        for (int i = 1; i < POPManager.Province_Farmer_Number_List.Length; i++)
        {
            ProvinceIncomeManager.Province_Income_List[i] = Convert.ToInt32(Math.Round((decimal)POPManager.Province_Farmer_Number_List[i] * ProvinceIncomeManager.Farmer_Income * Stability_Manager.Province_Stability_List[i] / 100));
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Math_Myself
{
    public static T Max<T>(params T[] nums) where T : IComparable
    {
        if (nums.Length == 0) return default(T);

        T max = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            max = max.CompareTo(nums[i]) > 0 ? max : nums[i];
            // Minの場合は不等号を逆にすればOK
        }
        return max;
    }
    public static T Min<T>(params T[] nums) where T : IComparable
    {
        if (nums.Length == 0) return default(T);

        T min = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            min = min.CompareTo(nums[i]) < 0 ? min : nums[i];

        }
        return min;
    }
}