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
            GameManager.Instance.coinCount++;
            Destroy(gameObject);
        }
        else if (other.CompareTag("FailArea"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Switch"))
        {
            bool lightOn = other.GetComponent<SwitchController>().lightOn;
            if (lightOn)
            {
                other.GetComponent<SwitchController>().LightOff();
                GameManager.Instance.SetNewSwitch();
                GameManager.Instance.SpawnCoin(5);
            }
        }
    }
}
