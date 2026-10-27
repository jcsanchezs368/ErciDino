using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource music;
    public GameObject panelReiniciar;
    public GameObject botonReiniciar;
    public TMP_Text proyectileText;
    public TMP_Text coinText;
    public TMP_Text vidasText;
    public TMP_Text corazonesText;
    public int numCorazones = 3;
    public int numVidas = 3;
    public int numProyectiles = 10;
    public int totalCoins = 0;
    public int collectedCoins = 0; 
    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
        botonReiniciar = GameObject.FindGameObjectWithTag("BotonReiniciar");
        botonReiniciar.SetActive(true);
        panelReiniciar = GameObject.FindGameObjectWithTag("PanelReiniciar");
        panelReiniciar.SetActive(false);
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        totalCoins = coins.Length;
        UpdateCoinText();
        UpdateCorazonesText();
        UpdateVidasText();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    public void MostrarMenu()
    {
        
    }
    public void CoinCollected()
    {
        collectedCoins++;
        UpdateCoinText();
    }


    public void dispararProyectil()
    {
        if (numProyectiles > 0)
        {
            numProyectiles--;
            UpdateNumProyectiles();
        }

    }
    public void recargarProyectiles()
    {
        numProyectiles = 10;
        UpdateNumProyectiles();
    }
    public void UpdateNumProyectiles()
    {
        proyectileText.text = $"x{numProyectiles}";
    }

    public void mostrarPanelReiniciar()
    {
        panelReiniciar.SetActive(true);
    }
    private void UpdateCoinText()
    {
        coinText.text = $"Monedas: {collectedCoins} / {totalCoins}";     
    }

    public void perderCorazon()
    {
        if (numCorazones > 0)
        {
            numCorazones--;
            UpdateCorazonesText();    
        }
    }

    public void conseguirCorazon()
    {
        if (numCorazones < 3)
        {
            numCorazones++;
            UpdateCorazonesText();
        }
        
    }

    public void perderVida()
    {
        if (numVidas > 0)
        {
            numVidas--;
            UpdateVidasText();
            mostrarPanelReiniciar();
        }
        else
        {
            mostrarPanelReiniciar();
            botonReiniciar.SetActive(false);
        }
    }

    public void UpdateCorazonesText()
    {
        corazonesText.text = $"Corazones: {numCorazones} / 3";
    }
    
    private void UpdateVidasText()
    {
        vidasText.text = $"Vidas: {numVidas} / 3";
    }
    
    public void ReiniciarNivel()
    {
        panelReiniciar.SetActive(false);
        player.Reaparecer();
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
