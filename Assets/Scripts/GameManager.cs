using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    CoinSpawner coinSpawner;

    public int coinCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        coinCount = 300;
        coinSpawner = FindAnyObjectByType<CoinSpawner>();
        Time.timeScale = 10.0f;
        yield return StartCoroutine(SpawnCoinCoroutine(150));
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    SpawnCoin(1);
        //}

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SpawnCoin(0, 1);
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            SpawnCoin(1, 1);
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SpawnCoin(2, 1);
        }
    }



    void SpawnCoin(int index, int count)
    {
        StartCoroutine(SpawnCoinCoroutine(index, count));
    }



    IEnumerator SpawnCoinCoroutine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            coinSpawner.SpawnCoinInit();
            if (coinCount > 0) coinCount--;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator SpawnCoinCoroutine(int index, int count)
    {
        for (int i = 0; i < count; i++)
        {
            coinSpawner.SpawnCoin(index);
            if (coinCount > 0) coinCount--;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
