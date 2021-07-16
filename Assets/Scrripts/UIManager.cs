using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject Complete;
    public GameObject Fail;
    public GameObject FinishConfetti;
    public GameObject ObstacleEffect;
    public GameObject CubeEffect;
    public GameObject PlayerEffect;

    public Text currentLevel;
    public Text score;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        currentLevel.text = "LEVEL " + GameManagerScript.instance.level;
    }

    public void ShowFinishConfetti()
	{
        Instantiate(FinishConfetti, GameObject.FindGameObjectWithTag("Finish").transform.position, transform.rotation);
	}
    public void ShowObstacleEffect(Transform transform)
    {
        Instantiate(ObstacleEffect, transform.position, transform.rotation);
    }
    public void ShowCubeEffect(Transform transform)
    {
        Instantiate(CubeEffect, transform.position, transform.rotation);
    }
    public void ShowPlayerEffect(Transform transform)
    {
        Instantiate(PlayerEffect, transform.position, transform.rotation);
    }
}
