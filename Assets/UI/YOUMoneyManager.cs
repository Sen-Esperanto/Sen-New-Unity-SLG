using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YOUMoneyManager : MonoBehaviour
{
    public static int YOUmoney = 1000;
    public GameObject YOUmoney_object = null;

    //国庫金
    public static int[] Money_in_Country = new int[TurnEndManager.Number_of_Country];
    // Start is called before the first frame update
    void Start()
    {
        Money_in_Country[1] = 1000; //陽帝国の初期所持金
    }

    // Update is called once per frame
    void Update()
    {
        Text YOUMoney_text = YOUmoney_object.GetComponent<Text>();

        YOUMoney_text.text = "国庫：" + YOUmoney.ToString();
    }
}
