using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine;

// async Task<string> DownloadDataAsync(string url)
// {
//     using (UnityWebRequest request = UnityWebRequest.Get(url))
//     {
//         // Invia richiesta e aspetta
//         var operation = request.SendWebRequest();

//         // Aspetta completamento 
//         while (!operation.isDone)
//         {
//             await Task.Yield();
//         }

//         if (request.result == UnityWebRequest.Result.Success)
//         {
//             return request.downloadHandler.text;
//         }
//         else
//         {
//             Debug.LogError($"Error: {request.error}");
//         }
//     }
// }
