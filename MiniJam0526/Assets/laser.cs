using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {
	
	public int speed;
	public float lifeTimer;
	// Use this for initialization
	void Start () {
		lifeTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0,speed * Time.deltaTime,Space.Self);
		lifeTimer += Time.deltaTime;
		if(lifeTimer >= 2){
			Destroy(this.gameObject);
		}
	}
}
