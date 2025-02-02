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

    private string apiKey = "18dbcea2368b4d179ed01417250202";
    private string city = "Montreal"; 
    private string apiUrl = "https://api.weatherapi.com/v1/current.json";

    public WeatherData weatherData;

    public void Weathering()
    {
        StartCoroutine(GetWeatherData());
    }
    
    IEnumerator GetWeatherData()
    {
        string url = $"{apiUrl}?key={apiKey}&q={city}";
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
                Debug.Log("Weather: " + weatherData.current.condition.text);
                Debug.Log("Temperature: " + weatherData.current.temp_c + "°C");
                Debug.Log("Feels Like: " + weatherData.current.feelslike_c + "°C");
                Debug.Log("Humidity: " + weatherData.current.humidity + "%");
                Debug.Log("Wind Speed: " + weatherData.current.wind_kph + " km/h");

                UpdateUI();
            }
            else
            {
                Debug.LogError("Failed to parse JSON response.");
            }
        }

    }

    void UpdateUI(){
         string cond = "Condition: " + weatherData.current.condition.text;
        string temp = "Temperature: " + weatherData.current.temp_c + "°C";
        string humi = "Humidity: " + weatherData.current.humidity + "%";
        string feelslike = "Feels Like: " + weatherData.current.feelslike_c + "°C";
        buttonText = displayBar.GetComponentInChildren<TMP_Text>();
        buttonText.text = "I got you! Here is the weather at Montreal now (=` ω´=)\n\n" + cond + "\n" + temp + "\n" + feelslike + "\n" + humi;
        isVisible = !isVisible;
        displayBar.SetActive(isVisible);
    }

    // Classes to match the Weatherstack JSON response
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

}
