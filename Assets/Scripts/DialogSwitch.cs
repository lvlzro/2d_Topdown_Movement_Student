using UnityEngine;

public class DialogSwitch : MonoBehaviour
{
    public GameObject objectState1;
    public GameObject objectState2;
    public GameObject objectState3;
    public GameObject objectState4;

    private void Awake()
    {
        objectState1.SetActive(true);
        objectState2.SetActive(false);
        objectState3.SetActive(true);
        objectState4.SetActive(false);
        
    }

    private void Update()
    {
        if (itemManager.coinCount == 6)
        {
            Destroy(objectState1);
            Destroy(objectState3);
            objectState2.SetActive(true);
            objectState4.SetActive(true);
        }
        
    } 
        
}
