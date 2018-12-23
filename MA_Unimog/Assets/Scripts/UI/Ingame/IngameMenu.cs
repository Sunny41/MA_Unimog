using UnityEngine;
using UnityEngine.Events;

public class IngameMenu : MonoBehaviour {
    
    [SerializeField] private UIStatusElement timeTxt;
    [SerializeField] private UIStatusElement boxTxt;
    [SerializeField] private UIStatusElement fuelTxt;
    [SerializeField] private GameObject ingameMenuDisplay;

    private UnityAction openInventoryListener;
    private UnityAction closeInventoryListener;
    private UnityAction<int> boxAmountListener;
    private UnityAction<int> levelTimeListener;
    private UnityAction<float> fuelAmountListener;

    void Awake()
    {
        openInventoryListener = new UnityAction(ShowIngameMenu);
        closeInventoryListener = new UnityAction(HideIngameMenu);
        boxAmountListener = new UnityAction<int>(SetBoxAmount);
        levelTimeListener = new UnityAction<int>(SetTime);
        fuelAmountListener = new UnityAction<float>(SetFuel);

        EventListener.StartListening("OpenInventoryEvent", openInventoryListener);
        EventListener.StartListening("CloseInventoryEvent", closeInventoryListener);
        EventListener.StartListening("SetBoxAmountEvent", boxAmountListener);
        EventListener.StartListening("SetLevelTimeEvent", levelTimeListener);
        EventListener.StartListening("SetFuelAmountEvent", fuelAmountListener);
    }

    public void ShowIngameMenuEvent()
    {
        EventListener.TriggerEvent("OpenInventoryEvent");
    }

    public void HideIngameMenuEvent()
    {
        EventListener.TriggerEvent("CloseInventoryEvent");
    }

    private void ShowIngameMenu()
    {
        ingameMenuDisplay.SetActive(true);
    }

    private void HideIngameMenu()
    {
        ingameMenuDisplay.SetActive(false);
    }

    private void SetTime(int time)
    {
        timeTxt.SetText("" + time + "s");
    }

    private void SetBoxAmount(int amount)
    {
        boxTxt.SetText("" + amount);
    }

    private void SetFuel(float fuel)
    {
        fuelTxt.SetText("" + fuel + "l");
    }

    public void LoadMenuScene()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadMenuScene();
    }

    public void RestartLevel()
    {
        EventListener.TriggerEvent("RestartLevelEvent");
    }
}
