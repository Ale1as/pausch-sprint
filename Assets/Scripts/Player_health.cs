using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Player_health : MonoBehaviour
{
    public float total_playerHealth;
    public float current_playerHealth;
    public GameObject deathUI;
    public int killCount;
    bool isHealed;
    public Dialoguedata dialogue; // assign in inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        killCount = 0;
        TriggerDialogue();
        deathUI.GetComponentInChildren<TextMeshProUGUI>().alpha = 0;
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
            PlayDeathUI();
            FindAnyObjectByType<Movement>().enabled = false;
            FindAnyObjectByType<Shooting>().enabled = false;
            FindAnyObjectByType<Duality>().enabled = false;
            FindAnyObjectByType<FPScamera>().enabled = false;
            current_playerHealth = 0;
        }
    }

    void PlayDeathUI()
    {
        deathUI.SetActive(true);
        deathUI.GetComponentInChildren<TextMeshProUGUI>().alpha += 0.5f * Time.deltaTime;
    }
}
