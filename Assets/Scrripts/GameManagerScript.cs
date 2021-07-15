using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;

    public IEnumerator WaitAndShowSucces()
    {
        yield return new WaitForSeconds(0.1f);
        UIManager.instance.Complete.SetActive(true);
        Time.timeScale = 0;
    }

    public IEnumerator WaitAndShowFail()
    {
        yield return new WaitForSeconds(.5f);
        UIManager.instance.Fail.SetActive(true);
        Time.timeScale = 0;
    }

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

    public void Reload()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
