using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject textPrefab;
    public Image background;
    public Image selector;
    public String[] options;
    public float SelectorOffset = 10;
    Vector2 textSize;

    int _selection = 0;
    public int Selection
    {
        get { return _selection; }
        set
        {
            _selection = value;
            if (_selection >= optionText.Length) _selection = optionText.Length - 1;
            if (_selection < 0) _selection = 0;
            selector.rectTransform.localPosition = new Vector2(selector.rectTransform.localPosition.x, -textSize.y * _selection - SelectorOffset);
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
            textSize = text.rectTransform.sizeDelta;

            text.rectTransform.localPosition = new Vector2(0, -textSize.y * i);
            optionText[i] = text;
        }

        // 8 because the background sprite has a margin of 4 pixels on the top and bottom
        background.rectTransform.sizeDelta = new Vector2(background.rectTransform.sizeDelta.x, 8 + textSize.y * optionText.Length);

        // update selector arrow position
        Selection = Selection;
    }

    public void SelectionUp() {
        --Selection;
    }

    public void SelectionDown() {
        ++Selection;
    }

    public Vector2 SelectionRightEdge() {
        return new Vector2(textSize.x, -textSize.y * Selection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
