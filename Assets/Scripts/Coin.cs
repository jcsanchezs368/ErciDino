using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;

    private UIManager uIManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            uIManager = FindAnyObjectByType<UIManager>();
            uIManager.CoinCollected();

            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
        }
    }

}