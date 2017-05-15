using UnityEngine;
using System.Collections;

public class chasecamera : MonoBehaviour {

	GameObject Player;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("uguisu-player");
		mainCamera = GameObject.Find ("Main Camera");
	}
	// Update is called once per frame
	void Update () {

		mainCamera.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + 1, -1);

	}
}