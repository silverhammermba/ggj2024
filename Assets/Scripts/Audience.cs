using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Audience : MonoBehaviour
{
    public Material[] materials;

    public float width = 0;
    public float depth = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when the script is loaded or a value is changed in the inspector
    void OnValidate()
    {
        // skip if invalid params
        if (materials == null || materials.Length == 0 || width <= 0 || depth <= 0 || transform.childCount <= 0) return;

        // randomize position/appearnce of children
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform person = transform.GetChild(i);
            MeshRenderer renderer = person.GetComponent<MeshRenderer>();
            renderer.material = materials[Random.Range(0, materials.Length)];
            person.localPosition = new Vector3(Random.Range(-width / 2, width / 2), 0, Random.Range(-depth / 2, depth / 2));
        }
    }
}
