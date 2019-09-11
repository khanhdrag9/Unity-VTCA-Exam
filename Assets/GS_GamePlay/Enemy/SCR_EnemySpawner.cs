using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemySpawner : MonoBehaviour
{
    public float delaySpawn;
    public SCR_Enemy enemy;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        SCR_GamePlay game = SCR_GamePlay.Instance;
        while(true)
        {
            var e = Instantiate(enemy);
            float x = Random.Range(-game.Width + 1, game.Width - 1);
            e.transform.position = new Vector2(x, game.Height + 1);
            yield return new WaitForSeconds(delaySpawn);

            if(game.status != GameStatus.PLAY)break;
        }
    }

}
