using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody2D rb2D;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.RecibirGolpe();
            Destroy(gameObject);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lanzar(float direccion)
    {
        rb2D.linearVelocity = new Vector2(direccion*speed, 1);
    }
}
