using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Research_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Onclick()
    {
        for(int i = 1; i < Research.Number_of_Research; i++)
        {
            if (Research.First_Research_Attribute[Research.Now_Research_Number] == i)
            {
                Research.Research_Point[First_Choose_Country_UI.Playing_Country][i] = Research.Research_Point[First_Choose_Country_UI.Playing_Country][i] - 1;
                Research.Now_Research_Percent[First_Choose_Country_UI.Playing_Country] = Research.Now_Research_Percent[First_Choose_Country_UI.Playing_Country] + 1;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
