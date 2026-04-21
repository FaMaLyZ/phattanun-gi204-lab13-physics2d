using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    float move;
    public float jumpForce;

    private int jumpCount;

    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2 (move*moveSpeed,rb2d.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && jumpCount <= 0)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            jumpCount++;
            Debug.Log($"Jump! jumpForce = {jumpForce}");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
