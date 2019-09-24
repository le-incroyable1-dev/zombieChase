using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour {

    public float translatespeed;
    private bool IsBg;
    private bool IsPlayer;
    public bool goesBack;


    private Transform player;
    //private Transform thistransform;
    //public bool TilePosError;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        //thistransform = gameObject.GetComponent<Transform>();
        if(gameObject.CompareTag("Streetlight"))
        {
            transform.Translate(0, 1, 0);
        }

        if (gameObject.CompareTag("Bg"))
        {
            IsBg = true;
        }
        if(gameObject.CompareTag("Player") || gameObject.CompareTag("Forward"))
        {
            IsPlayer = true;
        }
        else if(gameObject.CompareTag("Zombie1") || gameObject.CompareTag("Zombie2") || gameObject.CompareTag("Cure") || gameObject.CompareTag("GunPickup") || gameObject.CompareTag("Bg") || gameObject.CompareTag("Sword"))
        {
            goesBack = true;
        }




    }
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(MoveBackward());

        


     }


    /*private void OnTriggerEnter2D(CapsuleCollider2D other)
    {
        if (gameObject.CompareTag("Tile") && other.gameObject.CompareTag("Tile"))
        {
            TilePosError = true;
            //other.gameObject.transform.position = gameObject.GetComponentInChildren<Transform>().position;
        }
       
    }

    private void OnTriggerExit2D(CapsuleCollider2D otherx)
    {
        if (gameObject.CompareTag("Tile") && otherx.gameObject.CompareTag("Tile"))
        {
            TilePosError = false;
            //other.gameObject.transform.position = gameObject.GetComponentInChildren<Transform>().position;
        }

    }*/

    private IEnumerator MoveBackward()
    {


        //transform.Translate(translatespeed, 0, 0);

        if(!IsPlayer)
        {
            if(transform.position.x <= player.position.x - 25)
            {
                Destroy(gameObject);
            }

            if(goesBack)
            {
                float backSpeed = -(translatespeed/10);
                transform.Translate(backSpeed, 0, 0);
            }
        }
        else if(IsPlayer)
        {
            transform.Translate(translatespeed, 0, 0);
        }

        yield return null;

    }
}
