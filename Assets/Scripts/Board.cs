using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tileObject;

    void Start()
    {
        SetupBoard();
    }

    private void SetupBoard()
    {
        for(int x = 0; x < width; x++) 
        { 
            for(int y = 0; y < height; y++)
            {
                var o = Instantiate (tileObject, new Vector3(x,y,-5), Quaternion.identity);
                o.transform.parent = transform;
            }
        }
    }

    void Update()
    {
        
    }
}
