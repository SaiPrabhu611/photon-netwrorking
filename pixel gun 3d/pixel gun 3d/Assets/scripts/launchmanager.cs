using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class launchmanager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionstatusPanel;
    public GameObject LobbyPanel;
    #region UnityMethods

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionstatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Public Methods
    public void ConnectToPhotonServer()
    {
        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionstatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);
        }
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.LoadLevel("GameScene");
    }
    #endregion

    #region Phton Callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName+ " connected to photon");
        LobbyPanel.SetActive(true);
        ConnectionstatusPanel.SetActive(false);
    }

    public override void OnConnected()
    {
        Debug.Log("connected to internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName+" joined to "+PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName+" joined to " +PhotonNetwork.CurrentRoom.Name+" "+PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion

    #region Private methods
    void CreateAndJoinRoom()
    {
        string RandomRoomName = "Room " + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(RandomRoomName,roomOptions);
    }
    #endregion

}
