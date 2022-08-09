using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI currentCoinText;
    [SerializeField] private TextMeshProUGUI allCoinsText;

    [Header("GameOverMenu")]
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winMenu;

    [HideInInspector] public int currentCoins = 0;

    private int allCoins;

    private void Awake()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.HasKey("counterCoin"))
        {
            allCoins = PlayerPrefs.GetInt("counterCoin");
        }
    }
    private void Update()
    {
        currentCoinText.text = "Coins:" + currentCoins.ToString();
        allCoinsText.text = "AllCoins: " + allCoins.ToString();
        if (currentCoins == SpawnerObjects.counterCoins)
        {
            Win();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("counterCoin", allCoins + currentCoins);
    }
    public void Lose()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    void Win()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

}
