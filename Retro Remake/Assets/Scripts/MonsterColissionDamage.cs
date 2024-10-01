using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterColissionDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    public Movement Movement;
    public Health Health;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Movement.knockCounter = Movement.knockTotalTime;
            if (collider.transform.position.x <= transform.position.x)
            {
                Movement.knockFromRight = true;
            }
            if (collider.transform.position.x > transform.position.x)
            {
                Movement.knockFromRight = false;
            }
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}