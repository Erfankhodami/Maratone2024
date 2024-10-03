using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BnanaSkinsConroller : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // A GameObject was clicked!
                if (hit.collider.name == "BnanaSkin")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

