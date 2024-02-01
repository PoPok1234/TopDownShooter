using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    private float speedBullet = 25f;
    private float lifeTime = 2f;
    private bool enemyBullet;

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Enemy>() && !enemyBullet)
            {
                damage = manager.isPistol ? 50 : 25;
                hit.collider.GetComponent<Enemy>().Damage(damage);
                Destroy(gameObject);
            }
            if (hit.collider.GetComponent<Player>() && enemyBullet)
            {
                damage = manager.isEnemyPistol ? 50 : 25;
                hit.collider.GetComponent<Player>().Damage(damage);
                Destroy(gameObject);
            }
        }

        transform.Translate(Vector2.right * speedBullet * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
