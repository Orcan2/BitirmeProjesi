using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayHomeButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void QuitHomeButton()
    {
        Application.Quit();
    }
}
