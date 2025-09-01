using UnityEngine;

public class FoundKey : MonoBehaviour
{
    public Dialoguedata dialogue; // assign in inspector
    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueSystem>().StartDialogue(dialogue);
    }
}
