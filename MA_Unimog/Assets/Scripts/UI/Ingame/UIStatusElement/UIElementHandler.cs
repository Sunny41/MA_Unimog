using UnityEngine;

public class UIElementHandler : MonoBehaviour {

    [SerializeField]
    private UIStatusElement uiTime;
    [SerializeField]
    private UIStatusElement uiPackage;
    [SerializeField]
    private UIStatusElement uiFuel;

    public void SetTime(int seconds)
    {
        uiTime.SetText(seconds + "s");
    }

    public void SetPackageCount(int remainingPackages)
    {
        uiPackage.SetText(remainingPackages + "Stck.");
    }

    public void SetFuelAmount(int amount)
    {
        uiFuel.SetText(amount + "l");
    }
}
