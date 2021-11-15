using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallProjection : MonoBehaviour
{
     public float MinX, MaxX,MinY,MaxY;  
    BoxCollider box;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MaxX = box.bounds.max.x;
        MaxY = box.bounds.max.y;
        MinY = box.bounds.min.y;
        MinX = box.bounds.min.x;
    }
}
