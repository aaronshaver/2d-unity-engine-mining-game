using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position;
            newPosition.z = transform.position.z; // Keep camera's z position unchanged
            transform.position = newPosition;
        }
    }
}
