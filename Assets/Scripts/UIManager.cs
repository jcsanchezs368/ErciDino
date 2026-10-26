using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource music;
    public GameObject panelReiniciar;
    public TMP_Text coinText;
    public int totalCoins = 0;
    public int collectedCoins = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
        panelReiniciar = GameObject.FindGameObjectWithTag("PanelReiniciar");
        panelReiniciar.SetActive(false);
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        totalCoins = coins.Length;
        UpdateCoinText();
    }

    public void MostrarMenu()
    {
        
    }
    public void CoinCollected()
    {
        collectedCoins++;
        UpdateCoinText();
    }

    public void mostrarPanelReiniciar()
    {
        panelReiniciar.SetActive(true);
    }
    private void UpdateCoinText()
    {
        coinText.text = $"Monedas: {collectedCoins} / {totalCoins}";     
    }
    
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
