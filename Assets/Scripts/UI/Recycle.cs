using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recycle : MonoBehaviour
{
    public UINumbersManager UINumbers;

    public void RecycleGarbages()
    {
        UINumbers.currentGarbages = 0;
        
        /*if(UINumbers.currentGarbages)
        {

        }*/
    }
}
