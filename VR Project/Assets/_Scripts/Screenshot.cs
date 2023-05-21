using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [ContextMenu("Create Screenshot")]
    public void CreateScreenshot()
    {
        string currentDirectory = "D:/GitHub/Screenshots";

        ScreenCapture.CaptureScreenshot($"{currentDirectory}/Screenshot.jpg", 1);

        Debug.Log("Screenshot created");
    }
}