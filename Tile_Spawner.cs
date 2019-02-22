using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile_Spawner : MonoBehaviour {

    

    //public float translatespeed;
    public GameObject[] tiles;
    public Transform[] spawnPos;
    public float SpawnRepeatRate;

    // Use this for initialization
    void Start () {

        InvokeRepeating("SpawnTiles", 0.5f, SpawnRepeatRate);

    }

    // Update is called once per frame
    /*void Update () {

        StartCoroutine(MoveBackward());

        

    }

    private IEnumerator MoveBackward()
    {
        

        GameObject.FindGameObjectWithTag("Tile").transform.Translate(translatespeed, 0, 0);

        yield return null;

    }*/

     
    void SpawnTiles()
    {
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(tiles[(int)(UnityEngine.Random.Range(0, tiles.Length))], spawnPos[(int)(UnityEngine.Random.Range(0, spawnPos.Length))].position, rotation);

    }


 
    
   
}
