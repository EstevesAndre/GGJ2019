using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    [Header("Day Settings")]

    [SerializeField] private float _targetDayLenght = 0.5f
        ; //lenght of the day in minutes
    public float targetDayLenght
    {
        get
        {
            return _targetDayLenght;
        }
    }

    [SerializeField] [Range(0f, 1f)] private float _timeOfDay;
    public float timeOfDay
    {
        get
        {
            return _timeOfDay;
        }
    }

    [SerializeField] private int _dayNumber;
    public int dayNumber
    {
        get
        {
            return _dayNumber;
        }
    }

    private float _timeScale = 100f;

    public bool pause = false;

    [Header("Sun Light")]

    [SerializeField] private Transform dailyRotation;


    [SerializeField] private Light sun;

    private float intensity;

    [SerializeField] private float sunBaseIntensity = 1f;
    [SerializeField] private float sunVariation = 1.5f;

    [SerializeField] private Gradient sunColor;


    [Header("Modules")]

    private List<DNModuleBase> moduleList = new List<DNModuleBase>();

    void Update()
    {
        if (!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }

        AdjustSunRotation(); 
        SunIntensity();
        AdjustSunColor();
        UpdateModules();
    }


    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_targetDayLenght / 60);
    }

    private void UpdateTime()
    {
        _timeOfDay += Time.deltaTime * _timeScale / 86400; //second in a day
        if(_timeOfDay > 1) //new day
        {
            _timeOfDay -= 1;
            _dayNumber++;
        }
    }

    private void AdjustSunRotation()
    {
        float sunAngle = timeOfDay * 360;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }

    private void SunIntensity()
    {
        intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        sun.intensity = intensity * sunVariation + sunBaseIntensity;
    }

    private void AdjustSunColor()
    {
        sun.color = sunColor.Evaluate(intensity);
    }

    public void AddModule(DNModuleBase module)
    {
        moduleList.Add(module);
    }

    public void RemoveModule(DNModuleBase module)
    {
        moduleList.Remove(module);
    }

    private void UpdateModules()
    {
        foreach (DNModuleBase module in moduleList)
        {
            module.UpdateModule(intensity);
        }
    }
}
