using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{

    public Transform ParticleSpawn1;
    public GameObject Particle1;
    public GameObject SwordCollision;
    public GameObject SpecialAttack;

    public AudioSource Decapitation;
    public AudioClip attack_clip1;
    


    private ParticleSystem specialParticles;
    private AudioSource playerAudio;

    // Start is called before the first frame update
   void Start()
    {
        specialParticles = Particle1.GetComponent<ParticleSystem>();
        playerAudio = GetComponent<AudioSource>();
    }
    /*

   // Update is called once per frame
   void Update()
   {

   }*/

    public void InstantiateParticle()
    {
        specialParticles.Play();

    }

    public void BasicZombieKillOn()
    {
        SwordCollision.SetActive(true);
    }
    public void BasicZombieKillOff()
    {
        SwordCollision.SetActive(false);
    }


    public void SpecialZombieKillOn()
    {
        SpecialAttack.SetActive(true);
        playerAudio.clip = attack_clip1;
        playerAudio.Play();
    }
    public void SpecialZombieKillOff()
    {
        SpecialAttack.SetActive(false);
    }

    public void PlayDecapitationSound()
    {
        Decapitation.Play();
        playerAudio.clip = attack_clip1;
        playerAudio.Play();
    }

}
