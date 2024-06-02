using UnityEngine;

public class PlayerMining : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
