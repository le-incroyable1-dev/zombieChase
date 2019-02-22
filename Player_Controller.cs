using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public bool OnTile = false;
    public float JumpForce;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(Jumper());
		
	}

    private void OnTriggerEnter2D(Collider2D collisionenter)
    {
        if(collisionenter.gameObject.CompareTag("Tile"))
        {
            OnTile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collisionexit)
    {
        if (collisionexit.gameObject.CompareTag("Tile"))
        {
            OnTile = false;
        }
    }

    private IEnumerator Jumper()
    {
        Vector2 force = new Vector2(0, JumpForce);
        if (Input.GetKeyDown(KeyCode.Space) && OnTile)
        {
            rb.AddForce(force);
       
        }
        yield return null;
    }
}
