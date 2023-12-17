using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour, IDataPersistence
{
	const float secondsInDay = 86400f;
	
	[SerializeField] Color nightLightColor;
	[SerializeField] Color dayLightColor = Color.white;
	[SerializeField] AnimationCurve nightTimeCurve;

	[SerializeField] Text text;
	[SerializeField] Light2D globalLight;

	public float time = 25200;
	float Hours { get { return time / 3600f; } }
	float Minutes { get { return time % 3600f / 60f; } }
	[SerializeField] float timeScale = 100f;
	
	public int days;

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
	public void LoadData(GameData data)
	{
		time = data.time;
		days = data.days;
	}
	public void SaveData(ref GameData data)
	{
		data.time = time;
		data.days = days;
	}
}
