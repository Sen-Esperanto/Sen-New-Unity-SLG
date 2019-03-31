using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building_UI_Manager : MonoBehaviour
{
    public Image Fearture1_UI = null;
    private Sprite sprite;
    public int i = 1;

    public void Method(int i)
    {
        switch (Province_Building_Manager.Province_Building[Province1Manager.Choosing_ProvinceNumber,i-1])//選択してるプロビの建造物１
        {
            case "兵舎":
                sprite = Resources.Load<Sprite>("兵舎");
                Fearture1_UI = this.GetComponent<Image>();
                Fearture1_UI.sprite = sprite;
                break;
            //上の式を建物ごとに作る

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
