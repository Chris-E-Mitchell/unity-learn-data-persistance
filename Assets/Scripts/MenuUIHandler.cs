using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;

    public void LoadGameScene()
    {        
        if (playerNameInput.text == "")
        {
            GameManager.Instance.PlayerName = "Anon";
        }
        else
        {
            GameManager.Instance.PlayerName = playerNameInput.text;
        }

        SceneManager.LoadScene(1);
    }
}
