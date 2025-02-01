using System;

[System.Serializable]
public class WeatherData
{
    public MainData main;
    public Weather[] weather;
}

[System.Serializable]
public class MainData
{
    public float temp;
    public float feels_like;
    public float temp_min;
    public float temp_max;
    public int humidity;
}

[System.Serializable]
public class Weather
{
    public string main; // e.g., "Rain", "Clear", "Clouds"
    public string description;
}