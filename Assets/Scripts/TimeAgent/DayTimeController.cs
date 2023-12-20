using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour, IDataPersistence
{
	const float secondsInDay = 86400f;
	const float phaseLenght = 300f;

	[SerializeField] Color nightLightColor;
	[SerializeField] Color dayLightColor = Color.white;
	[SerializeField] AnimationCurve nightTimeCurve;

	[SerializeField] Text text;
	[SerializeField] Light2D globalLight;

	List<TimeAgent> agents;

	[SerializeField] float timeScale = 100f;
	[SerializeField] float startAtTime = 25200f;
	public float time = 0;
	public int days;
	int oldPhase = 0;

	float Hours { get { return time / 3600f; } }
	float Minutes { get { return time % 3600f / 60f; } }

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }
    private void Start()
    {
		time = startAtTime;
    }
    private void Update()
    {
        time += Time.deltaTime * timeScale;
        TimeValueCalculation();
        DayLight();
        if (time > secondsInDay) { NextDay(); }

        TimeAgents();
    }
    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
    }

    private void TimeAgents()
    {
		int currentPhase = (int)(time / phaseLenght);
		if (oldPhase != currentPhase)
		{ 
			oldPhase = currentPhase;
			for (int i = 0; i < agents.Count; i++)
			{
				agents[i].Invoke();
			}
		}
    }

    private void TimeValueCalculation()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00") + "\nDay " + days;
    }

    public void Subcribe(TimeAgent timeAgent)
	{
		agents.Add(timeAgent);
	}
	public void Unsubcribe(TimeAgent timeAgent)
	{
		agents.Remove(timeAgent);
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
