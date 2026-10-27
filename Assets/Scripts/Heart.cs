using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioClip healSound;
    private UIManager uIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            uIManager = FindAnyObjectByType<UIManager>();
            if (uIManager.numCorazones < 3)
            {
                uIManager.conseguirCorazon();
                AudioSource.PlayClipAtPoint(healSound, transform.position);
                Destroy(gameObject);
            }

        }
    }
}
