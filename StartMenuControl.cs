using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{

    public GameObject InfoScreen;
    public GameObject HowToScreen;
    public AudioClip PlayClip;
    public AudioClip QuitClip;
    private AudioSource game_audio;

    private void Start()
    {
        game_audio = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        game_audio.clip = PlayClip;
        game_audio.Play();
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        game_audio.clip = QuitClip;
        game_audio.Play();
        Application.Quit();
    }

    public void InfoOpen()
    {
        game_audio.clip = PlayClip;
        game_audio.Play();
        InfoScreen.SetActive(true);
    }

    public void InfoClose()
    {
        game_audio.clip = QuitClip;
        game_audio.Play();
        InfoScreen.SetActive(false);
    }

    public void HowToOpen()
    {
        game_audio.clip = PlayClip;
        game_audio.Play();
        HowToScreen.SetActive(true);
    }

    public void HowToClose()
    {
        game_audio.clip = QuitClip;
        game_audio.Play();
        HowToScreen.SetActive(false);
    }



}
