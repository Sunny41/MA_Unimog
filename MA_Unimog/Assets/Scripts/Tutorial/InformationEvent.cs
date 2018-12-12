using UnityEngine;

public class InformationEvent : MonoBehaviour {

    [SerializeField] private GameObject go;
    private bool started;

    void Awake()
    {
        started = false;
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
        }
    }

    public void Done()
    {
        go.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
