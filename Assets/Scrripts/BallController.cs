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
	public bool isFinish;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Start()
	{
		isJump = false;
		isFinish = false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isJump = true;
			_rigidbody.velocity = Vector3.zero;
			Jump();
		}
		if(!isJump && !isFinish)
		_rigidbody.velocity += new Vector3(0, 0, Time.deltaTime * 15);

	}
	
	public void Jump()
	{
		_rigidbody.AddForce(Vector3.up * 300 * Time.deltaTime, ForceMode.Impulse);
		transform.DORotate(new Vector3(0, 0, 180), 1);
		isJump = false;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("cube"))
		{
			UIManager.instance.ShowCubeEffect(collision.gameObject.transform);
			score += 1;
		}
		else if (collision.gameObject.CompareTag("obstacle"))
		{
			UIManager.instance.ShowObstacleEffect(collision.gameObject.transform);
			StartCoroutine(GameManagerScript.instance.WaitAndShowFail());
		}
		else if (collision.gameObject.CompareTag("Finish"))
		{
			_rigidbody.velocity = Vector3.zero;
			isFinish = true;
			UIManager.instance.score.text = "Score : " + score.ToString();
			StartCoroutine(GameManagerScript.instance.WaitAndShowSucces());
		}
	}

}
