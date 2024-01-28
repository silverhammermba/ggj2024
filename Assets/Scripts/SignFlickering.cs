using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SignFlickering : MonoBehaviour
{
    public Material onMaterial = null;
    public Material offMaterial = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material = Random.Range(0, 100)>1 ? onMaterial : offMaterial;
    }

    // called when the script is loaded or a value is changed in the inspector
    void OnValidate()
    {

    }
}
