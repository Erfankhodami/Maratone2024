using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class CompanyManager : MonoBehaviour
{
    public int x = 15;
    public int y = 15;

    public float companyDirtiness = 50f;
    public int companyTrucks = 5;
    public float trucksDirtiness = 0.02f;
    public float trucksSpawnTime = 10f;

    public float upgradeCost = 20f;

    public TextMeshProUGUI upgradeMoney;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    public Button button;
    public Button button1;

    public GameObject GarbageTruckPrefab;

    public GameObject particle;

    [SerializeField] private List<SplineContainer> SplineContainers;

    private UINumbersManager UINumbers;

    void Start()
    {
        UINumbers = GetComponent<UINumbersManager>();
    }

    public void StartCompany()
    {
        GetComponent<People>().AddDirtness(companyDirtiness + (companyTrucks * trucksDirtiness));
        StartCoroutine(SpawnCar(trucksSpawnTime, companyTrucks));
        UINumbers.garbages = 0f;
    }

    void Update()
    {
        text.text = companyTrucks.ToString();
        text1.text = companyTrucks.ToString();
        upgradeMoney.text = Mathf.Round(upgradeCost).ToString() + "$";

        if (UINumbers.money < upgradeCost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void AddTrucks()
    {
        companyTrucks++;
        UINumbers.money = UINumbers.money - upgradeCost;
        upgradeCost = upgradeCost + (upgradeCost / 3);
        trucksSpawnTime++;
    }

    public IEnumerator SpawnCar(float spawnTime, int amount)
    {
        button1.interactable = false;

        particle.SetActive(true);

        for (int i = 0; i < amount; i++)
        {
            GameObject gm = Instantiate(GarbageTruckPrefab);
            gm.GetComponent<SplineAnimate>().Container = SplineContainers[Random.Range(0, SplineContainers.Count)];
            yield return new WaitForSeconds(spawnTime / amount);
        }

        button1.interactable = true;

        particle.SetActive(false);

        for (int y = 0; y < this.y; y++)
        {
            for (int x = 0; x < this.x; x++)
            {
                if (GetTileFromAddress(x, y).tag == "Grass")
                {
                    GetTileFromAddress(x, y).RemoveTrashes();
                }
            }
        }
    }

    public Tile GetTileFromAddress(int x, int y)
    {
        string name = "X" + x + ".Y" + y;
        return GameObject.Find(name).GetComponent<Tile>();
    }
}
