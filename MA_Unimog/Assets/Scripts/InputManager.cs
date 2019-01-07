using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Button tiltDown;
    [SerializeField] private Button tiltUp;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    private UnityAction disableUserInputListener;
    private UnityAction enableUserInputListener;

    void Awake()
    {
        disableUserInputListener = new UnityAction(DisableInput);
        enableUserInputListener = new UnityAction(EnableInput);

        EventListener.StartListening("DisablePlayerInputEvent", disableUserInputListener);
        EventListener.StartListening("EnablePlayerInputEvent", enableUserInputListener);
    }

    private void EnableInput()
    {
        joystick.gameObject.SetActive(true);
        tiltDown.gameObject.SetActive(true);
        tiltUp.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    private void DisableInput()
    {
        joystick.gameObject.SetActive(false);
        tiltDown.gameObject.SetActive(false);
        tiltUp.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
}
