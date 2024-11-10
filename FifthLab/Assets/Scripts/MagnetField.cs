using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    private Mesh _sphereMesh;
    public float magnetFieldRadius;
    public float magnetFieldStrength;
    public bool isMagnetFieldWorking;


    private void Awake()
    {
        _sphereMesh = CreateSphere(magnetFieldRadius, 10, 10);
    }

    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Screw>() != null && isMagnetFieldWorking)
        {
            Vector3 step = (transform.position - other.transform.position).normalized * Time.deltaTime * 300;
            other.GetComponent<Rigidbody>().AddForce(step);
        }

    }

    private void OnRenderObject()
    {
        if (isMagnetFieldWorking) Graphics.DrawMeshNow(_sphereMesh, transform.localToWorldMatrix);
    }

    private Mesh CreateSphere(float radius, int longitude, int latitude)
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[(longitude + 1) * (latitude + 1)];
        int[] triangles = new int[longitude * latitude * 6];

        for (int lat = 0; lat <= latitude; lat++)
        {
            float theta = lat * Mathf.PI / latitude;
            float sinTheta = Mathf.Sin(theta);
            float cosTheta = Mathf.Cos(theta);

            for (int lon = 0; lon <= longitude; lon++)
            {
                float phi = lon * 2 * Mathf.PI / longitude;
                float sinPhi = Mathf.Sin(phi);
                float cosPhi = Mathf.Cos(phi);

                float x = cosPhi * sinTheta;
                float y = cosTheta;
                float z = sinPhi * sinTheta;

                vertices[lat * (longitude + 1) + lon] = new Vector3(x, y, z) * radius;
            }
        }

        int index = 0;
        for (int lat = 0; lat < latitude; lat++)
        {
            for (int lon = 0; lon < longitude; lon++)
            {
                int first = lat * (longitude + 1) + lon;
                int second = first + longitude + 1;

                triangles[index++] = first;
                triangles[index++] = second;
                triangles[index++] = first + 1;

                triangles[index++] = second;
                triangles[index++] = second + 1;
                triangles[index++] = first + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
