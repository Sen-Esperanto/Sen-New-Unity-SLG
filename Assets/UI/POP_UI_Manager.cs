using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POP_UI_Manager : MonoBehaviour
{
    public GameObject POP_UI_Manager_gameobject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text POP_UI_Manager_text = POP_UI_Manager_gameobject.GetComponent<Text>();


        POP_UI_Manager_text.text = "POP" + "\n農民：" + POPManager.Province_Farmer_Number_List[Province1Manager.Choosing_ProvinceNumber].ToString()
                                    + " / " + POPManager.Province_MAX_Farmer[Province1Manager.Choosing_ProvinceNumber]
                                    + "\n鉱夫：" + POPManager.Province_Miner_Number_List[Province1Manager.Choosing_ProvinceNumber].ToString()
                                    + "\n工員：" + POPManager.Province_Craftsmen_Number_List[Province1Manager.Choosing_ProvinceNumber].ToString()
                                    + "\n兵士：" + POPManager.Province_Soldier_Number_List[Province1Manager.Choosing_ProvinceNumber].ToString();
        
    }

}//Province1Manager.Choosing_ProvinceNumber
