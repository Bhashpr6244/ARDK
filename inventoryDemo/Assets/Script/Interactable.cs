using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static Interactable Instance;
    
    public float radius = 3f;
    public GameObject UIRockinventory;
    public Transform interactionTransform;
    bool isFocus = false;   
    Transform player;
    bool hasInteracted = false;


    void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        

    }

    
    void Update()
    {
        if (isFocus)    
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
          
            if (!hasInteracted && distance <= radius)
            {
                UIRockinventory.SetActive(true);
               
                hasInteracted = true;
               

            }
        }
    }

    public virtual void  OnFocused(Transform playerTransform)
    {
        isFocus = true;
        hasInteracted = false;
        player = playerTransform;

    }



}
