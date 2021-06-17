using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int gold = 0;
    Text Scorevalue;
    
    // Start is called before the first frame update
    void Start()
    {
        Scorevalue = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Scorevalue.text = "Score: " + gold;
    }
}
