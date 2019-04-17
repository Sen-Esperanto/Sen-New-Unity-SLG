using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public const int Number_of_Kind_of_Factory = 31;//本来の数+１
    public static int[][] Factory_in_Country = new int[Number_of_Kind_of_Factory][];//[工場の種類][プロビ] = 数
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
