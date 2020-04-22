using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    public static int coinCount;
    public static int gemCount;
    public static int keyCount;
    public static int miscCount;
    public Text coinText;
    public Text keyText;
    public Text gemText;
    public Text miscText;

    
    private void Awake()
    {
        coinCount = 0;
        gemCount = 0;
        keyCount = 0;
        miscCount = 0;

    }
    private void Update()
    {
        coinText.text = "Coins: " + coinCount;
        gemText.text = "Gem: " + gemCount;
        keyText.text = "Key: " + keyCount;
        miscText.text = "Stuff: " + miscCount;
        Debug.Log("gems: " + gemCount);
        Debug.Log("keys: " + keyCount);
    }

}
