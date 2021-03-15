using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float slowdownFactor = 0.05f;
	public float slowdownLenght = 5f;

	void Start() {
		//DoSlowmotion ();
	}

	void Update() {
		Time.timeScale += (1f / slowdownLenght) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp (Time.timeScale, 0f, 1f);
	}

	public void DoSlowmotion() {
        Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
