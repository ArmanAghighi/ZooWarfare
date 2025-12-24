using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;


public class PlayerService : MonoBehaviour
{
    public int CurrentStageIndex;

    async void Awake()
    {
        try
        {
            await GetPlayerData("https://armanitproject.ir/Arman/PlayerData.json");
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    public async Task GetPlayerData(string url)
    {
        using var request = UnityWebRequest.Get(url);
        var op = request.SendWebRequest();

        while (!op.isDone)
            await Task.Yield();

        if (request.result != UnityWebRequest.Result.Success)
            throw new System.Exception(request.error);

        var json = request.downloadHandler.text;
        var data = JsonUtility.FromJson<PlayerData>(json);

        // modify data
        data.Name = "Arman";
        data.Score = 10;

        CurrentStageIndex = data.CurrentStageIndex;

        Debug.Log($"Name is: {data.Name} Score is: {data.Score}");

        // serialize UPDATED data
        string updatedJson = JsonUtility.ToJson(data);

        await PostJsonAsync(url, updatedJson);
    }

    public async Task<string> PostJsonAsync(string url, string json)
    {
        using var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", json);

        var op = request.SendWebRequest();
        while (!op.isDone)
            await Task.Yield();

        if (request.result != UnityWebRequest.Result.Success)
            throw new System.Exception(request.error);

        return request.downloadHandler.text;
    }
}
[System.Serializable]
public class PlayerData
{
    public string Name;
    public int Score;
    public int CurrentStageIndex;
}