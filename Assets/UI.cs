using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Texture2D[] icons;
    Image[] iconImages;

    // Start is called before the first frame update
    void Start()
    {
        // Texture2D[] icons = Resources.LoadAll("Icons") as Texture2D[];

        iconImages = new Image[icons.Length];

        for (int i = 0; i < icons.Length; ++i)
        {
            GameObject imgObject = new GameObject(icons[i].name);

            RectTransform trans = imgObject.AddComponent<RectTransform>();
            trans.transform.SetParent(gameObject.transform);
            trans.localScale = Vector3.one;
            trans.anchoredPosition = new Vector2(0f, 0f);
            trans.sizeDelta = new Vector2(150, 200);

            Image image = imgObject.AddComponent<Image>();
            image.sprite = Sprite.Create(icons[i], new Rect(0, 0, icons[i].width, icons[i].height), new Vector2(0.5f, 0.5f));
            imgObject.transform.SetParent(gameObject.transform);

            iconImages[i] = image;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image image in iconImages)
        {
            Vector2 pos = image.rectTransform.anchoredPosition;
            image.rectTransform.anchoredPosition = new Vector2(pos.x, pos.y + 1);
        }
    }
}
