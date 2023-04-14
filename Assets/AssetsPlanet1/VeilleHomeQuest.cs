using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeilleHomeQuest : Quest
{
    public override void BeginQuest()
    {
        Debug.Log("quest started !");
        questManager.Add(this);

        //questDescription = "1/1";
        //questManager.Refresh(this);
    }
}
