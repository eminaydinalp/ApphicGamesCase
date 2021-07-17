using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
	Rigidbody _rigidbody;

	float force = 850f;
	public int score;

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
		if(Input.touchCount > 0)
		{
			TapPlayer();
		}
		if (Input.GetMouseButtonDown(0))
		{
			TapPlayer();
		}

	}

	private void TapPlayer()
	{
		UIManager.instance.ShowPlayerEffect(transform);
		_rigidbody.velocity = Vector3.zero;
		Jump();
	}

	public void Jump()
	{
		_rigidbody.AddForce(new Vector3(0, 1, 1) * force * Time.deltaTime, ForceMode.Impulse);
		transform.DORotate(new Vector3(0, 0, 180), 1);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("cube"))
		{
			score += 1;
			collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 1) * 300 * Time.deltaTime, ForceMode.Impulse);
			StartCoroutine(UIManager.instance.ShowCubeEffect(collision.gameObject));
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
