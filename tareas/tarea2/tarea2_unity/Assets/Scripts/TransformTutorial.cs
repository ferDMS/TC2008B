using UnityEngine;

public class TransformTutorial : MonoBehaviour
{
	// Example values for translation (tx, ty, tz)
	public float tx = 1.0f;
	public float ty = 2.0f;
	public float tz = 3.0f;

	// Example rotation matrix elements (3x3 part)
	// This example uses a simple rotation around the Y-axis
	public float r00 = 1;
	public float r01 = 0;
	public float r02 = 0;
	public float r10 = 0;
	public float r11 = 1;
	public float r12 = 0;
	public float r20 = 0;
	public float r21 = 0;
	public float r22 = 1;

	Matrix4x4 transformationMatrix;
	
	void Start()
	{
		transformationMatrix = new Matrix4x4();

	}

	void Update ()
	{
		// Setting the rotation part of the matrix (3x3)
		transformationMatrix[0, 0] = r00;
		transformationMatrix[0, 1] = r01;
		transformationMatrix[0, 2] = r02;
		transformationMatrix[1, 0] = r10;
		transformationMatrix[1, 1] = r11;
		transformationMatrix[1, 2] = r12;
		transformationMatrix[2, 0] = r20;
		transformationMatrix[2, 1] = r21;
		transformationMatrix[2, 2] = r22;

		// Setting the translation part of the matrix
		transformationMatrix[0, 3] = tx;
		transformationMatrix[1, 3] = ty;
		transformationMatrix[2, 3] = tz;

		// The bottom row should be (0, 0, 0, 1) for a valid transformation matrix
		transformationMatrix[3, 0] = 0;
		transformationMatrix[3, 1] = 0;
		transformationMatrix[3, 2] = 0;
		transformationMatrix[3, 3] = 1;
		
		// Log the transformation matrix
        LogMatrix(transformationMatrix);
		
		//Apply the transformation matrix
		ApplyMatrixToTransform(transformationMatrix, transform);
	}
	
	void ApplyMatrixToTransform(Matrix4x4 matrix, Transform transform)
	{
		// Extract translation
		Vector3 position = matrix.GetColumn(3);

		// Extract rotation
		Quaternion rotation = Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));

		// Extract scale
		Vector3 scale = new Vector3(
			matrix.GetColumn(0).magnitude,
			matrix.GetColumn(1).magnitude,
			matrix.GetColumn(2).magnitude
		);

		// Apply the extracted values to the transform
		transform.position = position;
		transform.rotation = rotation;
		transform.localScale = scale;
	}
	
	void LogMatrix(Matrix4x4 matrix)
    {
		Debug.Log("----");
        for (int row = 0; row < 4; row++)
        {
            string rowText = string.Format(
                "{0:F4} , {1:F4} , {2:F4} , {3:F4}",
                matrix[row, 0], matrix[row, 1], matrix[row, 2], matrix[row, 3]
            );
            Debug.Log("[ " + rowText + " ]");
        }
    }
}