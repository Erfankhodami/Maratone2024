using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Random = System.Random;

public class TrucksManager : MonoBehaviour
{
    private SplineAnimate _splineAnimate;
    public int Capacity;
    public SplineContainer[] SplineContainers;
    private void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            SplineContainers[i-1] = GameObject.Find("Spline" + i.ToString()).GetComponent<SplineContainer>();
        }
        
        _splineAnimate=GetComponent<SplineAnimate>();
        _splineAnimate.Pause();
        _splineAnimate.splineContainer=SplineContainers[UnityEngine.Random.Range(0,5)];

    }

    void Update()
    {
        _splineAnimate.ElapsedTime += .001f;
        print(_splineAnimate.ElapsedTime);
        
        if (_splineAnimate.ElapsedTime > 1)
        {
            MainManager.instance.OccupiedCapacity += 50;
            Destroy(gameObject);
        }
    }
}
