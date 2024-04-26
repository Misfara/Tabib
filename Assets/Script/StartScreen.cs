using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("InGame");
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlaySFX("Button");
    }

    public void QuitGame(){
        Application.Quit();
        AudioManager.Instance.PlaySFX("Button");
    }

    
}
