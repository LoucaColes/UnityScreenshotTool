using UnityEngine;

/// <summary>
/// Rotates a cube
/// </summary>
public class CubeMovement : MonoBehaviour {

    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Vector3 rotationAxis;
	
	// Update is called once per frame
	void Update () {
        // Calculate new rotation value
        Vector3 newRotation = transform.rotation.eulerAngles + (rotationAxis * rotateSpeed * Time.deltaTime);

        // Update the transform rotation
        transform.rotation = Quaternion.Euler(newRotation);
	}
}
