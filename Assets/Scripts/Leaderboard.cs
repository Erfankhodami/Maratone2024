using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<TextMeshProUGUI> peopleAmounts;
    public TMP_InputField inputField;
    public TextMeshProUGUI name;
    public TextMeshProUGUI peopleAmount;

    void Start()
    {
        foreach (TextMeshProUGUI text in peopleAmounts)
        {
            text.text = Random.Range(10000, 2000000).ToString();
        }
    }

    public void ChangeName()
    {
        name.text = inputField.text;
    }
}
