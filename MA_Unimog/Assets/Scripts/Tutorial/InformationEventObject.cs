using UnityEngine;
using UnityEngine.UI;

public class InformationEventObject : MonoBehaviour {

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
            information.text = "Auf dem Weg zum Musseum \n liegen manchmal \n aufsammelbare" +
                " Gegenstände \n rum(Kisten,Tank,..), \n diese können dir zum ereichen des \n Ziels helfen";
        }
    }

    public void Done()
    {
        information.text = "";
        go.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
