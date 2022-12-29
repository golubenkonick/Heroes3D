using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handlerCaller : MonoBehaviour
{
    public MonoBehaviour Handler = null;
    public void Start()
    {
        Handler.Invoke("OnSave", 0.0f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
