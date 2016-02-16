using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPlayerHealth : MonoBehaviour {

    public GameObject player;
    public Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = player.GetComponent<PlayerHealth>().currentHealth;
	}
}
