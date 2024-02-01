using UnityEngine;
public class Entity : MonoBehaviour
{
    public int health { get; set; }
    public float speed { get; set; }

    public Vector2 moveVelocity { get; set; }

    public void Movement(Vector2 inputs)
    {
        moveVelocity = inputs.normalized * speed;
    }
    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }
    public virtual void Death() { } // без реализации.
}
