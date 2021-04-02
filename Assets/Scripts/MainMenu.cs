using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private string myTitleText;

    private AudioSource textClick;

    // Start is called before the first frame update
    void Start()
    {
        titleText.text = "";
        textClick = gameObject.GetComponent<AudioSource>();
        StartCoroutine(AnimateTitle(myTitleText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimateTitle(string inputText)
    {
        if (textClick == null)
        {
            textClick = gameObject.GetComponent<AudioSource>();
        }

        for (int i = 0; i < inputText.Length; i++)
        {
            if (!inputText[i].ToString().Contains(" "))
            {
                textClick.Play();
            }

            titleText.text = titleText.text + inputText[i];
            yield return new WaitForSecondsRealtime(0.12f);
        }
    }
}
