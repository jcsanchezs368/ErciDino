using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AudioSource music;
    private GameObject botonReiniciar;
    public TMP_Text coinText;
    public int totalCoins = 0;
    public int collectedCoins = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.Play();
        botonReiniciar = GameObject.FindGameObjectWithTag("Reiniciar");
        botonReiniciar.SetActive(false);
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

    public void mostrarBotonReiniciar()
    {
        botonReiniciar.SetActive(true);
    }
    private void UpdateCoinText()
    {
        coinText.text = $"Monedas: {collectedCoins} / {totalCoins}";     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
