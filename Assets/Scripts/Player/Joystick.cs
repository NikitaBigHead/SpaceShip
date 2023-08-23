using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Joystick : MonoBehaviour
{
    [SerializeField]
    private RectTransform Base;

    [SerializeField]
    private RectTransform Button;

    [SerializeField]
    private TMP_Text text;

    public float horizontal { get; private set; } = 0;
    public float vertical { get; private set; } = 0;

    private Vector2 ButtonPosition;
    private Vector2 CenterPosition;

    // Start is called before the first frame update
    void Start()
    {
        ButtonPosition = Button.position;
        CenterPosition = new Vector2(Base.position.x + Base.rect.width * 0.5f, Base.position.y + Base.rect.height * 0.5f);
    }

    int id = -1;

    bool TouchInRect(Vector2 pos)
    {
        return pos.x > Base.position.x && pos.x < Base.position.x + Base.rect.width
            && pos.y > Base.position.y && pos.y < Base.position.y + Base.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
//#if DEBUG
        float horizontalCoff = 0;
        float verticalCoff = 0;
        if (Input.GetKey(KeyCode.W))
            verticalCoff += 1;
        if (Input.GetKey(KeyCode.S))
            verticalCoff -= 1;
        if (Input.GetKey(KeyCode.A))
            horizontalCoff -= 1;
        if (Input.GetKey(KeyCode.D))
            horizontalCoff += 1;
        horizontal = horizontalCoff;
        vertical = verticalCoff;
//#else
        for (int touchNumber = 0; touchNumber < Input.touchCount; touchNumber++) 
        {
            Touch touch = Input.GetTouch(touchNumber);
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.fingerId == id)
                {
                    Vector2 baseCenter = new Vector2(Base.position.x + Base.rect.width * 0.5f, Base.position.y + Base.rect.height * 0.5f);
                    Vector2 pos = (baseCenter - touch.position);
                    pos = new Vector2(pos.x / Base.rect.width, pos.y / Base.rect.height);
                    pos.x = Mathf.Clamp(pos.x, -1, 1);
                    pos.y = Mathf.Clamp(pos.y, -1, 1);
                    horizontal = -pos.x;
                    vertical = -pos.y;
                    text.text = $"{horizontal}, {vertical}";
                    Button.position = baseCenter - pos * new Vector2(Base.rect.width * 0.5f, Base.rect.height * 0.5f);
                } 
            }
            else if (touch.phase == TouchPhase.Began)
            {
                if (id == -1)
                {
                    if (TouchInRect(touch.position))
                    {
                        id = touch.fingerId;
                        Vector2 baseCenter = new Vector2(Base.position.x + Base.rect.width * 0.5f, Base.position.y + Base.rect.height * 0.5f);
                        Vector2 pos = (baseCenter - touch.position);
                        pos = new Vector2(pos.x / Base.rect.width, pos.y / Base.rect.height);
                        pos.x = Mathf.Clamp(pos.x, -1, 1);
                        pos.y = Mathf.Clamp(pos.y, -1, 1);
                        horizontal = -pos.x;
                        vertical = -pos.y;
                        text.text = $"{horizontal}, {vertical}";
                        Button.position = baseCenter - pos * new Vector2(Base.rect.width * 0.5f, Base.rect.height * 0.5f);
                    }
                }
            } else if (touch.phase == TouchPhase.Ended)
            {
                if (touch.fingerId == id)
                {
                    id = -1;
                    horizontal = 0;
                    vertical = 0;
                    text.text = $"{horizontal}, {vertical}";
                    Button.position = ButtonPosition;
                }
            }
        }
//#endif
    }
}
