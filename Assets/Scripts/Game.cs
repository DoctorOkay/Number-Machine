using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private int minNumber;
    [SerializeField] private int maxNumber;
    [SerializeField] private TextMeshProUGUI outputText;

    private int guess;
    private bool waitingForPlayer;
    private bool game;

    private Button[] buttons;
        
    // Start is called before the first frame update
    void Start()
    {
        game = true;
        waitingForPlayer = false;
        outputText.SetText("");

        buttons = FindObjectsOfType<Button>();

        StartCoroutine(AnimateText(
            "|> Welcome to Number Machine\n" +
            "|> You are going to think of a number and I am going to guess it.\n" +
            "|> If your number is higher press the \"Higher\" button.\n" +
            "|> If your number is lower, press the \"Lower\" button\n" +
            "|> If I get it right, press \"Correct!\"\n" +
            "|> Ready? Then let's start.\n" +
            "|> Think of a number between " + minNumber + " and " + maxNumber + "\n" +
            "|> (Don't tell me what it is)\n"
            ));
    }

    

    // Update is called once per frame
    void Update()
    {

 
    }

    public void GuessTooHigh()
    {
        waitingForPlayer = false;
        maxNumber = guess;
        StartCoroutine(AnimateText("|> Ahhh, my guess is too high.\n"));
        
    }

    public void GuessTooLow()
    {
        waitingForPlayer = false;
        minNumber = guess;
        StartCoroutine(AnimateText("|> Hmmm, my guess is too low.\n"));
        
    }

    public void GuessCorrect()
    {
        game = false;

        StartCoroutine(AnimateText(
            "|> Great, I got it right!\n" +
            "|> Game over, do you want to play again?"
            ));

    }

    private void MakeGuess()
    {
        guess = (minNumber + maxNumber) / 2;
        waitingForPlayer = true;
        StartCoroutine(AnimateText("|> I guess your number is: " + guess + "\n"));
        
    }

    private IEnumerator AnimateText(string output)
    {
        DisableButtons();

        for (int i = 0; i < output.Length; i++)
        {
            outputText.text = outputText.text + output[i];
            yield return new WaitForSecondsRealtime(0.01f);
        }

        if (game)
        {
            if (!waitingForPlayer)
            {
                MakeGuess();

                yield return new WaitForSecondsRealtime(0.7f);
                EnableButtons();
            }
        }
    }

    private void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    private void EnableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
