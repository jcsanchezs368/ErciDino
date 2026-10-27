using UnityEngine;

public class HeartTrap : MonoBehaviour
{
    Animator animator;
    public AudioClip attackSound;
    private UIManager uIManager;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            uIManager = FindAnyObjectByType<UIManager>();
            uIManager.recargarProyectiles();
            animator.SetTrigger("Attack");
            AudioSource.PlayClipAtPoint(attackSound, transform.position);
            Player player = collision.GetComponent<Player>();
            player.recibirGolpe();
        }
    }
}
