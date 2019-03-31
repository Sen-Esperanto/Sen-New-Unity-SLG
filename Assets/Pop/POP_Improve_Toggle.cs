using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POP_Improve_Toggle : MonoBehaviour
{
    //インスペクタからトグルを設定するようにしました。
    //[SerializeField]


    //public int i;
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Toggle toggle4;
    
    public static bool[,] Toggle_Active = new bool[Province1Manager.Number_of_Province,7]; //左がプロビ番号　右は職ごと
 
    void Update()
    {
        //if (i == 1)//農民
        
            try { Toggle_Active[Province1Manager.Choosing_ProvinceNumber, 1] = toggle1.isOn;
            }
            catch { Debug.Log("Cannot read toggle"); }
        
       // if (i == 2)//鉱夫
        
            try { Toggle_Active[Province1Manager.Choosing_ProvinceNumber, 2] = toggle2.isOn; }
            catch { }
        
        //if (i == 3)//工員
        
            try { Toggle_Active[Province1Manager.Choosing_ProvinceNumber, 3] = toggle3.isOn; }
            catch { }
        
        //if (i == 4)//兵士
        
            try { Toggle_Active[Province1Manager.Choosing_ProvinceNumber, 4] = toggle4.isOn; }
            catch { }
        /*
        //if (i == 5)
        
            try { Toggle_Active[Province1Manager.Choosing_ProvinceNumber, 5] = toggle5.isOn; }
            catch { }
        
        //if (i == 6)
        
            try { Toggle_Active[Province1Manager.Choosing_ProvinceNumber, 6] = toggle6.isOn; }
            catch { }
        */
        //トグルのオン/オフ イベントを受け取れます
        //toggle.onValueChanged.AddListener(changeToggleEvent);

        //isOnで状態を取得できます
       

        //代入も可能です
        //toggle.isOn = false;
    }

    /*void changeToggleEvent(bool isActive)
    {
        Debug.Log(string.Format("今のトグルの状態 : {0}", isActive));
   }*/ 
}
