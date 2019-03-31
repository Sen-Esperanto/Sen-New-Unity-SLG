using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Province1Manager : MonoBehaviour
{
    public static string Province1Name = "東京";
    public static int Choosing_ProvinceNumber = 1;
    public static int Grain_Resources = 15;
    public static int Number_of_Province = 100;
    



    private Text targetText; // <---- 追加2

    void Print()
    {

        this.targetText = this.GetComponent<Text>(); // <---- 追加3
        this.targetText.text = Province1Name; // <---- 追加4
    }
        void Start()
        {
        }


    public void OnClick(int number)
    {
        MyCanvas.SetActive("ProvinceUIBackground", true);
        switch (number)
        {
            case 1: Choosing_ProvinceNumber = 1; break;
            case 2: Choosing_ProvinceNumber = 2; break;
            case 3: Choosing_ProvinceNumber = 3; break;
            case 4: Choosing_ProvinceNumber = 4; break;
            case 5: Choosing_ProvinceNumber = 5; break;
            case 6: Choosing_ProvinceNumber = 6; break;
            case 7: Choosing_ProvinceNumber = 7; break;
            case 8: Choosing_ProvinceNumber = 8; break;
            case 9: Choosing_ProvinceNumber = 9; break;
            case 10: Choosing_ProvinceNumber = 10; break;
            case 11: Choosing_ProvinceNumber = 11; break;
            case 12: Choosing_ProvinceNumber = 12; break;
            case 13: Choosing_ProvinceNumber = 13; break;
            case 14: Choosing_ProvinceNumber = 14; break;
            case 15: Choosing_ProvinceNumber = 15; break;


            default:
        break;
    }
    }
}
