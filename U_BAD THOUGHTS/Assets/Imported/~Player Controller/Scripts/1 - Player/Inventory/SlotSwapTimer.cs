using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSwapTimer : MonoBehaviour
{
    [SerializeField] private SlotSwitcher slotSwitcher;
    
    public IEnumerator SlotTimer()
    {
        yield return new WaitForSeconds(0.25f);
        slotSwitcher.canSwap = true;
        yield return null;
    }
}
