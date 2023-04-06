using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGeneratorAndOut : Interactable
{
    private MarchandQuest marchandQuest;

    // Start is called before the first frame update
    void Start()
    {
        marchandQuest = FindObjectOfType<MarchandQuest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        marchandQuest.ChangeObjective("Retourner au vaisseau");
        marchandQuest.ChangeName("Quitter la planète");
        GameObject.Find("scifi-pillar-light").GetComponent<MeshRenderer>().enabled = false;
        
        IsTerminated = true;
    }
}
