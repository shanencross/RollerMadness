using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;

	private float time = 0;
	private bool ticking = true;

	//number of seconds in a minute;
	//should be 60f, but can be modified for testing purposes
	const float secondsPerMinute = 60f;
	//fraction of second to be displayed; 
	//e.g. 10f yields tenths-of-second, 100f yields hundredths-of-second, etc.
	const float fractionOfSecond = 10f;

	//is the timer ticking now?
	public bool isTicking() {
		return ticking;
	}

	//Start the timer over from 0 and begin ticking
	public void startTicking() {
		time = 0;
		resumeTicking ();
	}

	//Resume ticking from value last left off at
	public void resumeTicking() {
		ticking = true;
	}

	//Stop timer from ticking
	public void stopTicking() {
		ticking = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if timer is ticking...
		if (ticking) {
			//increment timer each frame
			time += Time.deltaTime;

			//calculate minute, second, and tenths-of-second values
			int minutes = Mathf.FloorToInt (time / secondsPerMinute);
			int seconds = Mathf.FloorToInt (time - (minutes * secondsPerMinute));
			int tenthsOfSecond = Mathf.FloorToInt ((time - (minutes * secondsPerMinute) - seconds) * fractionOfSecond);

			//format time string as "00:00.0" with minutes, seconds, and tenths-of-second in that order
			string niceTime = string.Format ("{0:00}:{1:00}.{2:0}", minutes, seconds, tenthsOfSecond);
			//update timer text with formatted time
			timerText.text = niceTime;
		}
	}
}
