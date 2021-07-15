using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;

    [HideInInspector]
    public static int levelIndex = 1;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        switch (levelIndex)
        {
            case 1:
                level1.SetActive(true);
                break;
            case 2:
                level1.SetActive(false);
                level2.SetActive(true);
                break;
            case 3:
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(true);
                break;
            case 4:
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(false);
                level4.SetActive(true);
                break;
            default:
                level1.SetActive(true);
                break;
        }
    }
}
