using UnityEngine;

public class PlayerMining : MonoBehaviour
{
    public ObjectPool objectPool;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            objectPool.ReturnObject(collision.gameObject);
        }
    }
}
