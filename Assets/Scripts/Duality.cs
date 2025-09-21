using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Duality : MonoBehaviour
{
    public bool switched = true;
    [SerializeField] GameObject demonHand;
    [SerializeField] GameObject priestHand;

    [SerializeField] float healthInc;
    [SerializeField] float healthDec;

    // Update is called once per frame
    void Update()
    {

        if (switched)
        {
            gameObject.GetComponent<Player_health>().current_playerHealth += healthInc * Time.deltaTime;
            priestHand.SetActive(true);
            demonHand.SetActive(false);
        }
        else if (!switched)
        {
            gameObject.GetComponent<Player_health>().current_playerHealth -= healthDec * Time.deltaTime;
            demonHand.SetActive(true);
            priestHand.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && switched)
        {
            Debug.Log("Switched to Demon");
            switched = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !switched)
        {
            Debug.Log("Switched to Priest");
            switched = true;
        }
    }
}
