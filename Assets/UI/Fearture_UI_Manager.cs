using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Fearture_UI_Manager : MonoBehaviour
{
    public Image Fearture1_UI = null;
    private Sprite sprite;
    public int i = 1;
    public static string Str = "農地";

    public void Method(int i)
    {
        Str = Province_Building_Manager.Province_Fearture[Province1Manager.Choosing_ProvinceNumber,i - 1];
        //選択してるプロビの建造物i番目(-1はリストが0から始まるため)
        switch (Str) 
        {
            case "農地":
                sprite = Resources.Load<Sprite>("農地");
                Fearture1_UI = this.GetComponent<Image>();
                Fearture1_UI.sprite = sprite;
                
                break;
            case "石炭鉱山":
                sprite = Resources.Load<Sprite>("石炭鉱山");
                Fearture1_UI = this.GetComponent<Image>();
                Fearture1_UI.sprite = sprite;
                
                break;　//特徴の種類分追加

            default:
                sprite = Resources.Load<Sprite>("NOIMAGE");
                Fearture1_UI = this.GetComponent<Image>();
                Fearture1_UI.sprite = sprite;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {


}

    // Update is called once per frame
    void Update()
    {
        Method(i);

    }

}
