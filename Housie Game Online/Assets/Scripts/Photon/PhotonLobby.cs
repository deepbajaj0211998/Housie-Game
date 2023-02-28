using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{

    public static PhotonLobby lobby;
    public GameObject gameStartButton;
	public GameObject cancelGameButton;

	private void Awake()
	{
        lobby = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

	public override void OnConnectedToMaster()
	{
		Debug.Log("Player has connected to the Photon Master server.");
		PhotonNetwork.AutomaticallySyncScene = true;
		gameStartButton.SetActive(true);
	}

	public void OnStartGameButtonClicked()
	{
		Debug.Log("Start Game Button was clicked");
		gameStartButton.SetActive(false);
		cancelGameButton.SetActive(true);
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		Debug.Log("Tried to join a random room but failed. There must be no open games available");
		CreateRoom();
	}

	void CreateRoom()
	{
		Debug.Log("Trying to create a new room");
		int randomRoomName = Random.Range(0, 10000);
		RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
		PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
	}

	public override void OnCreateRoomFailed(short returnCode, string message)
	{
		Debug.Log("Tried to create a new Room but failed, there must already be a room with the same name");
		CreateRoom();
	}

	public void OnCancelGameButtonClicked()
	{
		Debug.Log("Cancel Button was clicked");
		cancelGameButton.SetActive(false);
		gameStartButton.SetActive(true);
		PhotonNetwork.LeaveRoom();
	}

}
