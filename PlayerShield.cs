using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

     private HealthScript healthSript;
    
    void Awake()
    {
       healthSript = GetComponent<HealthScript>(); 
    }

    public void ActivateShield(bool shieldActive) {
        
        healthSript.shieldActivated = shieldActive;

    }
}
