using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPlayer : MonoBehaviour
{
    public InputField playerNameInput; // reference to Input field
    private string playerName; // var to hold name player typed
    public Text tellPlayer; // reference to text field to greet player - title Screen
   


   

    public void GreetPlayer()
    {

        playerName = playerNameInput.text;
        Debug.Log("Hello " + playerName);
        tellPlayer.text = "Hello " + playerName + ". How will you resolve these quandries? You don't know your mettle till you test it!";
        PlayerPrefs.SetString("PlayerName", playerName);
     

    }

    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }

}
