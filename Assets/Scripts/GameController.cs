
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public	Text		Label;

	public	GameObject	Player;
	public	GameObject	EnemyLight;
	public	GameObject	EnemyMedium;
	public	GameObject	EnemyHeavy;
	public	GameObject	Boss;

	public	float		StartDelay;
	public	float		WaveDelay;
	public	float		WaveDuration;



	void Awake() {

		Screen.SetResolution(600, 900, false);
	}

	void Start() {

		Instantiate(Player, new Vector3(0.0f, -3.5f, 0.0f), transform.rotation);

		StartCoroutine(GameFlow());
	}



	IEnumerator GameFlow() {

		yield return new WaitForSeconds(StartDelay);

		StartCoroutine(EnemyLightController.SpawnWave(EnemyLight, WaveDelay));
		yield return new WaitForSeconds(WaveDuration + WaveDelay);
		StartCoroutine(EnemyMediumController.SpawnWave(EnemyMedium, WaveDelay));
		yield return new WaitForSeconds(WaveDuration + WaveDelay);
		StartCoroutine(EnemyHeavyController.SpawnWave(EnemyHeavy, WaveDelay));
		yield return new WaitForSeconds(WaveDuration + WaveDelay);
		StartCoroutine(BossController.SpawnWave(Boss, WaveDelay));
	}

	public void Win() {

		StartCoroutine(Restart());
		Label.text = "You Win!";
	}

	public void Lose() {

		StartCoroutine(Restart());
		Label.text = "GAME OVER";
		GameObject.Find("Canvas/HPLabel").GetComponent<Text>().text = string.Empty;
	}

	private IEnumerator Restart() {

		yield return new WaitForSeconds(4.0f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
