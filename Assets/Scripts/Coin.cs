using UnityEngine;

public class Coin : MonoBehaviour
{
    float speed = 4f;

    void Update()
    {
        gameObject.transform.Rotate(0, 90 * Time.deltaTime * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("picked up");

        CoinManager.coinCount += 1;
        Destroy(gameObject);
    }
}
