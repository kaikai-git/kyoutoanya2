using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] AudioSource footstepSound;
    float x, z;
    float speed = 0.1f;
    bool IsPause;
    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 2.5f, Ysensityvity = 0.3f;
    float RotateSpeed = 170f;
    bool cursorLock = true;

    float minX = -90f, maxX = 90f;
    bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        RotatePlayer();
        UpdateCursorLock();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        pause();
    }

    void RotatePlayer()
    {
        float rotationAmount = Input.GetAxisRaw("Horizontal") * RotateSpeed * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationAmount);
        characterRot *= deltaRotation;
    }

    private void FixedUpdate()
    {
        z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        if (z != 0)
        {
            Vector3 moveDirection = transform.forward * z;
            moveDirection.y = 0f;
            moveDirection = moveDirection.normalized;

            transform.position += moveDirection * speed;

            if (isWalking && !footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }

    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    public void pause()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPause == false)
        {
            IsPause = true;
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && IsPause == true)
        {
            IsPause = false;
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
    }
}
