using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndCheck : MonoBehaviour
{

    public VideoPlayer vid;
    public GameObject cont;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time == 50f)
        {
            //SceneManager.LoadScene(2);
            cont.SetActive(true);
        }
        
    }
}
