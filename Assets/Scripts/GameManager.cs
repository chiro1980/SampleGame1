using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    CoinSpawner coinSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        coinSpawner = FindAnyObjectByType<CoinSpawner>();
        Time.timeScale = 10.0f;
        yield return StartCoroutine(SpawnCoinCoroutine(200));
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnCoin(1);
        }
    }

    void SpawnCoin(int count)
    {
        StartCoroutine(SpawnCoinCoroutine(count));
    }

    IEnumerator SpawnCoinCoroutine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            coinSpawner.SpawnCoin();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
