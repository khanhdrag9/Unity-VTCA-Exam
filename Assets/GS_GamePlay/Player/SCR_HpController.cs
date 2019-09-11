using UnityEngine;
public class SCR_HpController : MonoBehaviour
{
    public SCR_Player player;
    public void Damage(int damage)
    {
        player.currentHp -= damage;
        if(player.currentHp <= 0)
        {
            player.Die();
        }
    }
}