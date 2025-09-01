using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_health : MonoBehaviour
{
    public float total_playerHealth;
    public float current_playerHealth;
    public GameObject deathUI;
    public Dialoguedata dialogue; // assign in inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TriggerDialogue();
    }



    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueSystem>().StartDialogue(dialogue);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (current_playerHealth > total_playerHealth)
        {
            current_playerHealth = total_playerHealth;
        }

        if (current_playerHealth <= 0)
        {
            FindAnyObjectByType<Movement>().enabled = false;
            FindAnyObjectByType<drawLine>().enabled = false;
            current_playerHealth = 0;
            deathUI.SetActive(true);
        }
    }
}
