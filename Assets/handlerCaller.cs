using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerCaller : MonoBehaviour
{
    public MonoBehaviour Handler = null;
    
    public void Start()
    {
        Map map = Handler.GetComponent<Map>();
        map.OnSave(); // work if OnSave is public
        //Hero hero = Handler.GetComponent<Hero>();
        //hero.OnSave(); // work if OnSave is public

        //Handler.Invoke("OnSave", 0.0f); // work if OnSave is private. Invoke only one 
        //Handler.SendMessage("OnSave"); // work if OnSave is private. Invoke all methods "OnSave"
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
