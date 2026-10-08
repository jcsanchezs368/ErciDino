using System;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //velocidad del jugador
    public float speed = 6f;

    //Fuerza de salto del jugador
    public float jumpForce = 8f;

    //Indicar si el jugador está tocando el suelo
    private bool isGrounded;

   //Tamaño del circulo que comprueba si hay suelo
   public float groundRadius = 0.1f;

   // Capa que representa el suelo
   public LayerMask groundLayer;

    //Punto situado debajo el jugador para comprobar si hay suelo
    public Transform groundCheck;

    //componente rigidbody2D del jugador (Player)
    private Rigidbody2D rb2D;
    //Indica la dirección del movimiento
    private float move;

    public Animator anim;
    void Start(){
        //guardar en la variable rb2D el componente Rigidbody2D del jugador
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    void Update()
    {
        //Leer teclas A,D o flechas izquierda / derecha
        move = Input.GetAxisRaw("Horizontal");

        //Cambiar velocidad horizontal del jugador
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded){
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);

        }

        //Orientación
        if(move != 0){
            //Cambia la orientación del jugador
            transform.localScale = new Vector3(Mathf.Sign(move), 1f, 1f);
        }

        //Cambiamos el valor de la variable Speed dentro del controlador de animaciones
        anim.SetFloat("Speed",Mathf.Abs(move));

        //Cambiamos el valor de la variable VerticalVelocity del controlador de animaciones
        anim.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);

        //Cambiamos el valor de la variable isGrounded
        anim.SetBool("isGrounded", isGrounded);
        
    }

    private void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

}
