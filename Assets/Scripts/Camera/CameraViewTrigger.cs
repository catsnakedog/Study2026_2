using UnityEngine;

public class CameraViewTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RaycastPlayerController>().isFirstPerson = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RaycastPlayerController>().isFirstPerson = false;
        }
    }
}
