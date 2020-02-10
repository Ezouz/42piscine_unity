using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalController : MonoBehaviour
{
    // my instance
    public static generalController MGC; 

    // initialized in unity
    public GameObject[] cameras;
    public GameObject ball;
    public GameObject arrow;
    public GameObject pivot;

    // globales
    // camera state
    public int changeView = 1;
    public int cameraView = 0;
    public int cameraCount = 0;
    public bool gameInterface = false;
    public bool spacePressed = false;

    // play mode
    public bool ballIsOn = false;
    public bool isGaugeOn = false;
    public float force = 0;
    public bool ballIsRolling = false;
    private float t;

    void Awake()
    {
        if (MGC == null)
            MGC = this;
    }

    void Start()
    {
        cameras[0].SetActive(false);
        cameras[1].SetActive(true);
        cameraCount = Camera.allCamerasCount;
    }

    void Update()
    {
        if (cameraView != changeView)
           updateCameraView();
        switchCameraView();
    }

    // only if keyboard input L
    public void switchCameraView()
    {
        if (cameraView == 1) {
            if (Input.GetKey("e")) {
                changeTheView();
            }
        } else if (cameraView == 0) {
            if (Input.GetKey("space")) {
                if (Time.time - t >= 0.2f) {
                    t = Time.time;
                    spacePressed = true;
                    changeTheView();
                }
            }
        }
    }

    void changeTheView () {
        // set change to
        if (changeView <= cameraCount - 1)
            changeView++;
        else
            changeView = 0;
        // update the current camera we switched on
        cameraView = changeView;
        updateCameraView();
    }

    void updateCameraView()
    {
        for (var idx = 0; idx <= cameraCount; idx++)
        {
            if (idx == changeView)
            {
                cameras[idx].SetActive(true);
                cameraView = idx;
            }
            else if (idx <= cameraCount)
                cameras[idx].SetActive(false);
        }
    }

    public bool IsHit(string tag, int cam)
    {
        RaycastHit hit;
        Camera instance = cameras[cam].GetComponent<Camera>();
        Ray ray = instance.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))
            if (hit.transform.tag == tag)
                return true;
        return false;
    }

    // when camera 1 is activated and desactivated it calls this so this is play mode
    public void activateGaugeView(bool on)
    {
        pivot.transform.GetChild(0).gameObject.SetActive(on);
    }
    public void AlignView()
    {
        pivot.transform.LookAt(GameManager.GM.flag[GameManager.GM.currentTrou].transform.position);
    }
    public void activateGauge(bool on)
    {
        // isGaugeOn = !isGaugeOn;
        isGaugeOn = on;
        cameras[1].transform.GetChild(0).gameObject.SetActive(on);
    }

}
