using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float mainCameraCharacterOffset;
    [SerializeField] private float rotationSpeed;

    private CharacterController characterController;

    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        characterController = GetComponent<CharacterController>();

        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y + mainCameraCharacterOffset, transform.position.z - mainCameraCharacterOffset);
    }

    // Update is called once per frame
    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        //���� ��� � Normilize()
        //var movement = Vector3.ClampMagnitude(new Vector3(horizontalInput, 0, verticalInput), 1);
        var movementDirection = new Vector3(horizontalInput, 0f, verticalInput);

        movementDirection.Normalize();
        movementDirection = movementDirection * speed * Time.deltaTime;
        //movementDirection = Vector3.ClampMagnitude(movementDirection, speed);

        RotatePlayer(movementDirection);
        MovePlayer(movementDirection);
        MoveMainCamera(movementDirection);



        //MovePlayer(movement);
        //RotatePlayerInDirectionOfMovement(movement);

        //if (movement != Vector3.zero)
        //{
        //    RotatePlayerInDirectionOfMovement(movement);
        //}
    }

    private void MovePlayer(Vector3 movementDirection)
    {

        //characterController.Move(transform.TransformDirection(movementDirection * speed * Time.deltaTime));        
        characterController.Move(movementDirection);
        //transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

          private void RotatePlayer(Vector3 movementDirection)
    {
        if (movementDirection == Vector3.zero) return;

        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        characterController.transform.rotation = Quaternion.RotateTowards(characterController.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
    private void MoveMainCamera(Vector3 movementDirection)
    {
        //var z = Mathf.Clamp(characterController.transform.position.z, 45.58f, 154f);
        //movementDirection.z = z;
        //movementDirection.Normalize();
        //154.2669
        //45.5799
          Debug.Log($"new X: {characterController.transform.position.x}");
        if (characterController.transform.position.z > 154f || characterController.transform.position.z < 45.58f)
        {
            movementDirection.z = 0f;
        }

        if (characterController.transform.position.x > 154f || characterController.transform.position.x < 45.58f)
        {
            movementDirection.x = 0f;
        }

        mainCamera.transform.Translate(movementDirection, Space.World);

        //mainCamera.transform.Translate(transform.TransformDirection(movement), Space.World);
    }
}
