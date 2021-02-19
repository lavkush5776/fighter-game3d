using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private float x_Death = -90f;
    private float death_Smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerDied;

    public bool isPlayer;

    [SerializeField]
    private Image health_UI;
   
    [HideInInspector]
    public bool shieldActivated;

    private CharacterSoundFX soundFX;
     
     void Awake(){
         soundFX = GetComponentInChildren<CharacterSoundFX>();
     }

    void Update() {

        if(playerDied){
            RotateAfterDeath();
        }
    }



    public void ApplyDamage(float damage)
    {
      if(shieldActivated){
          return;
      }
      
       health -= damage;

        if(health_UI != null){
            health_UI.fillAmount = health /100f;
        }

       if(health <= 0){
           
           GetComponent<Animator>().enabled = false;

           StartCoroutine(AllowRotate());

           if(isPlayer){
               GetComponent<PlayerMove>().enabled = false;
               GetComponent<PlayerAttackInput>().enabled = false;
                 
                 // the player is not tha parent game object
                 //for the camera anymore

               Camera.main.transform.SetParent(null);
               GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false;


           }else
           {
               GetComponent<EnemyController>().enabled = false;
               GetComponent<NavMeshAgent>().enabled = false;
           }
          
    }
    }
    void RotateAfterDeath(){

        transform.eulerAngles = new Vector3(Mathf.Lerp(transform.eulerAngles.x,
         x_Death, Time.deltaTime * death_Smooth),
        transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator AllowRotate(){
        playerDied = true;
        yield return new WaitForSeconds(rotate_Time);
        playerDied = false;
    }

   
}
