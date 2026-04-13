using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;

    public TextMeshProUGUI hudTimerText;
    public TextMeshProUGUI finalTimerText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI finalCoinsText;
    void Update()
    {
        coinsText.text = "Moedas: " + GameController.CoinsCollected;    
        if (!GameController.GameOver)
        {
            endGamePanel.SetActive(false);
            GameController.TickTimer(Time.deltaTime);
            hudTimerText.text = GameController.Timer.ToString("F2");
            livesText.text = "Vidas: " + GameController.Lives;
            coinsText.text = "Coins: " + GameController.CoinsCollected;
        }
        else
        {
            endGamePanel.SetActive(true);
            livesText.text = "";
            coinsText.text = "";
            hudTimerText.text = "";
            finalCoinsText.text = "Moedas Coletadas: " + GameController.CoinsCollected.ToString();
            finalTimerText.text = "Tempo Final: " + GameController.Timer.ToString("F2");
        }
    }
   
}
