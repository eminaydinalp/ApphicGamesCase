using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
	private void Update()
	{
		transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
	}
}
