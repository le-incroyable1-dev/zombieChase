using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.U2D;


public class GameControl : MonoBehaviour
{

    public int MaxScore;
    private int UIlen;

    //public GameObject StartMenu;
    public GameObject DeathMenu;
    public GameObject PauseMenu;
    public GameObject TheEntireGame;

    public GameObject[] InGameUI;

    public AudioClip pause;
    public AudioClip play;
    public AudioClip quit;

    public Text MaxScoreText;

    private AudioSource game_audio;
    public VideoPlayer loadscreen;

    private bool PlayerDead;


    //Pixel Perfect Cam
    public Camera MainCam;
    private PixelPerfectCamera ppc;
    private float HalfScreenHt;

 
    // Start is called before the first frame update
    void Start()
    {
        //Correcting Pixel Perfect Cam;
        HalfScreenHt = Screen.height / 2;
        ppc = MainCam.GetComponent<PixelPerfectCamera>();
        ppc.refResolutionX = Screen.width;
        ppc.refResolutionY = Screen.height;
        ppc.assetsPPU = (int)(HalfScreenHt / MainCam.orthographicSize);
        
        UIlen = InGameUI.Length;
        Time.timeScale = 1;
        PlayerDead = false;
        PlayerPrefs.SetInt("MaxScore", MaxScore);
        game_audio = GetComponent<AudioSource>();
      
        TheEntireGame.SetActive(false);

        

        //Enable this below when setting up StartMenu

        //MaxCureText.text = "Maximum Cures Collected = " + MaxCures;
    }

   

    // Update is called once per frame - not required here
    void Update()
    {
        

        if(!PlayerDead)
        {
            TheEntireGame.SetActive(true);
        }
        
    }
    

    /*public void Play()
    {
        //PlayerPrefs.SetInt("MaxCures", MaxCures);
        StartCoroutine(OnPlay());
        

    }*/

    public void Replay()
    {
        SceneManager.LoadScene(3);
    }



  

    public void Death()
    {
        for(int i = 0; i < UIlen; i++)
        {
            InGameUI[i].SetActive(false);
        }
        StartCoroutine(Wait(2.0f));
        PlayerDead = true;
        MaxScore = PlayerPrefs.GetInt("MaxScore");
        //Time.timeScale = 0;
        DeathMenu.SetActive(true);
        MaxScoreText.text = "High Score = " + MaxScore;
        MaxScoreText.gameObject.SetActive(true);
       
    }

    public void Pause()
    {
        game_audio.clip = pause;
        game_audio.Play();
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void MainMenu()
    {
        
        game_audio.clip = quit;
        game_audio.Play();
        SceneManager.LoadScene(2);
    }

    public void Resume()
    {
       
        game_audio.clip = play;
        game_audio.Play();
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    /* private IEnumerator OnPlay()
    {
        StartMenu.SetActive(false);
        loadscreen.Play();
        StartMenu.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        loadscreen.Stop();
        
        TheEntireGame.SetActive(true);
       
        yield return null;
    }*/

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        yield return null;
    }
}
