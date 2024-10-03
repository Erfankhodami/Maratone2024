using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 InitialPos;
    [SerializeField] private Vector3 FinalPos;

    float minX = 3.5f;
    float maxX = 17f;
    float minY = -14f;
    float maxY = -6.7f;

    private Camera MainCam;

    void Start()
    {
        MainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InitialPos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            FinalPos = MainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = FinalPos - InitialPos;
            MainCam.transform.position -= pos;

            Vector3 clampedPosition = MainCam.transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
            MainCam.transform.position = clampedPosition;
        }
    }
}

