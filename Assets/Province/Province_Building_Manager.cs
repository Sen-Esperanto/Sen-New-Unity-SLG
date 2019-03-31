using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Province_Building_Manager : MonoBehaviour
{
    /*public static List<string>[] Province_Building = new List<string>[100];
    public static List<string>[] Province_Fearture = new List<string>[100];
    
    };
    // Start is called before the first frame update
    void Start()
    {
        Province_Building[0] = new List<string>()
        {};//ここは空
        Province_Building[1] = new List<string>()
        { //プロビ１の建造物
             "兵舎",
        };

        Province_Fearture[0] = new List<string>() {
        "test","test","test" };
        Province_Fearture[1] = new List<string>() {
            "石炭鉱山","農地", "農地", "農地"
        };
    }*/
    public static int Farm_Supply_Farmer = 5;


    public static string[,] Province_Building = new string[,] //左がプロビ番号　右が建造物番号
    {
        { "","","","","","","","","","","",""},//プロビ０は空
        { "兵舎","","","","","","","","","","",""},
        { "","","","","","","","","","","",""},
        { "","","","","","","","","","","",""},
        { "","","","","","","","","","","",""},
    };

    public static string[,] Province_Fearture = //左がプロビ番号　右が特徴番号
    {
        { "","","","","","","","","","","",""},//プロビ０は空
        { "石炭鉱山","農地","農地","農地","","","","","","","",""},
        { "","","","","","","","","","","",""},
        { "","","","","","","","","","","",""},
        { "","","","","","","","","","","",""},
    };

    // Update is called once per frame
    void Update()
    {
        
    }
}
