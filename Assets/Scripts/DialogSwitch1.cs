using UnityEngine;

public class DialogSwitch1 : MonoBehaviour
{
    public GameObject objectState1;
    public GameObject objectState2;
 

    private void Awake()
    {
        objectState1.SetActive(true);
        objectState2.SetActive(false);
    }

    private void Update()
    {
        if (itemManager.gemCount == 1)
        {
            Destroy(objectState1);
            objectState2.SetActive(true);
        }
        
    } 
        
}
