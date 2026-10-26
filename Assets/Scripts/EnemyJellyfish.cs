using System.Threading;
using UnityEngine;

public class EnemyJellyfish : MonoBehaviour
{
    private Animator anim;

    // Movimiento del enemigo
    public Transform puntoA;
    public Transform puntoB;
    public float speed = 0.5f;
    public Transform objetivo;

    // Vida del Enemigo
    public int vida = 5;

    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        objetivo = puntoB;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            
            return;
        }
        transform.position = Vector2.MoveTowards(
            transform.position,
            objetivo.position,
            speed * Time.deltaTime
        );
        
        if (objetivo.position.x != transform.position.x)
        {
            float direccion = Mathf.Sign(objetivo.position.x - transform.position.x);

            transform.localScale = new Vector3(direccion, 1, 1);
        }

        if (Vector2.Distance(transform.position, objetivo.position) < 0.1f)
        {
            anim.SetBool("IsMoving", false);
            if(objetivo == puntoA)
            {
                objetivo = puntoB;
            } else
            {
                objetivo = puntoA;
            }
        }
        else
        {
            anim.SetBool("IsMoving", true);
        }
        
    }

    public void Atacar()
    {
        
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
        isDead = true;
        
    }
}
