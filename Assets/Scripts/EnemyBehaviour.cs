﻿using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	/// <summary>
	/// What is the Enemy going to be able to go
	/// When the Player hit a collider the enemy will spawn
	/// 
	///	/// </summary>
	// Use this for initialization

	CharacterMovement characterMovement;

	//Physics Vars.
	public float speed;
	public float health;

	GameObject canvas;
	Score scoreText;

	//info gathering Vars.
	public bool isChasing;
	public bool isAttacking;
	public bool isIdel;
	public bool isFacingLeft;
	public bool isFacingRight;
	public bool isAlive;

	//attacking vars
	public float timeToAttack;
	public Transform laserPref;
	public Transform laserPrefLeft;


	public float dir;
	private GameObject Player;

	void Start () {
		timeToAttack = 1.5f;
		isFacingLeft = true;
		Player = GameObject.FindWithTag("Player");
		characterMovement = Player.GetComponent<CharacterMovement>();
		canvas = GameObject.Find ("Score text");
		scoreText = canvas.GetComponent<Score>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Debug.Log ("swag");
		if(characterMovement.isAlive)
		{
			dir = Player.transform.position.x - transform.position.x;
		}

		if(dir > 0)
		{
			isFacingRight = true;
			isFacingLeft = false;
		}
		else if(dir < 0)
		{
			isFacingLeft = true;
			isFacingRight = false;
		}

		if(timeToAttack > 0)
		{
			Debug.Log ("swag");
			timeToAttack -= Time.deltaTime;
		}
		Attack ();

	}


	void Attack()
	{
		if(isAttacking && timeToAttack <= 0)
		{
			Debug.Log("1st if isAttacking");
			if(isFacingLeft == true)
			{
				Debug.Log ("");
				Instantiate(laserPrefLeft, new Vector2(this.transform.position.x - 2, this.transform.position.y), Quaternion.identity);
				timeToAttack = 7f;
			}
			if(isFacingRight == true)
			{
				Instantiate(laserPref, new Vector2(this.transform.position.x + 1, this.transform.position.y), Quaternion.identity);
				timeToAttack = 7f;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// if other colider is "Laser" do something
		if (col.gameObject.tag == "Laser") {
			
			Die();
			Destroy(col.gameObject);
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			isAttacking = true;
		}

	}

	void OnTriggerStay2D(Collider2D other)
	{

		if(other.gameObject.tag == "Player")
		{
			isAttacking = true;
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			isAttacking = false;
		}
	}
	
	public void Die()
	{
		Destroy (this.gameObject);
		scoreText.score = scoreText.score + 10;
	}
}
