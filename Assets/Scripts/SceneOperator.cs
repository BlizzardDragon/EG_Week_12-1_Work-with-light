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

        if(Instance == null)
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
        if(Input.anyKey)
        {
            if(SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
            {
                Debug.Log(SceneManager.sceneCountInBuildSettings + " "+ SceneManager.GetActiveScene().buildIndex);
                LoadScene(0);
            }
            else
            {
                LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        //ChangeColorText();
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

    private void ChangeColorText()
    {
        _timer += + Time.deltaTime * 1;
        
        if (_timer < 1)
        {
            _epilepsy.color = Color.red;
        }

        else if (_timer < 2)
        {
            _epilepsy.color = Color.blue;
        }

        else if (_timer < 3)
        {
            _epilepsy.color = Color.yellow;
        }

        else if (_timer < 4)
        {
            _epilepsy.color = Color.magenta;
        }
        
        else if (_timer < 5)
        {
            _epilepsy.color = Color.green;
        }
        else
        {
            _timer = 0;
        }
    }
}
