using System;
using UnityEngine;

public class Chilito : MonoBehaviour
{
    public AudioClip eatSound;
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
            uIManager.recargarProyectiles();

            AudioSource.PlayClipAtPoint(eatSound, transform.position);
            Destroy(gameObject);
        }
    }
}
