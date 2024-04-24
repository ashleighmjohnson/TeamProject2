using UnityEngine;

public class KeyDoorTrigger : MonoBehaviour
{
    public GameObject doorToDestroy;
    public GameObject Chair;
    public GameObject player;
    public GameObject key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Destroy the door
            if (doorToDestroy != null)
            {
                Destroy(doorToDestroy);
            }
            if (Chair != null)
            {
                Destroy(Chair);
            }

            // Destroy the key
            if (key != null)
            {
                Destroy(key);
            }
        }
    }
}
