using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceCloseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        MyCanvas.SetActive("Population", false);
        MyCanvas.SetActive("ProvinceUIBackground", false);
        MyCanvas.SetActive("ProvinceClose", false);
        MyCanvas.SetActive("ProvinceName", false);
        MyCanvas.SetActive("POP_UI", false);
        MyCanvas.SetActive("ProvinceIncome", false);
    }
}
