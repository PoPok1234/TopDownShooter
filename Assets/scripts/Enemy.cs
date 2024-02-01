using UnityEngine;
public class Enemy : Entity
{
    float attackRadius = 5;
    private Weapon weapon;

    private GameObject player;
    private void Awake()
    {
        // здесь может происходить общение с другими системами,
        // и установка id для начального оружия.
        speed = 5;
        health = 100;
        weapon = transform.Find("enemyGun").GetComponent<Weapon>();
        player = FindObjectOfType<Player>().gameObject;
    }
    private void FixedUpdate()
    {
        // тут рассчитываете направление и радиус, а после вызыв
        // если расстояние до игрока больше радиуса.
        if (Vector2.Distance(transform.position, player.transform.position) > attackRadius)
        {
            speed = 5;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            weapon.mayShot = false;
        }
        else
        {
            speed = 0;
            weapon.mayShot = true;
        }
    }
    public override void Death()
    {
        Destroy(gameObject);
    }
}

