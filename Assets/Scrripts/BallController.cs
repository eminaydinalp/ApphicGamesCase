using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
	Rigidbody _rigidbody;

	public int score;
	public float time;

	public bool isJump;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Start()
	{
		isJump = false;
	}

	private void FixedUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isJump = true;
			_rigidbody.velocity = Vector3.zero;
			Jump();
		}
		if(!isJump)
		_rigidbody.velocity += new Vector3(0, 0, Time.deltaTime * 15);

	}
	
	public void Jump()
	{
		_rigidbody.AddForce(Vector3.up * 20000 * Time.deltaTime);
		transform.DORotate(new Vector3(0, 0, 180), 1);
		isJump = false;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("cube"))
		{
			score += 1;
		}
		else if (collision.gameObject.CompareTag("obstacle"))
		{
			StartCoroutine(GameManagerScript.instance.WaitAndShowFail());
		}
		else if (collision.gameObject.CompareTag("Finish"))
		{
			Debug.Log("Finish");
			UIManager.instance.score.text = "Score : " + score.ToString();
			StartCoroutine(GameManagerScript.instance.WaitAndShowSucces());
		}
	}

}
