using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public GameObject PowerUp;
    public Movement movementScript;
    public ParticleSystem powerUpParticles;
    public ParticleSystem acidLevel;

            //===Audio===//
    public AudioClip powerUpPickUp;
    public AudioClip powerSpawn;
    public AudioClip deadSound;
    public AudioClip GG;
    public AudioClip Break;
    public AudioClip ActivatePlate;
    public AudioSource sourceToPlayAt;

    bool powTouched;
    bool plateTouched;
    bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        PowerUp.SetActive(false);
        acidLevel.Play();
   
    }


    //========FUNCTIONS=============
    public void PowerUpSpawn()
    {
        PowerUp.SetActive(true);
        powerUpParticles.Play();

        sourceToPlayAt.PlayOneShot(powerSpawn);

    }
    public void MissedPowerUp()
    {
        sourceToPlayAt.PlayOneShot(GG);
    }
    public void PowerUpPickedUp()
    {
        PowerUp.SetActive(false);
        movementScript.jumpHeight = 17f;
        movementScript.gravity = -40f;

        sourceToPlayAt.PlayOneShot(powerUpPickUp);
        
    }
    public void BrokenBlockTouched() 
    {
        sourceToPlayAt.PlayOneShot(Break);
    }
    public void PlateActive()
    {
        sourceToPlayAt.PlayOneShot(ActivatePlate);
    }

    public void GameEnded()
    {

    }
    public void PlayerDied()
    {
        sourceToPlayAt.PlayOneShot(deadSound);

    }
    public void DeadPlateTouched()
    {
        sourceToPlayAt.PlayOneShot(GG);
    }

    //if (plateTouched && !powerUpSpawned && PowerUp != null)
    // {
    //   Instantiate(PowerUp, new Vector3(-37.35f, 21.05f, -46.78f), Quaternion.Euler(0, 0, 0)); //spawning powerup

    // Set the flag to true to indicate that the PowerUp has been spawned
    //  powerUpSpawned = true;

    //}


}

