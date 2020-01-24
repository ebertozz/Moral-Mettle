using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPlayer : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup titleScreen;

    [SerializeField]
    private CanvasGroup gameScreen;

    void Awake()
    {
        gameScreen.alpha = 0f;
        gameScreen.interactable = false;
        gameScreen.blocksRaycasts = false;

    }

    public InputField playerNameInput; // reference to Input field
    private string playerName; // var to hold name player typed
    public Text tellPlayer; // reference to text field to greet player - title Screen
    public Text instructions; // reference to text field for instruc - Game screen

    public void GreetPlayer()
    {

        playerName = playerNameInput.text;
        //Debug.Log("Hello" + playerName);
        tellPlayer.text = playerName;
    }

    public void StartGame()
    {
        titleScreen.alpha = 0f;
        titleScreen.interactable = false;
        titleScreen.blocksRaycasts = false;

        gameScreen.alpha = 1f;
        gameScreen.interactable = true;
        gameScreen.blocksRaycasts = true;

        instructions.text = "Hello " + playerName + ". How will you resolve these quandries? You don't know your mettle till you test it!";

    }

}
