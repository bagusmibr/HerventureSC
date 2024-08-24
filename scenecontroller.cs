using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scenecontroller : MonoBehaviour
{
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Main()
    {
        SceneManager.LoadScene(1);
    }

    public void Tentang()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Success");
    }

    public void open_scene(string scene_name){
        Application.LoadLevel(scene_name);
     }
}
