using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject theEnemy;
    public Transform player;
    public float xPos;
    public float zPos;
    public float yPos = 10f;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    public void EnemyDeath()
    {
        // Lower enemy count
        enemyCount -= 1;
    }

    IEnumerator EnemyDrop()
    {
        // Keep looping
        while(true)
        {
            // While less than 10 enemies
            while (enemyCount < 10)
            {
                yield return new WaitForSeconds(0.5f);
                // Get random x and z positions close to player
                xPos = player.position.x + Random.Range(-40, 40);
                zPos = player.position.z + Random.Range(-40, 40);
                // Create new enemy at those positions
                Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                // Increase enemy count
                enemyCount += 1;
                Debug.Log("SPAWNED ENEMY");
                Debug.Log("ENEMY COUNT: " + enemyCount);
            }
            // Wait 8 seconds before checking
            yield return new WaitForSeconds(8);
        }

    }
}
