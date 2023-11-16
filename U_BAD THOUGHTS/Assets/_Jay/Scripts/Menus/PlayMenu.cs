using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    private int gameScene = 1;
    private Animator anim;

    [SerializeField] private GameObject launchScreen;
    [SerializeField] private GameObject optionsMenu;
    
    [SerializeField] private Button[] buttons;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] audio;
    private bool canPlayAudio;

    private void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        canPlayAudio = true;
    }

    public void BeginLaunchSequence(){
        launchScreen.SetActive(true);
    }

    public void PlayGame(){
        SceneManager.LoadScene(gameScene);
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene("1-MainMenu");
    }

    public void ExitGame(){
        Application.Quit();
    }

#region Options

    public void OpenOptions(){
        optionsMenu.SetActive(true);
    }
    
    public void CloseOptions(){
        FadeButtons();
        StartCoroutine(Close());
    }

    public void FadeButtons(){
        anim.SetTrigger("Fade");
    }

    public void EnableButtons(){
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = true;
        }
    }

    public void DisableButtons(){
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
    }

    private IEnumerator Close(){
        yield return new WaitForSeconds(1.5f);
        optionsMenu.SetActive(false);
    }
    #endregion


#region Audio
    public void PlayClick(int id){
        if(canPlayAudio){
            canPlayAudio = false;
            aSource.PlayOneShot(audio[id], 1.25f);
            StartCoroutine(AudioTimer());
        }
    }

    private IEnumerator AudioTimer(){
        yield return new WaitForSeconds(0.05f);
        canPlayAudio = true;
    }
#endregion
}