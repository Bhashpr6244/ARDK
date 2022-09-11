using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        Setplayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Setplayer()
    {

      trigger.Instance.OnFocused(transform);

    }


}
