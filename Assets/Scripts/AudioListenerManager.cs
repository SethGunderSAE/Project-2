using UnityEngine;

public class AudioListenerManager : MonoBehaviour
{
    void Awake()
    {
        // Find all AudioListeners in the scene
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();

        // If there's more than one, disable all but the first one
        if (listeners.Length > 1)
        {
            for (int i = 1; i < listeners.Length; i++)
            {
                listeners[i].enabled = false; // Disable extra listeners
            }
        }
    }
}
