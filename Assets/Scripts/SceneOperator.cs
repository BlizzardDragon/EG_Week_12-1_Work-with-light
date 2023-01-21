using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOperator : MonoBehaviour
{
    public static SceneOperator Instance;
    [SerializeField] Text _epilepsy;
    float _timer;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
            {
                Debug.Log(SceneManager.sceneCountInBuildSettings + " " + SceneManager.GetActiveScene().buildIndex);
                LoadScene(0);
            }
            else
            {
                LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void ReadStringInput(string S)
    {
        SendMassage.PlayerName = S;
        LoadScene(1);
    }

    void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
