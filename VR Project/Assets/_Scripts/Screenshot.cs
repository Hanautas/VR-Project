using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public string currentDirectory = "D:/GitHub/Screenshots";

    [ContextMenu("Create Screenshot")]
    public void CreateScreenshot()
    {
        ScreenCapture.CaptureScreenshot($"{currentDirectory}/Screenshot.jpg", 1);

        Debug.Log("Screenshot created");
    }
}