using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; // allows us to use arrays
using UnityEngine.SceneManagement;

public class AskPlayer : MonoBehaviour
{

    public Quandaries[] quandaries; //reference to class 
    private static List<Quandaries> unansweredQuestions; //create a list to hold unanswered questions and make it persist
    private Quandaries currentQuestion; // var to hold current question
    public GameObject restart_btn;
    public Text instructions;
    private string myPlayer;
    public int justiceScore = 0;  // keep track of both kinds of scores
    public int empathyScore = 0;

    [SerializeField]  //
    private Text quandaryText; // way to convert list item to text string
    [SerializeField]  //
    private Text answerAText; // way to convert list item to text string
    [SerializeField]  //
    private Text answerBText; // way to convert list item to text string

    [SerializeField]  //
    private Text justScore; // way to convert list item to text string
    [SerializeField]  //
    private Text empScore; // way to convert list item to text string




    [SerializeField]
    private Image screenImage;
    [SerializeField]
    private Sprite who, teresa, kim, joe ;




    // Start is called before the first frame update
    void Start()
    {
        myPlayer = PlayerPrefs.GetString("PlayerName");
        instructions.text = myPlayer + "  Let's see what you are made of!";
        BeginGame(); // call function that loads text

    }

    public void BeginGame()
    {

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)// if the list hasn't been filled or is empty
        {
            unansweredQuestions = quandaries.ToList<Quandaries>(); // fill list with questions from array
            print(unansweredQuestions);
        }

        restart_btn.SetActive(false); //turn button off till needed

        SetCurrentQuestion();  // call the function that selects a random question.
    }



    void SetCurrentQuestion()

    {
        
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count); // set a random number to the index of the list
        currentQuestion = unansweredQuestions[randomQuestionIndex]; // extract a question at that index from the list

        quandaryText.text = currentQuestion.quandary;  // fill the text fields on the stage with elements from array
        answerAText.text = currentQuestion.ansOne;
        answerBText.text = currentQuestion.ansTwo;
        string myName = currentQuestion.imgName;

        Sprite DaSprite = Resources.Load(myName, typeof(Sprite)) as Sprite;//randomstring converted to sprite
        screenImage.sprite = DaSprite;
    }

    public void PlayerSelectA()   // actions after player selects A answer
    {
        if (unansweredQuestions.Count > 1)
        {

            justiceScore += currentQuestion.ansAjust;   // increment the  vars
            empathyScore += currentQuestion.ansAemp;
            justScore.text = "Justice: " + justiceScore.ToString();
            empScore.text = "Empathy: " + empathyScore.ToString();
            unansweredQuestions.Remove(currentQuestion);  // remove the used question from the array
            Debug.Log("your honesty is " + justiceScore + "and empathy is " + empathyScore);
            SetCurrentQuestion();
        }
        else
        {
            AssessPlayer();
        }


    }
    public void PlayerSelectB()   // same actions for B
    {
        if (unansweredQuestions.Count > 1)
        {
            empathyScore += currentQuestion.ansBemp;
            justiceScore += currentQuestion.ansBjust;
            justScore.text = "Justice: " + justiceScore.ToString();
            empScore.text = "Empathy: " + empathyScore.ToString();
            unansweredQuestions.Remove(currentQuestion);
            Debug.Log("your honesty is " + justiceScore + " and empathy is " + empathyScore);
            SetCurrentQuestion();

        }
        else
        {
            AssessPlayer();
        }
    }

    void AssessPlayer()
    {
        answerAText.text = "";
        answerBText.text = "";


        if (justiceScore > empathyScore)
        {
            quandaryText.text =  " you value the rule of law over the feelings of humans.";
            screenImage.sprite = kim;
        }
        else if (justiceScore < empathyScore)
        {

            quandaryText.text = " Self sacrifice, but at what cost?";
            screenImage.sprite = teresa;

        } else if (justiceScore == empathyScore){
            quandaryText.text = " you are an average Joe, just trying to figure it out.";
            screenImage.sprite = joe;
        }

        restart_btn.SetActive(true);
        unansweredQuestions = null;

    }

    public void RestartGame()
    {

        SceneManager.LoadScene(0);
    }

}
