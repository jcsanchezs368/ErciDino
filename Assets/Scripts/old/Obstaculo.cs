using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Reiniciar el nivel
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Player player = collision.gameObject.GetComponent<Player>();
            player.Morir();
        }
    }
}
