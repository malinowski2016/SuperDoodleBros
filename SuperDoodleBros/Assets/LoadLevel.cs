using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public void loadGame () {
		SceneManager.LoadScene ("Demo4");
	}

	public void loadDirections() {
		SceneManager.LoadScene ("Direction Screen");
	}
}
