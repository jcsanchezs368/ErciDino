using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource music;
    public GameObject botonComenzar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
        botonComenzar = GameObject.FindGameObjectWithTag("BotonComenzar");
    }

    public void Comenzar()
    {
       SceneManager.LoadScene("Level1"); 
    }
    
    public void Salir()
    {
        Application.Quit();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
