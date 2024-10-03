using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CarsController : MonoBehaviour
{
    [SerializeField] private SplineAnimate _splineAnimate;
    [SerializeField] private List<SplineContainer> _splineContainers;

    void Start()
    {
        _splineAnimate = GetComponent<SplineAnimate>();
    }

    void Update()
    {
        _splineAnimate.ElapsedTime += .0003f;
        if (_splineAnimate.ElapsedTime > 1)
        {
            Destroy(gameObject);
        }
    }
}
