using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   //Deni
    //We creating a massive for enemies, powerups and spawn points. We can add differents types of enemies or powerups and we can choice where there going to spawn with help of spawn points
    //Spawnintervals decides how much eneimes going to spawn example every seconds.
    [SerializeField] private SpawnObjects[] _enemies;
    [SerializeField] private SpawnObjects[] _powerups;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnIntervals;

    //This code starts our spawn coroutine for both spawnRoutine and GradualDifficulty
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(GradualDifficulty());
    }
    // With help of this code we create a while loop that going to spawn a enemy with variable spawnintervals. This code will spawn random enemy, random spawn position or spawnpoints a
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnIntervals);
            var enemy = GetRandomEnemy();
            var spawnPosition = GetRandomSpawnPosition();
            var enemyInstance = Instantiate(enemy, spawnPosition, Quaternion.identity);
            Destroy(enemyInstance.gameObject, 10);
        }
    }
    //this method let's us to create a random enemy, if we wish to add different enemy types, we are able to do that here with help of diffrent enemies + it works with powerups as well
    private SpawnObjects GetRandomEnemy()
    {
        var chance = Random.Range(0, 100);
        if (chance > 10)
        {
            int randomIndex = Random.Range(0, _enemies.Length);
            return _enemies[randomIndex];
        }
        else
        {
            int randomIndex = Random.Range(0, _powerups.Length);
            return _powerups[randomIndex];
        }
 
    }
    //It will pick random spawn position that are set up in the unity scene that are empty object.
    private Vector3 GetRandomSpawnPosition()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        return _spawnPoints[randomIndex].position;
    }
    //The speed of spawning will increase every 5 seconds by 0.2 seconds
    private IEnumerator GradualDifficulty()
    {
        while (_spawnIntervals > 0.2f)
        {
            yield return new WaitForSeconds(5);
            _spawnIntervals -= 0.1f;
        }
    }
}
