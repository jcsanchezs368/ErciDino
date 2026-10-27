using System.Threading;
using UnityEngine;

public class EnemyMushroom : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        vida = 6;
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
    
    public void RecibirGolpe()
    {
        vida--;
        if(vida <= 0)
        {
            Morir();
        }
    }

    public void Morir(){
        
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - 0.7f,
            transform.position.z
        );
        GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("Death");
        isDead = true;
        
    }
}
