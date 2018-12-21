using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Button tiltDown;
    [SerializeField] private Button tiltUp;

    public void EnableInput()
    {
        joystick.enabled = true;
        tiltDown.enabled = true;
        tiltUp.enabled = true;
    }

    public void DisableInput()
    {
        joystick.enabled = false;
        tiltDown.enabled = false;
        tiltUp.enabled = false;
    }
}
