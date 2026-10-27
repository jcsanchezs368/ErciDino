using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelControles;
    public AudioSource music;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
        panelControles.SetActive(false);
    }

    public void Comenzar()
    {
       SceneManager.LoadScene("Level1"); 
    }
    
    public void Salir()
    {
        Application.Quit();
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MostrarPanelControles()
    {
        panelControles.SetActive(true);
    }

    public void OcultarPanelControles()
    {
        panelControles.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
