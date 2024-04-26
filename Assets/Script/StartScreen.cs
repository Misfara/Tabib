using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Option;

        //START MENU//
    public void StartGame(){
        SceneManager.LoadScene("InGame");
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlaySFX("Button");
    }

    public void LoadGame(){
        SceneManager.LoadScene("LoadGame");
        AudioManager.Instance.PlaySFX("Button");
    }

    public void OptionClicked()
    {
        if (Option.activeInHierarchy == false)
        {
            Option.SetActive(true);
            AudioManager.Instance.PlaySFX("Button");
        }
        else
        {
            Option.SetActive(false);
            AudioManager.Instance.PlaySFX("Button");
        }
    }

    public void QuitGame(){
        Application.Quit();
        AudioManager.Instance.PlaySFX("Button");
    }

    
    //LOAD MENU//
    public void StartMenu(){
        SceneManager.LoadScene("StartScreen");
        AudioManager.Instance.PlaySFX("Button");
    }
}
