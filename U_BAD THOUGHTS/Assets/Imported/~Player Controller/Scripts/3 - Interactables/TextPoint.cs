using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPoint : Interactable
{
    [TextArea] [SerializeField] private string inspectInfo;

    public override void Interact()
    {
        //if(isDark)
        //{
        //    Debug.Log("It's too dark");
        //    References.inspectController.ShowInfo("It's too dark to see...");
        //    return;
        //}

        References.inspectController.ShowInfo(inspectInfo);
    }
}
