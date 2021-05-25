using UnityEngine;


public class Déplacement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    private Vector3 velocity = Vectore3.zero;
    
     void FixedUpdate()
    {
        float horizontalMovement = Imput.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vectore2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vectore3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
