using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : Entity
{
    Vector2 axis; // здесь будут храниться значения с Input.GetA
    Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 8;
        health = 500;
    }
    private void FixedUpdate()
    {
        axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Movement(axis);
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    public override void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

