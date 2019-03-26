using UnityEngine;
public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras = new Camera[4];
    public bool changeAudioListener = true;
    public GameObject radar;

    private void Start()
    {
        EnableCamera(cameras[0], false);
        EnableCamera(cameras[1], false);
        EnableCamera(cameras[2], false);
        EnableCamera(cameras[3], true);
    }
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            if (!radar.activeSelf)
                radar.SetActive(true);
            else
                radar.SetActive(false);
        }

        if (Input.GetKeyDown("1"))
        {
            if (cameras[0].enabled == true)
            {
                EnableCamera(cameras[0], false);
            }
            else
            {
                EnableCamera(cameras[0], true);
            }
        }
        if (Input.GetKeyDown("2"))
        {
            if (cameras[1].enabled == true)
            {
                EnableCamera(cameras[1], false);
            }
            else
            {
                EnableCamera(cameras[1], true);
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if(cameras[2].enabled ==true)
            {
                EnableCamera(cameras[2], false);
            }
            else
            {
                EnableCamera(cameras[2], true);
            }
            
        }
        if (Input.GetKeyDown("m"))
        {
            if (cameras[3].enabled == true)
            {
                EnableCamera(cameras[3], false);
            }
            else
            {
                EnableCamera(cameras[3], true);
            }

        }
    }
    private void EnableCamera(Camera cam, bool
    enabledStatus)
    {
        cam.enabled = enabledStatus;
        if (changeAudioListener)
            cam.GetComponent<AudioListener>().enabled =
            enabledStatus;
    }
}