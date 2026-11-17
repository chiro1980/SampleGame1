using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coinCountText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = $"Coint: {GameManager.Instance.coinCount}";
    }
}
