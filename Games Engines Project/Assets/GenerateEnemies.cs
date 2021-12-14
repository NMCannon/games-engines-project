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
        enemyCount -= 1;
    }

    IEnumerator EnemyDrop()
    {
        while(true)
        {
            while (enemyCount < 10)
            {
                xPos = player.position.x + Random.Range(20, 60);
                zPos = player.position.z + Random.Range(20, 60);
                Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                enemyCount += 1;
                Debug.Log("SPAWNED ENEMY");
                Debug.Log("ENEMY COUNT: " + enemyCount);
            }

            yield return new WaitForSeconds(5);
        }

    }
}
