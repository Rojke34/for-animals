using UnityEngine;

public class ObjectGeneratorActionMove : MonoBehaviour {
	public Transform farEnd;
	private Vector3 frometh;
	private Vector3 untoeth;
	private float secondsForOneLength = 20f;

	// Use this for initialization
	void Start () {
		frometh = transform.position;
		untoeth = farEnd.position;
	}
	
	void Update() {
		var t = Mathf.SmoothStep (0f, 1f, Mathf.PingPong (Time.time / secondsForOneLength, 1f));

		transform.position = Vector3.Lerp (frometh, untoeth, t);
	}
}
