using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColoreQuestGard : Quest
{
    public Quest QuestFinished;
    
    public override void BeginQuest()
    {
        Debug.Log("quest started !");
        questManager.Remove(QuestFinished);
        questManager.Add(this);
        //questDescription = "1/1";
        //questManager.Refresh(this);
    }
}