using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
	GameData gameData;
	const float secondsInDay = 86400f;
	
	[SerializeField] Color nightLightColor;
	[SerializeField] Color dayLightColor = Color.white;
	[SerializeField] AnimationCurve nightTimeCurve;

	[SerializeField] Text text;
	[SerializeField] Light2D globalLight;

	float time = 25200;
	float Hours { get { return time / 3600f; } }
	float Minutes { get { return time % 3600f / 60f; } }
	[SerializeField] float timeScale = 100f;
	
	private int days;
    private void Start()
    {
        time = gameData.time;
		days = gameData.days;
    }
    private void Update() 
	{
		time += Time.deltaTime * timeScale;
		int hh = (int)Hours;
		int mm = (int)Minutes;
		text.text = hh.ToString("00") + ":" + mm.ToString("00") + "\nDay " + days;
		float v = nightTimeCurve.Evaluate(Hours);
		Color c = Color.Lerp(dayLightColor, nightLightColor, v);
		globalLight.color = c;
		if (time > secondsInDay) { NextDay(); }
	}
	private void NextDay() 
	{
		time = 0;
		days += 1;
	}
}
