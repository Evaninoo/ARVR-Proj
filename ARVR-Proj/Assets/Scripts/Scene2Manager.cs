using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Scene2Manager : MonoBehaviour
{
    public ARRaycastManager RaycastManager;
    public TrackableType TypeToTrack = TrackableType.PlaneWithinBounds;
    public GameObject PrefabToInstantiate;
    

    public PlayerInput PlayerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;
    private InputAction touchPhaseAction;
    private TMP_Text countText;
    private int cubeCount;
    private List<GameObject> instantiatedCubes;
   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instantiatedCubes = new List<GameObject>();
        touchPressAction = PlayerInput.actions["TouchPress"];
        touchPosAction = PlayerInput.actions["TouchPos"];
        touchPhaseAction = PlayerInput.actions["TouchPhase"];
        cubeCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (touchPressAction.WasPerformedThisFrame())
        {
            OnTouch();
        }
    }

    private void OnTouch()
    {
        var touchPos = touchPosAction.ReadValue<Vector2>();

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(touchPos, hits, TypeToTrack);

        


        if (hits.Count > 0)
        {
            ARRaycastHit firstHit = hits[0];
            Instantiate(PrefabToInstantiate, firstHit.pose.position, firstHit.pose.rotation);

            GameObject cube = Instantiate(PrefabToInstantiate, firstHit.pose.position, firstHit.pose.rotation);
            instantiatedCubes.Add(cube);
            cubeCount += 1;
            countText.text = "Cubes: " + cubeCount;
        }

        if (touchPressAction.WasPerformedThisFrame())
        {
            var touchPhase = touchPhaseAction.ReadValue<UnityEngine.InputSystem.TouchPhase>();
            if (touchPhase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                OnTouch();
            }
        }

    }
}