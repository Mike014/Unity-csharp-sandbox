using UnityEngine;
using System.Runtime.InteropServices;

public class NativePlugin : MonoBehaviour
{
    // iOS plugin
    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void _ShowAlert(string message);
    #endif

    // Android Plugin
    #if UNITY_ANDROID
    [DllImport("MyAndroidPlugin")]
    private static extern void ShowAlert(string message);
    #endif

    // Windows plugin
    #if UNITY_STANDALONE_WIN
    [DllImport("MyWindowsPlugin")]
    private static extern void ShowAlert(string message);
#endif

    void Start()
    {
        #if UNITY_IOS
        _ShowAlert("Hello from iOS native code!");
        #elif UNITY_ANDROID || UNITY_STANDALONE_WIN
        ShowAlert("Hello from native code");
        #endif
    }
}