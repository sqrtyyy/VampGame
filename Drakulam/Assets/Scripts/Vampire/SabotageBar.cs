using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SabotageBar : MonoBehaviour
{
    public Image bar;
    private bool isInCycle = false;
    IEnumerator checkTime()
    {
        isInCycle = true;
        while (VampireTaskDisabler.getPercents() < 1)
        {
            
            Debug.Log(VampireTaskDisabler.getPercents());
            bar.fillAmount = VampireTaskDisabler.getPercents();
            yield return new WaitForSeconds(1);
        }

        bar.fillAmount = 1;
        isInCycle = false;
    }

    void FixedUpdate()
    {
        if (!isInCycle)
        {
            StartCoroutine(checkTime());
        }
    }
    
}
