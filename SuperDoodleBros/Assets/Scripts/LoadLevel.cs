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

	public void loadStart() {
		SceneManager.LoadScene ("Start Screen");
	}

	public void loadDeath() {
		SceneManager.LoadScene ("Death Screen");
	}

	public void loadHS() {
		SceneManager.LoadScene ("Leaderboard");
	}
}
