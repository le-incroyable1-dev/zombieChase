using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private GameObject player;
    private Transform player_transform;
    private Vector3 position;
    public float xchange, yref, zref;
    
  
    //private float x;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        player_transform = player.GetComponent<Transform>();
        position.x = player_transform.position.x + xchange;

        transform.position = new Vector3(position.x, yref, zref);

        
        
    }
}
