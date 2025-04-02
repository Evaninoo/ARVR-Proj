using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public GameObject ParticleEffect;
    private Vector2 touchPos;
    private RaycastHit hit;
    private Camera cam;

    private InputAction touchPhaseAction;
    public PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;

    //

    public PlayerInput PlayerInput;
    private TMP_Text countText;
    private int cubeCount;
    private List<GameObject> instantiatedCubes;

    public ARRaycastManager RaycastManager;
    public TrackableType TypeToTrack = TrackableType.PlaneWithinBounds;
    public GameObject PrefabToInstantiate;


    void Start()
    {
        cam = GetComponent<Camera>();

        touchPressAction = playerInput.actions["TouchPress"];
        touchPosAction = playerInput.actions["TouchPos"];
        touchPhaseAction = PlayerInput.actions["TouchPhase"];
        cubeCount = 0;
    }

    void Update()
    {
        if (!touchPressAction.WasPerformedThisFrame())
        {
            return;
        }

        touchPos = touchPosAction.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(touchPos);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.tag == "Enemy")
            {
                var clone = Instantiate(ParticleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);


                GameObject cube = Instantiate(PrefabToInstantiate, hitObj.transform.position, hitObj.transform.rotation);
                instantiatedCubes.Add(cube);
                cubeCount += 1;
                countText.text = "Cubes: " + cubeCount;

            }
        }

    }
}