using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GetArea"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("FailArea"))
        {
            Destroy(gameObject);
        }
    }
}
