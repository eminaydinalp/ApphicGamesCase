using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;

    public GameObject lyrLevel;
    public GameObject[] preLevel;

    [HideInInspector] public int level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
	{
        if (PlayerPrefs.GetInt("CurrentLevel") == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
        level = PlayerPrefs.GetInt("CurrentLevel");
        RemoveAllLevels();
        AddLevel();
    }
	public IEnumerator WaitAndShowSucces()
    {
        yield return new WaitForSeconds(0.1f);
        UIManager.instance.Complete.SetActive(true);
        UIManager.instance.ShowFinishConfetti();
        yield return new WaitForSeconds(4f);
        Time.timeScale = 0;
    }

    public IEnumerator WaitAndShowFail()
    {
        yield return new WaitForSeconds(.5f);
        UIManager.instance.Fail.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 0;
    }

    public void SetNextLevel()
    {
        level = PlayerPrefs.GetInt("CurrentLevel") + 1;
        PlayerPrefs.SetInt("CurrentLevel", level);
        if (level > preLevel.Length)
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            level = 1;
        }
        Debug.Log("SetNextLevel : " + level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}
	private void RemoveAllLevels()
    {
        foreach (Transform child in lyrLevel.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void AddLevel()
    {
        Instantiate(preLevel[(level - 1)], new Vector3(0, 0, 0), Quaternion.identity, lyrLevel.transform);
    }
}
