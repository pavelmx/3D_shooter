using UnityEngine.Networking;
using UnityEngine;

public class PlayerShoot : NetworkBehaviour {

 public Weapon weapon;

 [SerializeField]
 private LayerMask mask;

 [SerializeField]
 private Camera cam;

 void Start () {
  if (cam == null) {
   Debug.LogError ("PlayerShoor: No camera!");
   this.enabled = false;
  }
 }
 void Update () {
  if (Input.GetButtonDown("Fire1")) {
   Shoot ();
  }
 }

 [Client]
 void Shoot () {
  RaycastHit _hit;
  if (Physics.Raycast (cam.transform.position, cam.transform.forward, out _hit, weapon.distanceShoot, mask)){
   Debug.LogError ("Мы попали в " + _hit.collider.name);
   if (_hit.collider.tag == "Player")
				CmdPlayerShoot (_hit.collider.name, weapon.damage);
      }
}

 [Command]
	void CmdPlayerShoot (string _ID, float damage) {
  Debug.Log ("в игрока " +_ID + " попали");

		Player player = GameManager.GetPlayer (_ID);
		player.TakeDamage (damage);
 }

}﻿
