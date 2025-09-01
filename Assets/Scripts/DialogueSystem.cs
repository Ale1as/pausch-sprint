using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject Player;
    public GameObject dialogueBox;
    public float textSpeed = 0.05f;

    private Dialoguedata currentDialogue;
    private int index;

    // 🔹 Event fired when dialogue ends
    public event Action OnDialogueEnd;

    void Start()
    {
        textComponent.text = string.Empty;
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (currentDialogue == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == currentDialogue.lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = currentDialogue.lines[index];
            }
        }
    }

    public void StartDialogue(Dialoguedata dialogue)
    {
        currentDialogue = dialogue;
        textComponent.text = string.Empty;
        dialogueBox.SetActive(true);
        Player.GetComponent<Movement>().enabled = false;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentDialogue.lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < currentDialogue.lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        index = 0;
        currentDialogue = null;
        Player.GetComponent<Movement>().enabled = true;
        dialogueBox.SetActive(false);
        FindAnyObjectByType<Camera>().GetComponent<FPScamera>().enabled = true;

        // 🔹 Invoke event so others know
        OnDialogueEnd?.Invoke();
    }
}
