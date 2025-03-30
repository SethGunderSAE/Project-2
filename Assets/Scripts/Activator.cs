using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject targetPlate;   // Assign Pressure Plate B in Inspector
    public Material highlightedMaterial; // Assign highlighted material in Inspector
    private Material originalMaterial;   // Store the original material
    private bool isActivated = false;  // Prevent multiple activations

    private void Start()
    {
        if (targetPlate != null)
        {
            // Getting the original material of Pressure Plate 
            originalMaterial = targetPlate.GetComponent<MeshRenderer>().material;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)  // Check if Player steps on it
        {
            Debug.Log("Stepped on Activator");

            if (targetPlate != null)
            {
                //Changing the Tag of the Pressure plate to make it work when stepped on
                targetPlate.tag = "Plate";

                // Changing the material to highlighted material
                targetPlate.GetComponent<MeshRenderer>().material = highlightedMaterial;
                Debug.Log("Pressure Plate now activated!");
            }

            isActivated = true; 
        }
    }

}
