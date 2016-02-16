using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start(){
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update(){
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
    }
}
