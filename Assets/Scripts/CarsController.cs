using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour
{
    [SerializeField] private GameObject CarPrefab;

    [SerializeField] private Transform CarSpawn;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Instansiatecars());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Instansiatecars()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        GameObject SpawnedCar=Instantiate(CarPrefab, CarSpawn);
        SpawnedCar.GetComponent<Rigidbody2D>().velocity = (Vector2.up*10);
        StartCoroutine(Instansiatecars());
    }
}
