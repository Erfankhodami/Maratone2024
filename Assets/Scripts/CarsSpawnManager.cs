using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CarsSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> NpcCars;
    [SerializeField] private List<SplineContainer> SplineContainers;

    void Start()
    {
        StartCoroutine(NpcCarsSpawn());
    }

    IEnumerator NpcCarsSpawn()
    {
        GameObject gm = Instantiate(NpcCars[Random.Range(0, NpcCars.Count)]);
        gm.GetComponent<SplineAnimate>().Container = SplineContainers[Random.Range(0, SplineContainers.Count)];
        yield return new WaitForSeconds(5);
        StartCoroutine(NpcCarsSpawn());
    }
}
