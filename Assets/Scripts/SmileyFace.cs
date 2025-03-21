using UnityEngine;
using System.Collections.Generic;

public class SmileyFace : MonoBehaviour
{
    [Header("Face Properties")]
    public float faceScale = 1f;
    public Color faceColor = Color.yellow;

    [Header("Eye Properties")]
    public Color eyeColor = Color.black;

    [Header("Nose Properties")]
    public Color noseColor = Color.black;

    [Header("Mouth Properties")]
    public float smileAngle = 3f;
    public float smileHeight = -1.2f;
    public float smileWidth = 2f;
    public Color mouthColor = Color.black;

    public Material cubeMaterial;

    private GameObject faceCube;
    private List<GameObject> eyeCubes = new List<GameObject>();
    private GameObject noseCube;
    private List<GameObject> mouthCubes = new List<GameObject>();

    void Start()
    {
        CreateFace();
    }

    void Update()
    {
        //transform.Rotate(0, 10 * Time.deltaTime, 0); // Rotate the face

        UpdateFaceScale();
        UpdateColors();
        UpdateSmile();
    }

    void CreateFace()
    {
        // Face
        faceCube = CreateCube(Vector3.zero, new Vector3(5, 5, 0.5f), faceColor);

        // Eyes
        eyeCubes.Add(CreateCube(new Vector3(-1.5f, 1, 0.5f), Vector3.one * 0.8f, eyeColor));
        eyeCubes.Add(CreateCube(new Vector3(1.5f, 1, 0.5f), Vector3.one * 0.8f, eyeColor));

        // Nose
        noseCube = CreateCube(new Vector3(0, 0, 0.5f), new Vector3(0.5f, 0.8f, 0.5f), noseColor);

        // Mouth
        int smileCubeCount = 7;
        for (int i = 0; i < smileCubeCount; i++)
        {
            mouthCubes.Add(CreateCube(Vector3.zero, new Vector3(0.4f, 0.4f, 0.4f), mouthColor));
        }
    }

    void UpdateFaceScale()
    {
    float scaledFaceSize = 5f * faceScale;

    // Update face size
    faceCube.transform.localScale = new Vector3(scaledFaceSize, scaledFaceSize, 0.5f);

    // Define scaled values
    float eyeOffsetX = 1.5f * faceScale;
    float eyeOffsetY = 1f * faceScale;
    float eyeSize = 0.8f * faceScale;

    float noseSizeX = 0.5f * faceScale;
    float noseSizeY = 0.8f * faceScale;
    float noseOffsetY = -0.2f * faceScale;

    float smileCubeSize = 0.4f * faceScale;
    float smileWidthScaled = smileWidth * faceScale;
    float smileHeightScaled = smileHeight * faceScale;
    float smileAngleScaled = smileAngle * faceScale;

    // Update eye positions & size
    eyeCubes[0].transform.localPosition = new Vector3(-eyeOffsetX, eyeOffsetY, 0.5f);
    eyeCubes[1].transform.localPosition = new Vector3(eyeOffsetX, eyeOffsetY, 0.5f);
    eyeCubes[0].transform.localScale = Vector3.one * eyeSize;
    eyeCubes[1].transform.localScale = Vector3.one * eyeSize;

    // Update nose position & size
    noseCube.transform.localPosition = new Vector3(0, noseOffsetY, 0.5f);
    noseCube.transform.localScale = new Vector3(noseSizeX, noseSizeY, 0.5f);

    // Update smile/mouth position & size
    int smileCubeCount = mouthCubes.Count;
    for (int i = 0; i < smileCubeCount; i++)
    {
        float t = i / (float)(smileCubeCount - 1); // Normalize (0 to 1)
        float x = Mathf.Lerp(-smileWidthScaled, smileWidthScaled, t);
        float y = smileAngleScaled * (t - 0.5f) * (t - 0.5f) + smileHeightScaled;

        mouthCubes[i].transform.localPosition = new Vector3(x, y, 0.5f);
        mouthCubes[i].transform.localScale = Vector3.one * smileCubeSize;
    }
    }

    void UpdateColors()
    {
        faceCube.GetComponent<Renderer>().material.color = faceColor;
        eyeCubes[0].GetComponent<Renderer>().material.color = eyeColor;
        eyeCubes[1].GetComponent<Renderer>().material.color = eyeColor;
        noseCube.GetComponent<Renderer>().material.color = noseColor;

        foreach (GameObject mouthCube in mouthCubes)
        {
            mouthCube.GetComponent<Renderer>().material.color = mouthColor;
        }
    }

    void UpdateSmile()
    {
        int smileCubeCount = mouthCubes.Count;
        for (int i = 0; i < smileCubeCount; i++)
        {
            float t = i / (float)(smileCubeCount - 1); // Normalize (0 to 1)
            float x = Mathf.Lerp(-smileWidth, smileWidth, t) * faceScale;
            float y = smileAngle * (t - 0.5f) * (t - 0.5f) + smileHeight * faceScale;

            mouthCubes[i].transform.localPosition = new Vector3(x, y, 0.5f);
        }
    }

    GameObject CreateCube(Vector3 position, Vector3 scale, Color color)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.parent = transform;
        cube.transform.localPosition = position;
        cube.transform.localScale = scale;

        Renderer renderer = cube.GetComponent<Renderer>();
        if (cubeMaterial != null)
        {
            renderer.material = new Material(cubeMaterial);
            renderer.material.color = color;
        }
        else
        {
            renderer.material.color = color;
        }

        return cube;
    }
}
