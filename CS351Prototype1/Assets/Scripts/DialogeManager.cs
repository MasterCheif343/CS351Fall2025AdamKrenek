using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//must add this using statement to use TMP_Text
using TMPro;
public class DialogeManager : MonoBehaviour
{
    public TMP_Text textBox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject dialogPannel;

    private void OnEnable()
    {
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        //start textbox as empty
        textBox.text = "";

        //loop through the sentence, adding one letter at a time
        foreach (char letter in sentences[index])
        {
            textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }
    public void NextSentence()
    {
        //disable continue button
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textBox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textBox.text = "";
            dialogPannel.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
