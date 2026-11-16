using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CoinSpawner coinSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinSpawner = FindAnyObjectByType<CoinSpawner>();
        StartCoroutine(InitialSpawnCoin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InitialSpawnCoin()
    {
        for(int i = 0; i < 200; i++)
        {
            coinSpawner.SpawnCoin();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
