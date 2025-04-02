using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class KillingCam : MonoBehaviour
{
    public Text countText;
    public int killCount = 0;
    private Camera cam;

    public GameObject ParticleEffect;
    public PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;

    void Start()
    {
        cam = GetComponent<Camera>();

        touchPressAction = playerInput.actions["TouchPress"];
        touchPosAction = playerInput.actions["TouchPos"];

        UpdateUI();
    }

    void Update()
    {
        if (!touchPressAction.WasPerformedThisFrame()) return;

        Vector2 touchPos = touchPosAction.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(touchPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObj = hit.collider.gameObject;

            if (hit.collider.CompareTag("Enemy"))
            {
                var clone = Instantiate(ParticleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(clone, 3f);
                Destroy(hitObj);


                killCount++;
                UpdateUI();
            }
        }
    }

    void UpdateUI()
    {
        if (countText != null)
        {
            countText.text = "Killed : " + killCount;
        }
    }
}