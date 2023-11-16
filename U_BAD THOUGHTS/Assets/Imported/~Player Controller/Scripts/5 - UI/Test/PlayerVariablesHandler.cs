using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariablesHandler : MonoBehaviour
{
    [SerializeField] private ScriptableVariable maxHP;
    [SerializeField] private ScriptableVariable currentHP;

    [SerializeField] private ScriptableVariable maxStamina;
    [SerializeField] private ScriptableVariable currentStamina;

    // Start is called before the first frame update
    void Start()
    {
        currentHP.value = maxHP.value;
        currentStamina.value = maxStamina.value;
    }
}
