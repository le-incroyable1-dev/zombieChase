using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlayerCheck : MonoBehaviour
{

    public GameObject player;
    private CapsuleCollider2D coll;
    public bool playerAbove;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coll = GetComponent<CapsuleCollider2D>();
        playerAbove = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y>=-2 && player.transform.position.x >= gameObject.transform.position.x - 7)
        {
           
            playerAbove = true;
        }
        else
        {
            
            playerAbove = false;
        }

        coll.enabled = playerAbove;
        
    }
}
