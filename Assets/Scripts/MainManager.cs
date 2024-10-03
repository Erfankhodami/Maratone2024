using System.Collections;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public GameObject GarbageTruckPrefab;
    
    void Start()
    {
        Application.targetFrameRate = 144;
        instance = GetComponent<MainManager>();
        StartCoroutine(SpawnCar(1, 1));
    }

    public IEnumerator SpawnCar(float spawnTime, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(GarbageTruckPrefab);
            yield return new WaitForSeconds(spawnTime / amount);
        }
    }
}
