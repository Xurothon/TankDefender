using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
	private const string _defaultPrefix = "FPS: ";

	[Header ("Сколько раз в секунду обновлять?")]
	[SerializeField, Range (1.0f, 10.0f)] private float updateRate = 1.0f;

	[Header ("Что написать перед числом?")]
	[SerializeField] private string counterPrefix;

	// >>> ======================================= >>>

	private Text FPSCounter_Text;
	private bool counterTextWasFound = false;

	private int frameCount;
	private float frameDelta;
	private float fps;

	private void Awake ()
	{
		TryFindFPSCounterText ();
	}

	private void TryFindFPSCounterText ()
	{
		if (GetComponent<Text> ())
			FPSCounter_Text = GetComponent<Text> ();
		else if (GetComponentInParent<Text> ())
			FPSCounter_Text = GetComponentInParent<Text> ();
		else
		{
			Debug.Log ("Компонент <Text> не найден!");
			return;
		}

		if (counterPrefix == "")
			counterPrefix = _defaultPrefix;

		counterTextWasFound = true;
	}

	private void Update ()
	{
		if (counterTextWasFound)
		{
			frameCount++;
			frameDelta += Time.deltaTime;
			if (frameDelta > 1.0f / updateRate)
			{
				fps = frameCount / frameDelta;
				frameCount = 0;
				frameDelta -= 1.0f / updateRate;

				FPSCounter_Text.text = counterPrefix + (int) fps;
			}
		}
	}
}