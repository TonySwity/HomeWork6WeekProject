using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;
    public List<MonoBehaviour> ComponentsToDisable; 
    
    public void OpenMenuWindow(){
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);

        foreach (var component in ComponentsToDisable)
        {
            component.enabled = false;
        }
        
        Time.timeScale = 0.01f;
    }
    
    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);
        
        foreach (var component in ComponentsToDisable)
        {
            component.enabled = true;
        }
        
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
