using UnityEngine;
using Photon.Pun;

public class HittableCharacter : IHittable
{
    public override void Hit(int damage)
    {
        AsynchronousHit(damage);
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("AsynchronousHit", RpcTarget.Others, damage);
    }

    [PunRPC]
    public void AsynchronousHit(int damage)
    {
        GetComponent<Animator>().SetTrigger("hurt");
        GetComponent<IHealth>().changeHealth(-damage);
    }
}
