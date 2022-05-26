using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    [SerializeField] private float regOrthoSize;
    [SerializeField] private float regXDamping;
    [SerializeField] private float regYDamping;
    [SerializeField] private float mazeOrthoSize;
    [SerializeField] private float mazeXDamping;
    [SerializeField] private float mazeYDamping;
    [SerializeField] private float zoomSpeed;

    public float getRegOrthoSize() { return regOrthoSize; }
    public float getMazeOrthoSize() { return mazeOrthoSize; }
    public float getRegXDamping() { return regXDamping; }
    public float getRegYDamping() { return regYDamping; }
    public float getMazeXDamping() { return mazeXDamping; }
    public float getMazeYDamping() { return mazeYDamping; }

    public float getZoomSpeed() { return zoomSpeed; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
