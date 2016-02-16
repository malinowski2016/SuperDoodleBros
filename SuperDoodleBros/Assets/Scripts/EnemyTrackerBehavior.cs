using UnityEngine;
using System.Collections;

public class EnemyTrackerBehavior : MonoBehaviour {

    private GameObject target;
    private Transform targetTrans;
    public int MoveSpeed = 4;
 	public int MaxDist = 10;
 	public int MinDist = 5;

    public int attackDmg = 10;
    PlayerHealth playerHealth;
 
 
	void Start (){
        target = GameObject.FindWithTag("Player");
        targetTrans = target.transform;
        playerHealth = target.GetComponent<PlayerHealth>();
    }
 
 	void Update (){
    	transform.LookAt(targetTrans);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        /*if(Vector3.Distance(transform.position,target.position) >= MinDist){
     
        	transform.position += transform.forward*MoveSpeed*Time.deltaTime;
 
          	if(Vector3.Distance(transform.position,target.position) <= MaxDist){
                //Here Call any function U want Like Shoot at here or something
    	  	}
    	}
        */
    }

	/*
    void OnCollisionEnter2D(Collider2D other)   //*******TURNED COLLIDER OFF RN B/C PLATFORMS GET IN THE WAY*********
    {
        // If the entering collider is the player...
        if (other.gameObject == target)
        {
            if (playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(attackDmg);
            }
        }
    }
    */


    void OnCollisionExit(Collider2D other)
    {
        // If the exiting collider is the player...
        //if (other.gameObject == target) { }
    }
}
