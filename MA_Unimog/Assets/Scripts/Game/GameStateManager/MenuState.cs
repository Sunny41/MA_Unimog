using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : GameState {

    public MenuState(Game manager, IngameMenu ingameMenu) : base(manager)
    {
        ingameMenu.ShowIngameMenu();
    }

    public override void Update()
    {
    }
}
