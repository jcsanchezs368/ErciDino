using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    UIManager uiManager;
    public string siguienteNivel;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiManager = FindAnyObjectByType<UIManager>();
            {
                if (uiManager.collectedCoins >= 5)
                {
                    if (siguienteNivel.Equals("4"))
                    {
                        JugarNivel("PanelFin");
                    }
                    else
                    {
                        JugarNivel(siguienteNivel);
                    }
                    
                }
            
            }
        }

    }
    
    public void JugarNivel(string nivel)
    {
        SceneManager.LoadScene("Level" + nivel);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
