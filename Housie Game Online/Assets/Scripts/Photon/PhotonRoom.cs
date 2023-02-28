using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    public static PhotonRoom room;
	PhotonView PV;
	public int multiPlayerScene;

	private void Awake()
	{
		if(PhotonRoom.room == null)
		{
            PhotonRoom.room = this;
		}
		else
		{
			if(PhotonRoom.room != this)
			{
				Destroy(PhotonRoom.room.gameObject);
				PhotonRoom.room = this;
			}
		}
		DontDestroyOnLoad(this.gameObject);
	}

	public override void OnEnable()
	{
		base.OnEnable();
		PhotonNetwork.AddCallbackTarget(this);
		SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}

	public override void OnDisable()
	{
		base.OnDisable();
		PhotonNetwork.RemoveCallbackTarget(this);
		SceneManager.sceneLoaded -= OnSceneFinishedLoading;
	}

	// Start is called before the first frame update
	void Start()
    {
		PV = GetComponent<PhotonView>();
    }

	void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
	{

	}

	public override void OnJoinedRoom()
	{
		base.OnJoinedRoom();
		Debug.Log("We are now in a room");
	}

	void StartGame()
	{
		if (!PhotonNetwork.IsMasterClient)
			return;

		PhotonNetwork.LoadLevel(multiPlayerScene);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
