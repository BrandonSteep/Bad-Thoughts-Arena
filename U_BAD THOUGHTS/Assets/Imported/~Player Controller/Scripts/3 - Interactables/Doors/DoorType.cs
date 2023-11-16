using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Keys and Doors/Door")]
public class DoorType : ScriptableObject
{
    [TextArea] public string lockType;
    public bool isLocked = true;
    [TextArea] public string inspectInfo;
}
