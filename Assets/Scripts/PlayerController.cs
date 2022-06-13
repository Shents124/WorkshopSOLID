using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    public bool isDoneAnimation = false;
    
    public void Move(float horizontalInput, float speed)
    {
        rb2D.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb2D.velocity.y);
        Flip(horizontalInput);
    }

    public void StopMovement()
    {
        rb2D.velocity = Vector2.zero;
    }
    
    private void Flip(float horizontalInput)
    {
        var newScale = new Vector3(horizontalInput, 1, 1);
        transform.localScale = newScale;
    }

    private void DoneAnimation() => isDoneAnimation = true;
}
