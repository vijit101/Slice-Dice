using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargetCor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTargetCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }
}
