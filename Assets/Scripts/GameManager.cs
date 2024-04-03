using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerSource, enemeySource, playerPrefab, enemyPrefab;
    PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            playerPrefab = PhotonNetwork.Instantiate(playerSource.name, new Vector3(0, 0.1f, 1f), Quaternion.identity);
            photonView.RPC("InitializePrefab", RpcTarget.Others, playerPrefab.GetPhotonView().ViewID);
        }
        else
        {
            enemyPrefab = PhotonNetwork.Instantiate(enemeySource.name, new Vector3(0, 0.1f, -1f), Quaternion.identity);
            photonView.RPC("InitializePrefab", RpcTarget.Others, enemyPrefab.GetPhotonView().ViewID);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    [PunRPC]
    private void InitializePrefab(int viewID)
    {
        PhotonView targetPhotonView = PhotonView.Find(viewID);
        if (targetPhotonView != null)
        {
            playerPrefab = targetPhotonView.gameObject;
        }
    }
}
