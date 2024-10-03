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
    public GameObject trash = null;

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

        Place();
    }

    public void RemoveStuctures()
    {
        if (currentStucture != null)
        {
            DestroyImmediate(currentStucture);
            currentStucture = null;
        }
    }

    void Place()
    {
        if(placeableStructures.Count > 0)
        {
            int number = Random.Range(-generator.emptyTileRate, placeableStructures.Count);

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

    public void PlaceTrash()
    {
        if(trash == null)
        {
            int number = Random.Range(-3, placeableStructures.Count);

            if (number >= 0)
            {
                GameObject trash = Instantiate(generator.trashes[number]);
                trash.name = "Trash";
                trash.transform.SetParent(transform);
                trash.transform.localPosition = new Vector3(Random.Range(-1, 1), generator.is3D ? generator.structureYOffset : Random.Range(-1, 1), 0);
                trash.transform.localRotation = Quaternion.identity;

                this.trash = trash;
            }
        }
    }

    public void RemoveTrashes()
    {
        if (trash != null)
        {
            DestroyImmediate(trash);
            trash = null;
        }
    }
}
