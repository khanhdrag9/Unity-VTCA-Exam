using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy : SCR_Player
{
    public float delayShoot;
    void Start()
    {
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        SCR_GamePlay game = SCR_GamePlay.Instance;
        while(true)
        {
            Shoot(Vector2.down, "FromEnemy");
            yield return new WaitForSeconds(delayShoot);
            if(game.status != GameStatus.PLAY)break;
        }
    }

    void Update()
    {
        if(transform.position.y < -SCR_GamePlay.Instance.Height)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);    
        }
    }

    public override void Die()
    {
        base.Die();
        SCR_GamePlay.Instance.AddScore(1);
    }

    public override void OnHit()
    {
        Die();
    }
}
