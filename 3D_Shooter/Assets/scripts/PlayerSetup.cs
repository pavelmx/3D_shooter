using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent (typeof(Player))]
public class PlayerSetup : NetworkBehaviour {

	[SerializeField] 
	private string remoteLayer = "RemotePlayer";

	private Camera sceneCamera;

	[SerializeField] 
	Behaviour[] componentsToDisable;  //массив где храняться компоненты для скрытия

	void Start()
	{
		Cursor.visible = false;

		if (!isLocalPlayer){   //если я не локальный игрок
			for (int i = 0; i < componentsToDisable.Length; i++)
				componentsToDisable [i].enabled = false;   //то скрываем ненужные компоненты
			gameObject.layer = LayerMask.NameToLayer(remoteLayer);
		}
			else
		{
			sceneCamera = Camera.main;
			if (sceneCamera != null)
				sceneCamera.gameObject.SetActive (false);
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient ();

		string netID = GetComponent<NetworkIdentity> ().netId.ToString();
		Player player = GetComponent<Player>();
		GameManager.RegisterPlayer (netID, player);
	}


	void OnDisable()
	{
		if (sceneCamera != null)
			sceneCamera.gameObject.SetActive (true);
	
		GameManager.UnRegisterPlayer (transform.name);
	}


}
