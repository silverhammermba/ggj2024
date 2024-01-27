using System;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject textPrefab;
    public String[] options;

    int _selection = 0;
    public int Selection
    {
        get { return _selection; }
        set
        {
            _selection = value;
            if (_selection >= optionText.Length) _selection = optionText.Length - 1;
            if (_selection < 0) _selection = 0;
        }
    }

    TextMeshProUGUI[] optionText;

    // Start is called before the first frame update
    void Start()
    {
        optionText = new TextMeshProUGUI[options.Length];

        for (int i = 0; i < options.Length; ++i)
        {
            GameObject obj = Instantiate(textPrefab, transform);
            TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
            obj.name = "Option " + options[i];
            text.text = options[i];

            text.rectTransform.localPosition = new Vector2(0, -50 * i);
            optionText[i] = text;
        }
        UpdateSelectionColor();
    }

    public void SelectionUp() {
        --Selection;
        UpdateSelectionColor();
    }

    public void SelectionDown() {
        ++Selection;
        UpdateSelectionColor();
    }

    public Vector2 SelectionRightEdge() {
        return new Vector2(200, -50 * Selection);
    }

    private void UpdateSelectionColor() {
        for (int i = 0; i < optionText.Length; ++i)
        {
            optionText[i].color = Selection == i ? Color.red : Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
