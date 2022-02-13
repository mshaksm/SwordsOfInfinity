using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //enemy object
    public GameObject monsterEnemy;
    //spawn position x and y
    public int spawnxPosition;
    public int spawnzPosition;
    //monster count 
    public int monsterCount = 1;
    public int increaseCount;


    //GameManger variable
    public GameManager gm;
    

    // Start is called before the first frame update
    void Start()
    {
        //start a couritine and spawn first enemy
        StartCoroutine(SpawnEnemy());
    }
    private void Update()
    {
        //Check if return key is pressed and spawn one enemy
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartNextWave();
        }

    }



    IEnumerator SpawnEnemy()
    {
        //check if monster count is less increase count
        while(monsterCount < increaseCount)
        {
            //spawn enemy random position within x and z
            spawnxPosition = Random.Range(76, 95);
            spawnzPosition = Random.Range(55, 90);
            //create new monster enemy
            Instantiate(monsterEnemy, new Vector3(spawnxPosition, 0, spawnzPosition), Quaternion.identity);
            //wait 1 second before spawning
            yield return new WaitForSeconds(1);
            //monster count increase by 1
            monsterCount += 1;

        }
    }
    private void StartNextWave()
    {
        //increase count increase by 1 and start a couroutine spawn enemy
        increaseCount++;
        StartCoroutine(SpawnEnemy());

    }

}
