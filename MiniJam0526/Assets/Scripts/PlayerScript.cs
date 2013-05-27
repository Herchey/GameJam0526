using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public float speed;
	public int spinSpeed;
	public int rollSpeed;
	public int pitchSpeed;
	public float shotTimer = 0;
	public GameObject laser;
	
	public GameObject leftBarrel;
	public GameObject rightBarrel;		
	public int chosenBarrel;
	public GameObject barrel;
	
	void Start () {
		speed = 25;
		chosenBarrel = 1;
		leftBarrel = GameObject.Find("leftBarrel");
		rightBarrel = GameObject.Find("rightBarrel");
		barrel = leftBarrel;
	}
	
	void Update () {
		if(Input.GetAxisRaw("Roll") != 0){
			transform.Rotate(0,0,Input.GetAxisRaw("Roll")*Time.deltaTime*-rollSpeed);
		}
		if(Input.GetAxisRaw("Pitch") != 0){
			transform.Rotate(Input.GetAxisRaw("Pitch")*Time.deltaTime*-pitchSpeed,0,0);
		}
		if(Input.GetAxis("Jump") != 0){
			if(shotTimer >= .25){
				Shoot();
				shotTimer = 0;
			}
		}
		if(Input.GetButton("SlowDown") == true && Input.GetButton("SpeedUp") == false){
			speed -= Time.deltaTime;
		}
		if(Input.GetButton("SlowDown") == false && Input.GetButton("SpeedUp") == true){
			speed += Time.deltaTime;
		}		
		
		transform.Translate(0,0,1*speed*Time.deltaTime);
		shotTimer += Time.deltaTime;
	}
	
	void Shoot(){
		if(chosenBarrel == 1){
			Instantiate(laser, barrel.transform.position, barrel.transform.rotation);			
			barrel = rightBarrel;
			chosenBarrel = 2;
		}else{
			Instantiate(laser, barrel.transform.position, barrel.transform.rotation);
			barrel = leftBarrel;
			chosenBarrel = 1;
		}
	}
}

