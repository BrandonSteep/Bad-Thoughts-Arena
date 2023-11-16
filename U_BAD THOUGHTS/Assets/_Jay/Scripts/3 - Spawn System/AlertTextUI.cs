using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlertTextUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowAlertText(){
        canvas.alpha = 1f;
        StartCoroutine(ClearText());
    }

    private IEnumerator ClearText(){
        yield return new WaitForSeconds(2.5f);
        
        float elapsedTime = 0f;

        while (elapsedTime < 1f){
            elapsedTime += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(1, 0, elapsedTime / 1f);
            yield return null;
        }
    }

    void OnEnable(){
        Spawner.OnBossSpawn += ShowAlertText;
    }

    void OnDisable(){
        Spawner.OnBossSpawn -= ShowAlertText;
    }
}
