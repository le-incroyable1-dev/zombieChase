using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{

    public AudioClip midloop;
    public AudioClip highloop;

    //public float highloopendtime;

    private AudioSource src;
    private bool currentClipOver;

    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);

        src = GetComponent<AudioSource>();

        src.loop = true;
        src.clip = midloop;
        src.Play();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Zombie1") || collision.gameObject.CompareTag("Zombie2"))
        {
            src.clip = highloop;
            src.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Zombie1") || collision.gameObject.CompareTag("Zombie2"))
        { 
            src.clip = midloop;
            src.Play();
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
