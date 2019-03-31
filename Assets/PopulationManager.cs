using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationManager : MonoBehaviour
{
    
    public static int[] Province_Population_List = new int[100] { //プロビ数
        0, // Province0なので0にしておく
        300000, // Province1の人口
        2,  //行を見て人口数書き込み
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

    private string PopNum = null;

    public GameObject Population_object = null;
    public static int Population_Number = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //　↓オブジェクトからtextコンポーネントを取得
        Text Population_Text = Population_object.GetComponent<Text>();
        //　↓テキストの表示を変える
        PopNum = String.Format("{0:#,0}", Province_Population_List[Province1Manager.Choosing_ProvinceNumber]);
        Population_Text.text = "人口：" + PopNum;
    }
}
