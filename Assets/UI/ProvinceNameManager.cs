using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProvinceNameManager : MonoBehaviour
{
    public GameObject ProvinceName_object = null;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text ProvinceName_text = ProvinceName_object.GetComponent<Text>();

        ProvinceName_text.text = Province1Manager.Province1Name;
    }
}
