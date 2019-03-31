using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgricultureManager : MonoBehaviour
{
    public static int Province1Agriculture = 60;
    public GameObject Province1Agriculture_object = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text Province1Agriculture_text = Province1Agriculture_object.GetComponent<Text>();

        Province1Agriculture_text.text = "農業：" + Province1Agriculture.ToString();
    }
}
