using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject menuPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    public Button startButton;

    void Start()
    {
        // Başlangıç panelini aktif hale getir
        startPanel.SetActive(true);

        // Oyuna başla butonuna tıklama olayını dinle
        startButton.onClick.AddListener(StartGame);
    }

    // Oyuna başlama fonksiyonu
    public void StartGame()
    {
        // Oyuna başlama işlemleri burada gerçekleştirilecek
        Debug.Log("Oyun Başlatıldı!");

        // Başlangıç panelini kapat
        startPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void PauseButton()
    {
       Time.timeScale = 0.0f;
        menuPanel.SetActive(false);
        PausePanel.SetActive(true);
        


    }
    public void PlayButton()
    {
        Time.timeScale = 1.0f;
        menuPanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void RePlayButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

   
    public void HomeButton()
    {
        
        SceneManager.LoadScene(0);
    }
    public void GameOverButton()
    {
        Time.timeScale = 0.0f;
        menuPanel.SetActive(false);
        GameOverPanel.SetActive(true);

    }
    public void PlayerDie()
    {
        menuPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
}
