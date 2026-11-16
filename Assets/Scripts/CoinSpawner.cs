using UnityEngine;
using UnityEngine.InputSystem;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject coinPrefab;

    [SerializeField]
    GameObject spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCoin()
    {
        Instantiate(coinPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
