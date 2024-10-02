using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class MainManager : MonoBehaviour
{

    public static MainManager instance;

    public GameObject GarbageTruckPrefab;
    public float TrucksSpawnRate=5;
    
    void Start()
    {
        instance = GetComponent<MainManager>();
        //hello
        StartCoroutine(SpawnCar());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnCar()
    {
        GameObject g=Instantiate(GarbageTruckPrefab);
        g.GetComponent<SplineAnimate>().MaxSpeed = 1;
        yield return new WaitForSeconds(TrucksSpawnRate);
        StartCoroutine(SpawnCar());
    }
    
}
