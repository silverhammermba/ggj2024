using System;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject textPrefab;
    public String[] options;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < options.Length; ++i)
        {
            GameObject obj = Instantiate(textPrefab, gameObject.transform);
            TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
            obj.name = "Option " + options[i];
            text.text = options[i];

            text.rectTransform.localPosition = new Vector2(0, -50 * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
