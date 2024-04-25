using UnityEngine;
using UnityEngine.SceneManagement;

public class UpFloorController : MonoBehaviour
{
    // The name of the scene you want to load
    public string sceneToLoad;

    // Function to handle collision with player
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
