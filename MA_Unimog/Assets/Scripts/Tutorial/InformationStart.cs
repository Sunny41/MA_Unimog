using UnityEngine;
using UnityEngine.UI;

public class InformationStart : MonoBehaviour
{

    [SerializeField] private GameObject go;
    public Text information;
    private bool started;

    void Awake()
    {
        started = false;
        information.text = "";
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ShowInformation();
        }
    }

    private void ShowInformation()
    {
        if (!started)
        {
            started = true;
            go.SetActive(true);
            Time.timeScale = 0f;
            information.text = "In der oberen Leiste siehst du \n von links nach rechts: \n Zeit, Kisten, Tank \n" +
                " und Reset- sowie Pausemenü ";
        }
    }

    public void Done()
    {
        information.text = "";
        go.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}