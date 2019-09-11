using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Player : MonoBehaviour
{
    public float movementSpeed;
    public int HP;
    public SCR_Bullet bullet;
    public int currentHp{get; set;}

    void Start()
    {
        currentHp = HP;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    
    public void Shoot(Vector2 direction, string name)
    {
        var b = Instantiate(bullet);
        b.transform.position = transform.position;
        b.Spawn(direction, name);
    }

    public virtual void OnHit()
    {   
    }
}
