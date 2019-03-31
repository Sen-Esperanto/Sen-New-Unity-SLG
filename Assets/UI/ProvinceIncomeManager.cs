using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceIncomeManager : MonoBehaviour
{
    public GameObject ProvinceIncome_object = null;
    //public static int ProvinceIncome = 0;
    public static int[] Province_Income_List = new int[100];
    public static int Farmer_Income = 5;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 1; i < POPManager.Province_Farmer_Number_List.Length; i++)
        {
            Province_Income_List[i] = POPManager.Province_Farmer_Number_List[i] * Farmer_Income;
        }
    }


    // Update is called once per frame
    void Update()
    {


        Text ProvinceIncome_text = ProvinceIncome_object.GetComponent<Text>();

        ProvinceIncome_text.text = "収入：" + Province_Income_List[Province1Manager.Choosing_ProvinceNumber].ToString();
    }
}
