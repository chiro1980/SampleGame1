using System;
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

    SwitchController switchController;
    
    [SerializeField]
    GameObject switchPrefab;

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

    void OnApplicationQuit()
    {
        Time.timeScale = 1.0f;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        coinCount = 100;
        coinSpawner = FindAnyObjectByType<CoinSpawner>();
        Time.timeScale = 10.0f;
        yield return StartCoroutine(SpawnCoinCoroutine(140));
        Time.timeScale = 1.0f;

        SetNewSwitch();
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



    /// <summary>
    /// コインを置く（ユーザー操作用）
    /// </summary>
    /// <param name="index">置く位置</param>
    /// <param name="count">置く枚数</param>
    /// <returns></returns>
    void SpawnCoin(int index, int count)
    {
        StartCoroutine(SpawnCoinCoroutine(index, count));
    }


    /// <summary>
    /// コインを置く（初期配置、払い出し、ジャックポッド用）
    /// </summary>
    /// <param name="count">置く枚数</param>
    /// <returns></returns>
    public void SpawnCoin(int count)
    {
        StartCoroutine(SpawnCoinCoroutine(count));
    }

    IEnumerator SpawnCoinCoroutine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            coinSpawner.SpawnCoinInit();
            //if (coinCount > 0) coinCount--; // 初期配置や払い出しはカウントしない
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

    public void SetNewSwitch()
    {
        StartCoroutine(SetNewSwitchCoroutine());
    }

    IEnumerator SetNewSwitchCoroutine()
    {
        if (switchController != null)
        {
            Destroy(switchController.gameObject);
            switchController = null;
            yield return new WaitForSeconds(1.0f);
        }

        Vector3 pos = new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), -0.094f, -0.394f);
        var switchObj = Instantiate(switchPrefab, pos, Quaternion.identity);
        switchController = switchObj.GetComponent<SwitchController>();
    }

}
