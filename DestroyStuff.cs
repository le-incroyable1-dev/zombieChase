using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStuff : MonoBehaviour {

    //public float translatespeed;

    public GameObject destroySpawn;

    // Use this for initialization
    /*void Start () {

        
		
	}

    // Update is called once per frame
    void Update ()
    {
        StartCoroutine(MoveForward());


    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(destroySpawn, other.gameObject.transform.position, other.gameObject.transform.rotation);
        Destroy(other.gameObject);
    }

    /*private IEnumerator MoveForward()
    {

        transform.Translate(translatespeed, 0, 0);

        yield return null;

    }*/
}
