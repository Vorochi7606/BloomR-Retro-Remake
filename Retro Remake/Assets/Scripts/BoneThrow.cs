using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BoneThrow : MonoBehaviour
{
    public Animator anim;

    [SerializeField] private GameObject bonePrefab;

    [SerializeField] private Transform arm;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            Throw();
        }
    }

    public void Throw()
    {
        anim.SetTrigger("isAttacking");

        GameObject go = Instantiate(bonePrefab, arm.position, Quaternion.identity);

        Vector3 direction = new Vector3(transform.localScale.x, 0);

        go.GetComponent<Projectile>().Setup(direction);
    }
}
