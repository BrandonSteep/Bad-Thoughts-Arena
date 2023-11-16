using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private ScriptableVariable money;
    [SerializeField] private TMP_Text counter;

    private bool refresh = true;

    void Start()
    {
        counter = GetComponent<TMP_Text>();
        refresh = true;
    }

    void Update()
    {
        counter.text = "£ " + money.value.ToString();

        //if (refresh)
        //{
        //    StartCoroutine(UpdateCounter());
        //}

        //Debug.Log(refresh);
    }

    IEnumerator UpdateCounter()
    {
        refresh = false;
        counter.text = "£ " + money.value.ToString();
        yield return new WaitForSeconds(0.15f);
        refresh = true;
        yield return null;
    }
}
