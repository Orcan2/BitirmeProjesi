using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject menuPanel;
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
}
