using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipScreenSpaceUI : MonoBehaviour
{
    public static TooltipScreenSpaceUI Instance { get; private set; }

    private RectTransform backgroundRectTransform;
    private TextMeshProUGUI text;
    private RectTransform tooltipTransform;

    [SerializeField] private RectTransform canvasTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        tooltipTransform = transform.GetComponent<RectTransform>();

        HideTooltip();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasTransform.localScale.x;
        
        if(anchoredPosition.x + backgroundRectTransform.rect.width > canvasTransform.rect.width)
        {
            anchoredPosition.x = canvasTransform.rect.width - backgroundRectTransform.rect.width;
        }
        if (anchoredPosition.y + backgroundRectTransform.rect.height > canvasTransform.rect.height)
        {
            anchoredPosition.y = canvasTransform.rect.height - backgroundRectTransform.rect.height;
        }

        tooltipTransform.anchoredPosition = anchoredPosition;
    }

    private void SetText(string tooltipText)
    {
        text.SetText(tooltipText);
        text.ForceMeshUpdate();

        Vector2 textSize = text.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(8, 8);

        backgroundRectTransform.sizeDelta = textSize + paddingSize;
    }

    private void ShowTooltip(string tooltipText)
    {
        gameObject.SetActive(true);
        SetText(tooltipText);
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipText)
    {
        Instance.ShowTooltip(tooltipText);
    }

    public static void HideTooltip_Static()
    {
        Instance.HideTooltip();
    }
}
