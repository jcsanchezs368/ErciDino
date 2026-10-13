using System;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private int numVidas;
    private int golpesRestantes;
    private bool isCrouching;
    private UIManager uiManager;
    // Velocidad del jugador
    public float speed = 6f;
    // Fuerza de salto del jugador.
    public float jumpForce = 4f;
    // Indicar si el jugador está tocando el suelo
    private bool isGrounded;
    // Punto situado debajo del jugador para comprobar
    // si hay suelo
    public Transform groundCheck;
    // Tamaño del circulo que comprueba si hay suelo
    public float groundRadius = 0.1f;
    // Capa que representa el suelo
    public LayerMask groundLayer;
    // Indica la dirección del movimiento
    private float move;
    // Componente del jugador (Player)
    private Rigidbody2D rb2D;

    public Animator anim;

    // PROYECTIL
    public GameObject projectilePrefab;
    public Transform throwPoint;

    // Almacenar direccion de movimiento
    private float direccionMirada = 1f;

    // ATAQUE
    public Transform attackPoint;
    public float attackRadius = 0.75f;
    public LayerMask enemyLayer;

    private bool muerto;

    // Sonido proyectil
    public AudioClip shootProjectile;

    // Sonido salto
    public AudioClip jumpSound;

    // Sonido muerte
    public AudioClip deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
        // Guardar en la variable rb2D el componente Rigidbody del jugador
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isCrouching = false;
        numVidas = 3;
        golpesRestantes = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto)
        {
            return; 
        }

        // Lanzar el proyectil
        if (Input.GetKeyDown(KeyCode.C))
        {
            LanzarObjeto();
        }

        // Leer teclas A, D o flecha izquierda/derecha
        move = Input.GetAxisRaw("Horizontal");

        // Cambiar velocidad horizontal del jugador
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);
    
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Z)) && isGrounded) {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }

        // Orientación
        if (move != 0) {
            // Cambia la escala en el valor x
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
            direccionMirada = move;
        }

	    anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);
        anim.SetBool("isGrounded", isGrounded);

        // Golpear
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Kick");

            Collider2D collider = Physics2D.OverlapCircle(
                attackPoint.position,
                attackRadius,
                enemyLayer
            );

            if (collider != null)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                
                if (enemy != null)
                {
                    enemy.RecibirGolpe();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isCrouching)
            {
                speed /= 2;
                anim.SetBool("isCrouching", false);
                isCrouching = false;
            }
            else
            {
                anim.SetBool("isCrouching", true);
                isCrouching = true;
                speed *= 2;
            }
            
        }
        
    }

    private void LanzarObjeto()
    {
        AudioSource.PlayClipAtPoint(shootProjectile, transform.position);
        GameObject projectile = 
        Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);

        projectile.GetComponent<Projectile>().Lanzar(Mathf.Sign(direccionMirada));
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

    }

    // MATAR AL JUGADOR
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            recibirGolpe();
        }
    }

    public void recibirGolpe()
    {
        if (muerto)
        {
            return;
        }
        
        if (golpesRestantes > 0)
        {
            anim.SetTrigger("Hurt");
            golpesRestantes--;
        }
        else
        {
            if (numVidas > 0)
            {
                numVidas--;
                golpesRestantes = 3;
            }
            else
            {
                Morir();
            }
        }
    }
    
    public void Morir()
    {
        if (muerto)
        {
            return;
        }

        AudioSource.PlayClipAtPoint(deathSound, transform.position);

        muerto = true;

        rb2D.linearVelocity = Vector2.zero;

        anim.SetTrigger("Death");
        
        uiManager.mostrarBotonReiniciar();
    }
    
    public void Destruir()
    {
        Destroy(gameObject);
    }
}
