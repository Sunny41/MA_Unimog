using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Button tiltDown;
    [SerializeField] private Button tiltUp;
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
        joystick.enabled = true;
        tiltDown.enabled = true;
        tiltUp.enabled = true;
    }

    private void DisableInput()
    {
        joystick.enabled = false;
        tiltDown.enabled = false;
        tiltUp.enabled = false;
    }
}
