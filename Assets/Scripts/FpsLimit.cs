using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimit : MonoBehaviour
{

    public int frameRateCap = 60;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = frameRateCap;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.targetFrameRate != frameRateCap) Application.targetFrameRate = frameRateCap;
    }
}
