using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Setup")]
    public bool posX;
    public bool negX;
    public bool posZ;
    public bool negZ;

    public List<GameObject> placeableStructures = new List<GameObject>();

    [Header("Information")]
    public GameObject currentStucture = null;

    [HideInInspector] public Tile _X;
    [HideInInspector] public Tile _Y;

    [HideInInspector] public Generator generator;

    public void AddStructures()
    {
        if(currentStucture != null)
        {
            DestroyImmediate(currentStucture);
            currentStucture = null;
        }

        if (_Y != null)
        {
            if (!_Y.posX && !_Y.posZ && !_Y.negX && !_Y.negZ)
            {
                if (Random.Range(0, 2) == 0)
                {
                    Place();
                }
            }
            else
            {
                Place();
            }
        }
        else
        {
            Place();
        }
    }

    void Place()
    {
        if(placeableStructures.Count > 0)
        {
            int number = Random.Range(-generator.structureEmptyTileRate, placeableStructures.Count);

            if(number >= 0)
            {
                Transform child = transform.GetChild(0).transform;

                GameObject structure = Instantiate(placeableStructures[number]);
                structure.name = "Structure";
                structure.transform.SetParent(child);
                structure.transform.localPosition = new Vector3(0, generator.is3D ? generator.structureYOffset : 0, 0);
                structure.transform.localRotation = Quaternion.identity;

                currentStucture = structure;
            }
        }
    }
}
