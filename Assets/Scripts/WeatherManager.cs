using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WeatherManager : MonoBehaviour
{
    public GameObject displayBar; // Assign in Inspector
    private TMP_Text buttonText; // Use TMP_Text instead of Text
    private bool isVisible;

    private string accessKey = "ef467c09ab7dc6aaa58a2335e71c9a10";
    private string city = "Montreal"; // Replace with your desired city
    private string apiUrl = "https://api.weatherstack.com/current";

    public WeatherData weatherData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Weathering()
    {
        StartCoroutine(GetWeatherData());
        string temp = "Temperature: " + weatherData.current.temperature + "°C";
        string humi = "Humidity: " + weatherData.current.humidity + "%";
        string feelslike = "Feels Like: " + weatherData.current.feelslike + "°C";
        buttonText = displayBar.GetComponentInChildren<TMP_Text>();
        buttonText.text = "I got you! Here is the weather at Montreal Now" + temp + "\n" + feelslike + "\n" + humi;
        isVisible = !isVisible;
        displayBar.SetActive(isVisible); 
    }
    IEnumerator GetWeatherData()
    {
        string url = $"{apiUrl}?access_key={accessKey}&query={city}";
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error fetching weather data: " + request.error);
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            Debug.Log("Raw JSON Response: " + jsonResponse); // Print the raw JSON response

            weatherData = JsonUtility.FromJson<WeatherData>(jsonResponse);

            if (weatherData != null && weatherData.current != null)
            {
                Debug.Log("Weather Description: " + weatherData.current.weather_descriptions[0]);
                Debug.Log("Temperature: " + weatherData.current.temperature + "°C");
                Debug.Log("Feels Like: " + weatherData.current.feelslike + "°C");
                Debug.Log("Humidity: " + weatherData.current.humidity + "%");
                Debug.Log("Wind Speed: " + weatherData.current.wind_speed + " km/h");
            }
            else
            {
                Debug.LogError("Failed to parse JSON response.");
            }
        }

    }

    // Classes to match the Weatherstack JSON response
[System.Serializable]
public class WeatherData
{
    public CurrentWeather current;
    public Location location;
}

[System.Serializable]
public class CurrentWeather
{
    public float temperature;
    public string[] weather_descriptions;
    public float feelslike;
    public int humidity;
    public float wind_speed;
}

[System.Serializable]
public class Location
{
    public string name;
}

}
