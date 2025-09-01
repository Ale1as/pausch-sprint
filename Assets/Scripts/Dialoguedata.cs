using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Data")]
public class Dialoguedata : ScriptableObject
{
    [TextArea(2, 5)]
    public string[] lines;
}