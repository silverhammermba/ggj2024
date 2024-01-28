using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Audience : MonoBehaviour
{
    public Material[] materials;

    public float width = 0;
    public float depth = 0;
    private Vector3[] offsets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (offsets == null || offsets.Length != transform.childCount)
            return;
        // randomize position/appearnce of children
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform person = transform.GetChild(i);

            double offset_x = System.Math.Sin(Time.timeAsDouble+((double)i)*1.234);
            offset_x = System.Math.Pow(offset_x, 11)*0.1;
            double offset_z = System.Math.Sin(Time.timeAsDouble*0.7+((double)i)*2.234);
            offset_z = System.Math.Pow(offset_z, 21)*0.05;
            person.localPosition = new Vector3(offsets[i].x + (float)offset_x, offsets[i].y+(float)offset_z, offsets[i].z);
        }        
    }

    // called when the script is loaded or a value is changed in the inspector
    void OnValidate()
    {
        // skip if invalid params
        if (materials == null || materials.Length == 0 || width <= 0 || depth <= 0 || transform.childCount <= 0) return;

        offsets = new Vector3[transform.childCount];
        // randomize position/appearnce of children
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform person = transform.GetChild(i);
            MeshRenderer renderer = person.GetComponent<MeshRenderer>();
            renderer.material = materials[Random.Range(0, materials.Length)];
            offsets[i] = new Vector3(Random.Range(-width / 2, width / 2), 0, Random.Range(-depth / 2, depth / 2));
        }

        Update();
    }
}
