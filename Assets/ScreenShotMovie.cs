using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotMovie : MonoBehaviour
{
    // The folder we place all screenshots inside
    public string folder = "ScreenShotMovieOutput";
    public int frameRate = 25;
    public int sizeMultiplier = 1;

    private string realFolder = "";

    // Use this for initialization
    void Start()
    {
        // Set the playback framerate
        Time.captureFramerate = frameRate;

        // Find a folder that doesn't exist yet by appending numbers
        realFolder = folder;
        int count = 1;
        while (System.IO.Directory.Exists(realFolder))
        {
            realFolder = folder + count;
            count++;
        }
        // Create the folder
        System.IO.Directory.CreateDirectory(realFolder);
    }

    // Update is called once per frame
    void Update()
    {
        // name is "realFolder/shot 0005.png"
        var name = string.Format("{0}/shot{1:D04}.png", realFolder, Time.frameCount);

        // Capture the screenshot
        Application.CaptureScreenshot(name, sizeMultiplier);
    }
}
