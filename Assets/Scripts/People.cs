using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class People : MonoBehaviour
{
    public float peopleMoney = 0.1f;
    public float peopleDrityness = 0.01f;
    public float peopleGarbage = 0.05f;

    public float treeUsage = 0f;

    public Volume postProcessing;

    private UINumbersManager UINumbers;
    private Leaderboard leaderboard;

    private ColorAdjustments color;

    void Start()
    {
        UINumbers = GetComponent<UINumbersManager>();
        leaderboard = GetComponent<Leaderboard>();
        Invoke("PeopleBehaviour", 0f);

        postProcessing.profile.TryGet<ColorAdjustments>(out color);
    }

    void Update()
    {
        if (UINumbers.cityDirtiness > 100f)
        {
            UINumbers.cityDirtiness = 100f;
        }
        else if (UINumbers.cityDirtiness < 0f)
        {
            UINumbers.cityDirtiness = 0f;
        }

        if (UINumbers.peopleHappiness > 100f)
        {
            UINumbers.peopleHappiness = 100f;
        }
        else if (UINumbers.peopleHappiness < 0f)
        {
            UINumbers.peopleHappiness = 0f;
        }

        if (UINumbers.money < 0f)
        {
            UINumbers.money = 0f;
        }

        if (UINumbers.peopleAmount < 0f)
        {
            UINumbers.peopleAmount = 0f;
        }

        if (UINumbers.garbages < 0f)
        {
            UINumbers.garbages = 0f;
        }

        leaderboard.peopleAmount.text = Mathf.Round(UINumbers.peopleAmount).ToString();

        color.saturation.value = -UINumbers.cityDirtiness;
        color.contrast.value = -UINumbers.cityDirtiness * 0.8f;
    }

    void PeopleBehaviour()
    {
        //Happiness

        if (UINumbers.peopleHappiness > 60f)
        {
            UINumbers.peopleAmount += UINumbers.peopleAmount / 1000f;
        }
        else if (UINumbers.peopleHappiness < 40f)
        {
            UINumbers.peopleAmount -= UINumbers.peopleAmount / 1000f;
        }

        //Garbage

        UINumbers.garbages += peopleGarbage * UINumbers.peopleAmount;

        float isGarbageDamaging;
        if (UINumbers.garbages > 5000)
        {
            isGarbageDamaging = (UINumbers.garbages - 5000) / 1000;
        }
        else
        {
            isGarbageDamaging = -UINumbers.garbages / 1000;
        }

        UINumbers.peopleHappiness -= isGarbageDamaging + (UINumbers.cityDirtiness / 20);

        //Income

        UINumbers.money += peopleMoney * UINumbers.peopleAmount;

        //Dirtiness

        UINumbers.cityDirtiness += ((peopleDrityness * UINumbers.peopleAmount) / 10f) + (-treeUsage);

        Invoke("PeopleBehaviour", 1f);
    }

    public void AddDirtness(float value)
    {
        UINumbers.cityDirtiness += value;
    }
}
