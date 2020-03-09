using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class PlayerView : MonoBehaviour
{
	// Settings
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	public float frameCounter = 20;

	// Inner Active
	float rotationX = 0F;
	float rotationY = 0F;

	private List<float> rotArrayX = new List<float>();
	float rotAverageX = 0F;

	private List<float> rotArrayY = new List<float>();
	float rotAverageY = 0F;

	Quaternion originalRotation;

	// Component References
	public Camera cam;

	void Update()
	{
		// Horizontal View Rotation: Player's Main Body
		rotAverageX = 0f;

		rotationX += Input.GetAxis("Mouse X") * sensitivityX;

		rotArrayX.Add(rotationX);

		if (rotArrayX.Count >= frameCounter)
		{
			rotArrayX.RemoveAt(0);
		}
		for (int i = 0; i < rotArrayX.Count; i++)
		{
			rotAverageX += rotArrayX[i];
		}
		rotAverageX /= rotArrayX.Count;

		//rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);

		Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);
		transform.localRotation = originalRotation * xQuaternion;

		// Vertical View Rotation: Camera On Player
		rotAverageY = 0f;

		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		rotationY = ClampAngle(rotationY, minimumY, maximumY);		// Required to prevent the issue about vertical view rotation
		rotArrayY.Add(rotationY);

		if (rotArrayY.Count >= frameCounter)
		{
			rotArrayY.RemoveAt(0);
		}
		for (int j = 0; j < rotArrayY.Count; j++)
		{
			rotAverageY += rotArrayY[j];
		}
		rotAverageY /= rotArrayY.Count;

		rotAverageY = ClampAngle(rotAverageY, minimumY, maximumY);

		Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
		cam.transform.localRotation = originalRotation * yQuaternion;
	}

	void Start()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb)
			rb.freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		/*
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F))
		{
			if (angle < -360F)
			{
				angle += 360F;
			}
			if (angle > 360F)
			{
				angle -= 360F;
			}
		}
		*/
		return Mathf.Clamp(angle, min, max);
	}
}
