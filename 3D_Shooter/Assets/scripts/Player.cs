using UnityEngine.Networking;
using UnityEngine;

public class Player : NetworkBehaviour {

	[SerializeField]
	private float maxHealth = 100f;

	[SyncVar]
	private float currHealth;

	void Awake()
	{
		currHealth = maxHealth;
	}

	public void TakeDamage(float damage)
	{
		currHealth -= damage;
		Debug.Log (transform.name + " имеет " + currHealth + " единиц здоровья");

		if (currHealth <= 0f) {
			GameObject.Destroy(gameObject);
			Debug.Log (transform.name + " был убит");
		}
	}
}
