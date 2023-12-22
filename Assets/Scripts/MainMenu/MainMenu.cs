using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public DataPersistenceManager manager;
    public void PlayGame() 
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(1);
    }
    public void ContinueGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void BackToMenu() 
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync(0);  
    }
    public void Exit() 
    {
        DataPersistenceManager.instance.SaveGame();
        Application.Quit();  
    }   
}
