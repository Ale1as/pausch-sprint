using UnityEngine;

public class DemonArise : MonoBehaviour
{
    public Dialoguedata dialogue; // assign in inspector
    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueSystem>().StartDialogue(dialogue);
    }
}
