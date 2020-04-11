using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static int coinCount;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        coinCount = 0;

    }
    // Update is called once per frame
    void Update()
    {
        text.text = "" + coinCount;
    }
}
