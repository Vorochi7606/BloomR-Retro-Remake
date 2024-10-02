using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private int damage = 1;
    public Movement Movement;
    public Health Health;

    void Start()
    {
        Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

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

    public void Setup(Vector2 direction)
    {
        this.direction = direction;
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
