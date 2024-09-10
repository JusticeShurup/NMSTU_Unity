using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public struct VectorXYZ
    {
        public VectorXYZ(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
       
        public float Length => Mathf.Sqrt(Mathf.Pow(X, 2) + Mathf.Pow(Y, 2) + Mathf.Pow(Z, 2));

        public VectorXYZ Normalized => new VectorXYZ(X / Length, Y / Length, Z / Length);

        public float Dot(VectorXYZ other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        public VectorXYZ Cross(VectorXYZ other)
        {
            return new VectorXYZ(Y * other.Z - Z * other.Y, -(X * other.Z - Z * other.X), X * other.Y - Y * other.X);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

    }

    void Start()
    {
        var vector1 = new VectorXYZ(1, 2, 3);
        var vector2 = new VectorXYZ(3, 4, 5);

        var vector1U = new Vector3(1, 2, 3);
        var vector2U = new Vector3(3, 4, 5);

        Debug.Log(vector1.Length);
        Debug.Log(vector1.Normalized);
        Debug.Log(vector1.Dot(vector2));
        Debug.Log(vector1.Cross(vector2));

        Debug.Log(vector1U.normalized);
        Debug.Log(Vector3.Dot(vector1U, vector2U));
        Debug.Log(Vector3.Cross(vector1U, vector2U));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
