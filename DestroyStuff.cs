using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStuff : MonoBehaviour {

    //public float translatespeed;

    //public GameObject destroySpawn;
    //public bool ObjectIn;

    // Use this for initialization
    void Start () {

        
		
	}

    // Update is called once per frame
    void Update ()
    {
        //StartCoroutine(MoveForward());


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //ObjectIn = true;
        //Instantiate(destroySpawn, other.gameObject.transform.position, other.gameObject.transform.rotation);
        if(!other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    /*private IEnumerator MoveForward()
    {

        transform.Translate(translatespeed, 0, 0);

        yield return null;

    }*/
}
