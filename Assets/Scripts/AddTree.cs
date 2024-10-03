using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddTree : MonoBehaviour
{
    public int x = 15;
    public int y = 15;

    public float upgradeValue = 2f;
    public float upgradeCost = 20f;

    public int currentUpgrade = 0;
    public int maxUpgrade = 10;

    public TextMeshProUGUI upgradeMoney;
    public TextMeshProUGUI text;
    public Button button;

    private People people;
    private UINumbersManager UINumbers;

    void Start()
    {
        people = GetComponent<People>();
        UINumbers = GetComponent<UINumbersManager>();
    }

    void Update()
    {
        text.text = currentUpgrade.ToString() + " / " + maxUpgrade.ToString();
        upgradeMoney.text = Mathf.Round(upgradeCost).ToString() + "$";

        if(UINumbers.money < upgradeCost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }

        if(currentUpgrade == maxUpgrade)
        {
            button.interactable = false;
        }
    }

    public void AddOrUpgrade()
    {
        if(currentUpgrade < maxUpgrade)
        {
            if (UINumbers.money >= upgradeCost)
            {
                if (people.treeUsage == 0)
                {
                    for (int y = 0; y < this.y; y++)
                    {
                        for (int x = 0; x < this.x; x++)
                        {
                            if (GetTileFromAddress(x, y).tag == "Grass")
                            {
                                GetTileFromAddress(x, y).AddStructures();
                            }
                        }
                    }
                }

                people.treeUsage += upgradeValue;
                UINumbers.money = UINumbers.money - upgradeCost;
                upgradeCost = upgradeCost + (upgradeCost / 3);
                currentUpgrade++;
            }
        }
    }

    public Tile GetTileFromAddress(int x, int y)
    {
        string name = "X" + x + ".Y" + y;
        return GameObject.Find(name).GetComponent<Tile>();
    }
}
