using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNameInputManager : MonoBehaviour
{
    public void SetPlayername(string playername)
    {
        if(string.IsNullOrEmpty(playername))
        {
            Debug.Log("player name is empty");
        }

        PhotonNetwork.NickName = playername;

    }
}
