using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject crackedBlock;
    public Game gameScript; //reference to game script
    public GameObject targetPlate;   // Assign Pressure Plate B in Inspector

    public TextMeshProUGUI sillyPlayer;

    public Material highlightedMaterial; // Assign highlighted material in Inspector
    private Material originalMaterial;   // Store the original material
    private bool isActivated = false;  // Prevent multiple activations

    public GameObject deathCamera; // Assign an alternative camera in the Inspector
    public GameObject playerModel; // The visual part of the player
    public float respawnDelay = 2f; // Time before restarting

    private bool isDead = false;
    bool powerUpSpawned = false; //Power up Flag
    bool playerSoftLocked = false;//Softlock Flag

    

    //====Functions====//
    void Start()
    {
        sillyPlayer.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision thingIHit)
    {
        //If Player hits object tagged hazard the model will be destroyed.
        if (thingIHit.gameObject.tag == "Hazard")
        {
            Debug.Log("I Died...");
            Die();
            gameScript.PlayerDied();
            
        }
        //If player collides with object tagged with End finish end the game
        if (thingIHit.gameObject.tag == "End")
        {
            Debug.Log("I won!");
            gameScript.GameEnded();
        }


        //If player collides with object tagged with Plate spawn power up
        if (thingIHit.gameObject.tag == "Plate" && !powerUpSpawned)
        {
            Debug.Log("I Spawned the power up.");
            gameScript.PowerUpSpawn(); //using function from game script to make life easier 
            powerUpSpawned = true;
        }


        if (thingIHit.gameObject.tag == "Silly" && !playerSoftLocked && !powerUpSpawned)
        {

            Debug.Log("You silly man... You've missed the powerup to beat the level. Time to jump off into the lava!!!");
            ShowMessage("You silly man... you've failed to spawn the power up...");

            playerSoftLocked = true;
            gameScript.MissedPowerUp();
        }


        if (thingIHit.gameObject.tag == "Pow")
        {
            Debug.Log("I picked up the power up.");
            gameScript.PowerUpPickedUp();
        }


        if (thingIHit.gameObject.tag == "BrokenBlock")
        {
            Debug.Log("I Broke the Block.");
            Destroy(thingIHit.gameObject, .7f);
            gameScript.BrokenBlockTouched();
        }

        //ACTIVATES THE PRESSURE PLATE
        if (thingIHit.gameObject.tag == "PlateActivate")
        {
            Debug.Log("I touced the plate activator");

            //Changing the Tag of the Pressure plate to make it work when stepped on
            targetPlate.tag = "Plate";

            // Changing the material to highlighted material
            targetPlate.GetComponent<MeshRenderer>().material = highlightedMaterial;
            Debug.Log("Pressure Plate now activated!");
            

            isActivated = true;
            gameScript.PlateActive();
        }

       if (thingIHit.gameObject.tag == "DeadPlate")
       {
            gameScript.DeadPlateTouched();

       }



        if (thingIHit.gameObject.CompareTag("End")) // Check if player hits "End"
        {
            Debug.Log("Player reached the end! Loading Scene 2...");
            SceneManager.LoadScene(1); // Load level 2
        }


        if (thingIHit.gameObject.CompareTag("You Win")) // Check if player hits "End"
        {
            Debug.Log("Player has finished the game!");
            SceneManager.LoadScene(2); // Load level 3
        }
    }
    void Die()
    {
        isDead = true;

        // Activate the death camera if assigned
        if (deathCamera != null)
        {
            deathCamera.SetActive(true);
        }
      
        if (playerModel != null)
        {
            playerModel.SetActive(false);
        }

        // Disable player movement
        GetComponent<Movement>().enabled = false;

        // Restart the scene after a delay
        Invoke("RestartScene", respawnDelay);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current scene
    }
    public void ShowMessage(string message, float duration = 2f)
    {
        sillyPlayer.text = message; //Setting the message
        sillyPlayer.gameObject.SetActive(true); //Showing the Text
        Invoke("HideMessage", 2f); //Hiding it after 2 seconds
        //note: invoke is calling the hidemessage function, after waiting 2 seconds
    }
    public void HideMessage()
    {
        sillyPlayer.gameObject.SetActive(false);  // Hide the text
    }
}
   
  

