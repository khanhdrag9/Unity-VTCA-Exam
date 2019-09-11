using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Bullet : MonoBehaviour
{
    public float speedMovement;
    public Vector2 direction;
    public void Spawn(Vector2 direction, string name)
    {
        this.direction = direction;
        this.name = name;
    }

    public void Update()
    {
        transform.Translate(direction * speedMovement * Time.deltaTime);

        if(transform.position.y > SCR_GamePlay.Instance.Height)
        {
            Destroy(gameObject);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if(hit.transform && hit.transform.gameObject.tag == "Enemy" && name == "FromPlayer")
        {
            hit.transform.GetComponent<SCR_Player>().OnHit();
        }
        else if(hit.transform && hit.transform.gameObject.tag == "Player" && name == "FromEnemy")
        {
            hit.transform.GetComponent<SCR_Player>().OnHit();
        }
    }
}
