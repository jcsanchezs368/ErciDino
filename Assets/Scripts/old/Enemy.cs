using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;

    // Movimiento del enemigo
    public Transform puntoA;
    public Transform puntoB;
    public float speed = 0.5f;
    public Transform objetivo;

    // Vida del Enemigo
    public int vida = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        objetivo = puntoB;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            objetivo.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, objetivo.position) < 0.1f)
        {
            if(objetivo == puntoA)
            {
                objetivo = puntoB;
            } else
            {
                objetivo = puntoA;
            }
        }
    }

    public void RecibirGolpe()
    {
        vida--;
        if(vida <= 0)
        {
            Morir();
        }
    }

    public void Morir(){

        GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("Death");
        
    }

    public void Destruir(){
        Destroy(gameObject);
    }
}
