using System;
using UnityEngine;
using UnityEngine.UI;

public class UINumbersManager : MonoBehaviour
{
    public int currentGarbages;
    public int maximumGarbages;
    public Text garbageText;

    public int peopleAmount;
    public Text peopleText;

    public int money;
    public Text moneyText;

    void Start()
    {
        //money = MainManager.instance.Money;
    }

    void Update()
    {
        garbageText.text = "Recycle " + currentGarbages.ToString() + " / " + maximumGarbages.ToString();
        peopleText.text = peopleAmount.ToString();
        moneyText.text = money.ToString() + "$";
        MainManager.instance.TrucksSpawnRate = 8;
    }
    
    
}
