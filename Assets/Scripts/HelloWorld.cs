using UnityEngine;
using System.Collections.Generic;

public class HelloWorld : MonoBehaviour
{
    // Material to apply to the cubes
    public Material cubeMaterial;
    
    // List to keep track of all instantiated cubes
    private List<GameObject> cubes = new List<GameObject>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateSmileyFace();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the entire smiley face for a fun effect
        transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
    
    // Creates a 3D smiley face made of cubes
    void CreateSmileyFace()
    {
        // Create the face (center cube)
        GameObject faceCube = CreateCube(Vector3.zero, new Vector3(5, 5, 0.5f), Color.yellow);
        
        // Create left eye
        CreateCube(new Vector3(-1.5f, 1, 0.5f), Vector3.one * 0.8f, Color.black);
        
        // Create right eye
        CreateCube(new Vector3(1.5f, 1, 0.5f), Vector3.one * 0.8f, Color.black);
        
        // Create nose
        CreateCube(new Vector3(0, 0, 0.5f), new Vector3(0.5f, 0.8f, 0.5f), Color.black);
        
        // Create smile (a curved line of cubes)
        int smileCubeCount = 7;
        for (int i = 0; i < smileCubeCount; i++)
        {
            // Calculate position along a curve
            float t = i / (float)(smileCubeCount - 1); // Normalized position (0 to 1)
            float x = Mathf.Lerp(-2, 2, t);
            
            // Use a parabola (y = ax²) for the smile curve
            // Shifted and scaled to create a proper upward curve (smile)
            float y = 3f * (t - 0.5f) * (t - 0.5f) + -1.2f;
            
            CreateCube(new Vector3(x, y, 0.5f), new Vector3(0.4f, 0.4f, 0.4f), Color.black);
        }
    }
    
    // Creates a cube at the specified position with the given scale and color
    GameObject CreateCube(Vector3 position, Vector3 scale, Color color)
    {
        // Create a cube GameObject
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // Set the cube's parent to this GameObject
        cube.transform.parent = transform;
        
        // Set position and scale
        cube.transform.localPosition = position;
        cube.transform.localScale = scale;
        
        // Set the cube's color
        Renderer renderer = cube.GetComponent<Renderer>();
        if (cubeMaterial != null)
        {
            // Use the assigned material if available
            renderer.material = new Material(cubeMaterial);
            renderer.material.color = color;
        }
        else
        {
            // Create a new material with the specified color
            renderer.material.color = color;
        }
        
        // Add the cube to our list
        cubes.Add(cube);
        
        return cube;
    }
}
