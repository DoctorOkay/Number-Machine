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
    [TextArea(10, 14)] [SerializeField] private string introText;
    [SerializeField] private TextMeshProUGUI outputText;

    private int guess;

    // Start is called before the first frame update
    void Start()
    {
        outputText.text = introText;
        outputText.text = outputText.text + "Think of a number between " + minNumber + " and " + maxNumber + "\n";
        outputText.text = outputText.text + "(Don't tell me what it is)\n";

        MakeGuess();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void GuessTooHigh()
    {
        outputText.text = outputText.text + "Ahhh, my guess is too high.\n";
        maxNumber = guess;
        MakeGuess();
    }

    public void GuessTooLow()
    {
        outputText.text = outputText.text + "Hmmm, my guess is too low.\n";
        minNumber = guess;
        MakeGuess();
    }

    public void GuessCorrect()
    {
        outputText.text = outputText.text + "Great, I got it right!\n";
        outputText.text = outputText.text + "Game over :)";

    }

    private void MakeGuess()
    {
        guess = (minNumber + maxNumber) / 2;
        outputText.text = outputText.text + "I guess your number is: " + guess + "\n";
    }
}
