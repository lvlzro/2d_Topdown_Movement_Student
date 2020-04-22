using UnityEngine;

public class Coin : MonoBehaviour
{
    float speed = 4f;
    public GameObject player;

    private void Awake()
    {

    }
    void Update()
    {
        gameObject.transform.Rotate(0, 90 * Time.deltaTime * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
            Debug.Log("picked up");
            itemManager.coinCount += 1;
            Destroy(gameObject);

    }
}
