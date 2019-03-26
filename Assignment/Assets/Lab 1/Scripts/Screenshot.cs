using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour {
    DirectoryInfo dir = new DirectoryInfo("Captured");
    

  

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown("c"))
        {
            ScreenCapture.CaptureScreenshot("Captured/" + (dir.GetFiles().Length + 1)+".png");
            
        }

    }
}
