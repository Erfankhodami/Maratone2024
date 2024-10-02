using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class MainManager : MonoBehaviour
{

    public static MainManager instance;

    public int Money;
    public GameObject GarbageTruckPrefab;
    public float TrucksSpawnRate=5;
    public int Capacity=200;
    public int OccupiedCapacity;
    void Start()
    {
        instance = GetComponent<MainManager>();
        //hello
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        GameObject g=Instantiate(GarbageTruckPrefab);
        yield return new WaitForSeconds(TrucksSpawnRate);
        StartCoroutine(SpawnCar());
    }

    public void UpgradeTrucks()
    {
        TrucksSpawnRate -= 1;
    }
    
}
