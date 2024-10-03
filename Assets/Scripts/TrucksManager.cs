using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class TrucksManager : MonoBehaviour
{
    private SplineAnimate _splineAnimate;

    private void Start()
    {
        _splineAnimate = GetComponent<SplineAnimate>();
        _splineAnimate.Pause();
    }

    void Update()
    {
        _splineAnimate.ElapsedTime += 0.0003f;

        if (_splineAnimate.ElapsedTime > 1)
        {
            Destroy(gameObject);
        }
    }
}
