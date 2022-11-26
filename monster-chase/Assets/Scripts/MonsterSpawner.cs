using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // Waits for random seconds between 1 to 5
            randomIndex = Random.Range(0, monsterReference.Length); // Random indexes between 0 and monsterReference.Length(3) [Enemy1, Enemy2, Ghost]
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]); // Instantiates a random monster at a random index every random amount of seconds lol

            if (randomSide == 0)
            {
                // left side
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10); // Move from left to right
            }
            else
            {
                // right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10); // Move from right to left
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); // Flip monster to left
            }
        } // while loop
    }

} // class
