
public class MenuState : GameState {

    public MenuState(Game manager) : base(manager)
    {
        EventListener.TriggerEvent("DisablePlayerInputEvent");
    }

    public override void Update()
    {
    }
}
