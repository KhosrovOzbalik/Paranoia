using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FinalAnimationScript : MonoBehaviour
{   
    public GameObject tile1,
        tile2,
        tile3,
        full;
    private int layer = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tileChange());
    }
    IEnumerator tileChange(){
        yield return new WaitForSeconds(1);
        tile1.GetComponent<TilemapRenderer>().sortingOrder = layer;
        yield return new WaitForSeconds(1.5f);
        tile2.GetComponent<TilemapRenderer>().sortingOrder = layer;
        yield return new WaitForSeconds(2f);
        tile3.GetComponent<TilemapRenderer>().sortingOrder = layer;
        yield return new WaitForSeconds(3f);
        full.GetComponent<TilemapRenderer>().sortingOrder = layer;
    }
}
