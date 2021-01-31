using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject spawnPartical;
    [SerializeField] private GameObject [] enemies ;

    [SerializeField] private float TimeBtwSpawn;
    [SerializeField] private float xMax, xMin, yMax, yMin;


    private float timer;


    private void Update()
    {
        if(timer<=0)
        {
            SpawnEnemy();
            timer = TimeBtwSpawn;
        }
        else
            timer-=Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        int rand = Random.Range(0,enemies.Length);

        Instantiate(enemies[rand],RandomPosition(),Quaternion.identity);
    }
    private Vector2 RandomPosition()
    {
        var randomX = Random.Range(xMin, xMax);
        var randomY = Random.Range(yMin, yMax);
        return new Vector2(randomX, randomY);
    }
    
}
