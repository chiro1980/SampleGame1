using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool lightOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightOff()
    {
        lightOn = false;
    }
}
