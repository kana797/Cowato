
[System.Serializable]
public class WeatherData
{
    public Location location;
    public Current current;
}

[System.Serializable]
public class Location
{
    public string name;
    public string region;
    public string country;
}

[System.Serializable]
public class Current
{
    public float temp_c;
    public Condition condition;
    public float wind_kph;
    public int humidity;
    public float feelslike_c;
}

[System.Serializable]
public class Condition
{
    public string text;
    public string icon;
}