using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class SabotageBar : MonoBehaviour, IPunObservable
{
    public Image bar;
    private bool isInCycle = false;
    IEnumerator checkTime()
    {
        isInCycle = true;
        while (VampireTaskDisabler.getPercents() < 1)
        {
            
            Debug.LogWarning(VampireTaskDisabler.getPercents());
            bar.fillAmount = VampireTaskDisabler.getPercents();
            yield return new WaitForSeconds(1);
        }

        bar.fillAmount = 1;
        isInCycle = false;
    }

    void Update()
    {
        if (!isInCycle)
        {
            StartCoroutine(checkTime());
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
}
