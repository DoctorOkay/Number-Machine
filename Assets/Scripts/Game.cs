using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
    [SerializeField] private AudioSource beep;

    private int guess;
    private int currentMin;
    private int currentMax;
    private int guessCount;

    private bool waitingForPlayer;
    private bool game;

    private Button[] buttons;

    private string pattern = "^[a-zA-Z0-9_]*$";
    private Regex rx;


    void Start()
    {
        outputText.text = "";

        currentMin = minNumber;
        currentMax = maxNumber + 1;
        guessCount = 0;

        game = true;
        waitingForPlayer = false;

        rx = new Regex(pattern);
        

        buttons = FindObjectsOfType<Button>();

        StartCoroutine(AnimateText(
            "|> Welcome to Number Machine\n|> " +
            "You are going to think of a number and I am going to guess it.\n|> " +
            "If your number is higher press the \"Higher\" button.\n|> " +
            "If your number is lower, press the \"Lower\" button\n|> " +
            "If I get it right, press \"Correct!\"\n|> " +
            "Ready? Then let's start.\n|> " +
            "Think of a number between " + minNumber + " and " + maxNumber + "\n|> " +
            "(Don't tell me what it is)\n|> "
            ));
    }

    public void GuessTooHigh()
    {
        waitingForPlayer = false;
        currentMax = guess;
        StartCoroutine(AnimateText("Ahhh, my guess is too high.\n|> "));
        
    }

    public void GuessTooLow()
    {
        waitingForPlayer = false;
        currentMin = guess;
        StartCoroutine(AnimateText("Hmmm, my guess is too low.\n|> "));
        
    }

    public void GuessCorrect()
    {
        game = false;

        StartCoroutine(AnimateText(
            "Great, I got it right!\n|> " +
            "Game over, do you want to play again?"
            ));

    }

    private void MakeGuess()
    {            
        if (guessCount == 0)
        {
            // initial guess
            if (minNumber == 1)
            {
                guess = maxNumber / 2;
            }
            else
            {
                guess = UnityEngine.Random.Range(minNumber, maxNumber);
            }

        }
        else
        {
            guess = UnityEngine.Random.Range(currentMin, currentMax);
        }

        waitingForPlayer = true;
        StartCoroutine(AnimateText("I guess your number is: " + guess + "\n|> "));
        guessCount++;
        
    }

    private IEnumerator AnimateText(string output)
    {
        DisableButtons();

        for (int i = 0; i < output.Length; i++)
        {
            if (beep.isPlaying)
            {
                beep.Stop();
            }

            if (rx.IsMatch(output[i].ToString()))
            {
                beep.Play();
            }
            
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
        else
        {
            SceneManager.LoadScene("NM_GameOver", LoadSceneMode.Additive);
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
