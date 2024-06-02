using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rbody;
    private Vector2 movement;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameStateManager.Instance.isGameOver) return;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (GameStateManager.Instance.isGameOver) return;

        rbody.MovePosition(rbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
