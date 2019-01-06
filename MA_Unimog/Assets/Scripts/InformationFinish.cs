
using UnityEngine.UI;
using UnityEngine;

public class InformationFinish : MonoBehaviour {

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
            information.text = "Du bist kurz vorm Ziel. \n dein Ergebnis berechnet sich" +
                " \n aus der übrigen Zeit \n und den zum Ziel \n" +
                " transportierten Kisten";
        }
    }

    public void Done()
    {
        information.text = "";
        go.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
