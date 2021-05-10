using UnityEngine;
using Photon.Pun;

public class HittableCharacter : IHittable
{
    public override void Hit(int damage)
    {
        if (GetComponent<IHealth>().isDead) return;
        AsynchronousHit(damage);
        PhotonView photonView = PhotonView.Get(this);
        if (PhotonNetwork.IsConnectedAndReady && PhotonNetwork.CurrentRoom != null)
        {
            photonView.RPC("AsynchronousHit", RpcTarget.Others, damage);
        }
    }

    [PunRPC]
    public void AsynchronousHit(int damage)
    {
        GetComponent<Animator>().SetTrigger("hurt");
        GetComponent<IHealth>().changeHealth(-damage);
    }
}
