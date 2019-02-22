using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour {

    public float translatespeed;
	// Use this for initialization
	/*void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(MoveBackward());


		
	}

    private IEnumerator MoveBackward()
    {


        transform.Translate(translatespeed, 0, 0);

        yield return null;

    }
}
