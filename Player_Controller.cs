using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

    public GameObject[] SwordElements;
    public GameObject[] GunElements;

    public bool OnTile = false;
    public float JumpForce;
    public int Energy;
    public int Health;
    public int Cure;

    public float Score;
    public int MaxScore;

    public GameObject ParticleFactory;
    public GameObject GameControl;
    public GameObject GunWeapon;

    private DemoMouseController particle_script;
    private GameControl control_script;
    private Gun_Weapon gun_script;

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource player_audio;

    public AudioClip attacked_clip;
    public AudioClip BoostClip;
    public Slider EnergySlider;
    public Slider HealthSlider;
    public Text CureText;
    public Text ScoreText;

    //private bool WantsToJump;
    //private bool WantsToUseSword;

    // Use this for initialization
    void Start () {

        Health = 100;
        Energy = 20;
        Cure = 0;
        Score = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        particle_script = ParticleFactory.GetComponent<DemoMouseController>();
        control_script = GameControl.GetComponent<GameControl>();
        player_audio = GetComponent<AudioSource>();
        StartCoroutine(CureUpdate());
        StartCoroutine(ScoreUpdate());


    }
	
	// Update is called once per frame
	void Update ()
    {
        EnergySlider.value = Energy;
        HealthSlider.value = Health;
        //StartCoroutine(Jumper());
        //StartCoroutine(BasicSwordAttack());
        //StartCoroutine(SpecialSwordAttack());
        anim.SetBool("OnGround", OnTile);
        //StartCoroutine(SwordAttack());
        MaxScore = PlayerPrefs.GetInt("MaxScore");
        if(Health>=0)
        {
            Score = Score + 0.05f;
        }
        
        StartCoroutine(ScoreUpdate());

        if (Score > MaxScore)
        {
            MaxScore = (int)Score;
        }

        
        
        

    }

    private void OnTriggerEnter2D(Collider2D collisionenter)
    {
        if (collisionenter.gameObject.CompareTag("Tile"))
        {
            OnTile = true;
            anim.SetBool("SheJumps", false);

        }
        else if (collisionenter.gameObject.CompareTag("Zombie1"))
        {
            player_audio.clip = attacked_clip;
            player_audio.Play();
            if (collisionenter.gameObject.GetComponent<ZombieBehavior1>())
            {
                if (collisionenter.gameObject.GetComponent<ZombieBehavior1>().Killed)
                {
                    Vector2 spawnPos = new Vector2(collisionenter.transform.position.x, collisionenter.transform.position.y);
                    particle_script.SpawnExplosion(spawnPos);
                    collisionenter.gameObject.GetComponent<Animator>().SetBool("Zombie1_Dead", true);
                    Energy = Energy + 5;
                    Score = Score + 100;
                }
                else
                {
                    collisionenter.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    Health = Health - 5;
                    StartCoroutine(HealthChecker());
                }
            }
            else
            {
                collisionenter.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Health = Health - 5;
                StartCoroutine(HealthChecker());

            }

        }
        else if (collisionenter.gameObject.CompareTag("Zombie2"))
        {
            player_audio.clip = attacked_clip;
            player_audio.Play();
            if (collisionenter.gameObject.GetComponent<ZombieBehaviour2>())
            {
                if (collisionenter.gameObject.GetComponent<ZombieBehaviour2>().Killed)
                {
                    Vector2 spawnPos = new Vector2(collisionenter.transform.position.x, collisionenter.transform.position.y);
                    particle_script.SpawnExplosion(spawnPos);
                    collisionenter.gameObject.GetComponent<Animator>().enabled = false;
                    Energy = Energy + 5;
                    Score = Score + 100;
                }
                else
                {
                    collisionenter.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    Health = Health - 5;
                    StartCoroutine(HealthChecker());
                }
            }
            else
            {
                collisionenter.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Health = Health - 5;
                StartCoroutine(HealthChecker());
            }

        }
        else if (collisionenter.gameObject.CompareTag("Cure"))
        {
            Cure = Cure + 1;
            

            if( Cure >= 5)
            {
                player_audio.clip = BoostClip;
                player_audio.Play();
                Cure = 0;
                Health = 100;
            }

            StartCoroutine(CureUpdate());
            //// //// ////


        }
        else if(collisionenter.gameObject.CompareTag("GunPickup"))
        {
            for(int i = 0; i<SwordElements.Length; i++)
            {
                SwordElements[i].SetActive(false);
            }

            for (int i = 0; i < GunElements.Length; i++)
            {
                GunElements[i].SetActive(true);
            }

            gun_script = GunWeapon.GetComponent<Gun_Weapon>();
            gun_script.bullets = 5;
        }
      
    }

    private void OnTriggerExit2D(Collider2D collisionexit)
    {
        if (collisionexit.gameObject.CompareTag("Tile"))
        {
            OnTile = false;
        }
    }

   
    public void Jump()
    {
        if (OnTile)
        {
            Vector2 force = new Vector2(0, JumpForce);
            anim.SetBool("SheJumps", true);
            rb.AddForce(force);
        }
            
    }

    public void PlayerShoots()
    {
        if(GunWeapon)
        {
            gun_script.Shoot();
        }
    }

    public void InitiateShotFunction()
    {
        if (GunWeapon)
        {
            gun_script.InitiateShot();
        }
    }
    
    public void Dead()
    {
        anim.Play("PlayerDead");
       
        if(Score > PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", (int)Score);
        }

        control_script.Death();
    }

    public void GunEmpty()
    {
        for (int i = 0; i < SwordElements.Length; i++)
        {
            SwordElements[i].SetActive(true);
        }

        for (int i = 0; i < GunElements.Length; i++)
        {
            GunElements[i].SetActive(false);
        }
    }

    public void SpecialSwordAttack()
    {
        if (Energy >= 100)
        {
            anim.Play("SpecialAttack1");
            Energy = Energy - 100;
        }
    }

    private IEnumerator HealthChecker()
    {
        if (Health <= 0)
        {
            Dead();
        }
        yield return null;
    }

    private IEnumerator CureUpdate()
    {
        CureText.text = "Cures = " + Cure;
        yield return null;
    }

    private IEnumerator ScoreUpdate()
    {
        ScoreText.text = "" + (int)Score;
        yield return null;
    }



    public void BasicSwordAttack()
    {
        anim.Play("BasicSwordAttack");


    }

    /*private IEnumerator SpecialSwordAttack()
    {
        //Vector2 force = new Vector2(0, JumpForce);
        if (Input.GetKeyDown(KeyCode.X) && OnTile)
        {
            //rb.AddForce(force);
            if(Energy >= 100)
            {
                anim.Play("SpecialAttack1");
                Energy = Energy - 100;
            }
           
            
            //WantsToJump = true;
            //WantsToUseSword = false;
            //StartCoroutine(JumpAnimTrigger());

        }
        yield return null;
    }*/
    

}
