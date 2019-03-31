using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgricultureImproveManager : MonoBehaviour
{
    public void OnClick()
    {
        AgricultureManager.Province1Agriculture = AgricultureManager.Province1Agriculture + 5;
        YOUMoneyManager.YOUmoney = YOUMoneyManager.YOUmoney - 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
