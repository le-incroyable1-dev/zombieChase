using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Weapon : MonoBehaviour
{

    public int bullets;
    private ParticleSystem shotps;
    private Player_Controller player_Script;
    private PlayerEvents events_Script;
    private Animator player_anim;

    public GameObject MuzzleParticles;
    public GameObject BulletParticle;
    public GameObject Player;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        bullets = 5;
        shotps = MuzzleParticles.GetComponent<ParticleSystem>();
        player_Script = Player.GetComponent<Player_Controller>();
        events_Script = Player.GetComponent<PlayerEvents>();
        player_anim = Player.GetComponent<Animator>();
    }

    /*// Update is called once per frame, not required right now
    void Update()
    {
        
    }*/

    public void Shoot()
    {
        player_anim.Play("Shoot");
        

        

    }

    public void InitiateShot()
    {
        shotps.Play();
        events_Script.PlayDecapitationSound();
        Instantiate(BulletParticle, bulletSpawn.position, bulletSpawn.rotation);
        bullets = bullets - 1;

        if (bullets <= 0)
        {
            player_Script.GunEmpty();
        }
    }

    
}
