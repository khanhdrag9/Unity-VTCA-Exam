using System;
using UnityEngine;

public class SCR_PlayerController : SCR_Player
{
    public float delayShoot = 0.25f;

    float cooldown = 0;
    public void Update()
    {
        UpdateMovement();
        UpdateAction();
    }

    private void UpdateAction()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(cooldown <= 0)
            {
                cooldown = delayShoot;
                Shoot(Vector2.up, "FromPlayer");
            }
        }

        cooldown -= Time.deltaTime;

        //Physics
        // Physics
    }

    void UpdateMovement()
    {
        Vector3 move = Vector2.zero;

        float vertical = Input.GetAxis("Vertical");
        move.y = vertical * movementSpeed * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        move.x = horizontal * movementSpeed * Time.deltaTime;

        move = transform.position + move;
        move.x = Mathf.Clamp(move.x, -SCR_GamePlay.Instance.Width, SCR_GamePlay.Instance.Width);
        move.y = Mathf.Clamp(move.y, -SCR_GamePlay.Instance.Height, SCR_GamePlay.Instance.Height);

        transform.position = move;
    }

    public override void OnHit()
    {
        Debug.Log("Die");
        Die();
        SCR_GamePlay.Instance.Over();
    }

}