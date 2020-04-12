using UnityEngine;

public class DialogSwitch : MonoBehaviour
{
    public GameObject objectState1;
    public GameObject objectState2;

    private void Awake()
    {
        objectState1.SetActive(true);
        objectState2.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (CoinManager.coinCount == 6)
        {
            Destroy(objectState1);
            objectState2.SetActive(true);
        }
        
    }


}
