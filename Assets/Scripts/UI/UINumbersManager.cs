using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UINumbersManager : MonoBehaviour
{
    public bool Active = false;

    [Space]
    public float garbages;

    public float peopleAmount = 2500f;
    public TextMeshProUGUI peopleText;

    public float money;
    public TextMeshProUGUI moneyText;

    public float peopleHappiness = 60f;
    public Slider happinessSlider;

    public float cityDirtiness = 5f;
    public Slider dirtinessSlider;

    void Update()
    {
        if (Active)
        {
            peopleText.text = Mathf.Round(peopleAmount).ToString();
            moneyText.text = Mathf.Round(money).ToString() + "$";

            happinessSlider.value = Mathf.Round(peopleHappiness);
            dirtinessSlider.value = Mathf.Round(cityDirtiness);
        }
    }
}
