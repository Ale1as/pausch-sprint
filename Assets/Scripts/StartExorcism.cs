using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartExorcism : MonoBehaviour
{
    public Dialoguedata dialogue; // assign in inspector
    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueSystem>().StartDialogue(dialogue);
        FindAnyObjectByType<DialogueSystem>().OnDialogueEnd += ExorcismFinished;
    }

    public void ExorcismFinished()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Next scene");
    }
}
