using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{
    
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip attack_Sound_1, attack_Sound_2, die_Sound; 


    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
        
    }
     
     public void Attack_1(){
         soundFX.clip = attack_Sound_1;
         soundFX.Play();
     }
    
        public void Attack_2(){
         soundFX.clip = attack_Sound_2;
         soundFX.Play();
     }

     public void Die(){
         soundFX.clip = die_Sound;
         soundFX.Play();
     }
    
}
