using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToDeathScreen : MonoBehaviour
{
    public void SendPlayerToDeathScreen(){
        SceneManager.LoadScene("DeathScreen");
    }
}
