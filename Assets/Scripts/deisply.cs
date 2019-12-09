using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deisply : MonoBehaviour
{
    public string theName;
    public GameObject inputfield;
    public GameObject textdisply;

    public void Storename()
    {
        theName = inputfield.GetComponent<Text>().text;
        textdisply.GetComponent<Text>().text = "WElcome" + theName + "ARe"; 

    }


}
