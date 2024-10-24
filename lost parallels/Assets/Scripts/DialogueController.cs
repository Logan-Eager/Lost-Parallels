using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public string destination;
    public AudioSource kidtalking;
    public AudioSource drivertalking;

    private AudioSource typingSound;
    private int index;
    private Coroutine typingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        // on left click either next line or finish the line of dialogue
        if (Input.GetMouseButtonDown(0))
        {

            if (textComponent.text == lines[index])
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // determines speech tone
        typingSound = kidtalking;

        if (lines[index].Substring(0, 3) == "Dri")
        {
            typingSound = drivertalking;
        }


        textComponent.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
            {
            textComponent.text += c;
            typingSound.Play();
            if (c == '.' || c == '?')
                {
                yield return new WaitForSeconds(textSpeed * 3);
                }

            else
            {
                yield return new WaitForSeconds(textSpeed);
            }
            
            }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            typingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene(destination);
        }
    }
}
