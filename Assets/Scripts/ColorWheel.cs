using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ColorWheel : MonoBehaviour
{
    public Sprite wheel;

    public Camera camera;

    public int numberOfColors;

    public float radius = 2.5f;

    public float width = 0.6f;

    private const string LAYER_NAME = "UI";

    private bool showWheel = false;

    private List<GameObject> collidersList = new List<GameObject>();
//    public List<ColorId> collidersId = new List<ColorId>();

    public float rayScale = 1.0f;

    public LayerMask layerMask;

    private GameObject wheelCanvas;

    private List<GameObject> rings = new List<GameObject>();

    private ColorPlayer colorPlayer;

    private int currentRing = -1;

    private float distance2 = 0.1f;

    void Start()
    {
        wheelCanvas = new GameObject();
        wheelCanvas.name = "ColorWheelCanvas";
        wheelCanvas.AddComponent<RectTransform>();
        Canvas canvas = wheelCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        wheelCanvas.AddComponent<CanvasScaler>();
        wheelCanvas.AddComponent<GraphicRaycaster>();
        colorPlayer = FindObjectOfType<ColorPlayer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !showWheel)
        {
            CreateNewWheel();
        }
        else if (Input.GetMouseButtonUp(0) && showWheel)
        {
            if (currentRing != -1) colorPlayer.changeColor(colorPlayer.availableColors[(currentRing-1)/2]);
            showWheel = false;
            DestroyWheel();
        }
        if (showWheel)
        {
            gameObject.transform.position = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            SelectColor();
        }
    }

    private void CreateNewWheel()
    {
        showWheel = true;
        CreateWheel();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SelectColor()
    {
        Vector3 currentMousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        currentMousePosition.z = 0.0f;
        Vector3 direction = (currentMousePosition - gameObject.transform.position);
        Debug.DrawRay(gameObject.transform.position, direction * rayScale, Color.white);

        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, direction, direction.magnitude * rayScale,
            layerMask);
        if (hit.collider != null)
        {
//            Debug.Log(hit.collider.gameObject.name);
            int index = collidersList.FindIndex(x => x == hit.collider.gameObject);
            if (index < 0)
            {
//                Debug.Log(hit.collider.gameObject.name);
                return;
            }
            if (index < colorPlayer.availableColorsId.Count)
            {
                if (currentRing != (index *2)+1)
                {
                    if (currentRing > -1)
                    {
                        ChangeRingAlpha(0.5f);
                    }
                    currentRing = (index *2)+1;
                    ChangeRingAlpha(1.0f);
                    Debug.Log(currentRing);
                }
            }
        }
    }

    private void ChangeRingAlpha(float alpha)
    {
        Image image = rings[currentRing].GetComponent<Image>();
        image.color = ChangeAlpha(image.color, alpha);
    }

    public void CreateWheel()
    {
        numberOfColors = colorPlayer.availableColors.Count;

        float degrees = 360.0f / numberOfColors;

        Vector2 upVectorRotation = Vector2.up * radius;

        Vector2 angleVectorRotation = gameObject.Rotate2D(degrees, upVectorRotation);

        float lenghtX = (angleVectorRotation - upVectorRotation).magnitude;

//        Debug.Log("Vector magnitude = " + lenghtX);

        Vector2 upVectorMove = Vector2.up * (radius);

        Vector2 angleVectorMove = gameObject.Rotate2D(degrees / 2.0f, upVectorMove);

        float halfLenght = lenghtX / 2.0f;

        float positionVectorMagnitude = Mathf.Sqrt(radius * radius + halfLenght * halfLenght -
                                                   2.0f * radius * halfLenght *
                                                   Mathf.Cos(Mathf.Deg2Rad * ((180.0f - degrees) / 2.0f)));
//        Debug.Log("Position magnitude: " + positionVectorMagnitude);
        int order = 0;
        
        for (int i = 0; i < numberOfColors; i++)
        {
            GameObject colliderBlock = new GameObject();
            colliderBlock.name = "Block " + i.ToString();
            if(numberOfColors > 1) colliderBlock.transform.Rotate(0.0f, 0.0f, -(degrees * (i) + degrees / 2.0f));
            colliderBlock.transform.SetParent(this.gameObject.transform, false);
            if (numberOfColors < 2) colliderBlock.transform.position = gameObject.transform.position;
            else
            colliderBlock.transform.position = gameObject.transform.position +
                                               new Vector3(angleVectorMove.x, angleVectorMove.y, 0.0f).normalized *
                                               (positionVectorMagnitude + width / 2.0f);
            if (numberOfColors == 2)
            {
                if (i == 0) colliderBlock.transform.position += new Vector3(distance2,0.0f,0.0f);
                else colliderBlock.transform.position += new Vector3(-distance2, 0.0f, 0.0f);
            }

            colliderBlock.layer = gameObject.layer = LayerMask.NameToLayer(LAYER_NAME);
            BoxCollider2D box = colliderBlock.AddComponent<BoxCollider2D>();
            box.isTrigger = true;
            box.offset = new Vector2(0.0f, 0.0f);
            if(numberOfColors > 1) box.size = new Vector2(lenghtX, width);
            else box.size = new Vector2(radius*2.0f,radius*2.0f);
            angleVectorMove = gameObject.Rotate2D(degrees, angleVectorMove);
            collidersList.Add(colliderBlock);
            AddRing(degrees * (numberOfColors - i), new Color(0.0f, 0.0f, 0.0f, 1.0f));
            AddRing(degrees * (numberOfColors - i), ChangeAlpha(colorPlayer.availableColors[i].colorWheel,0.5f));
        }
    }

    private void AddRing(float degrees, Color color)
    {
        GameObject colorRing = new GameObject();
        RectTransform rectTransform = colorRing.AddComponent<RectTransform>();
        rectTransform.position = new Vector3(0.0f, 0.0f, 0.0f);
        rectTransform.sizeDelta = new Vector2(1024.0f, 1024.0f);
        rectTransform.localScale = new Vector3(0.6f, 0.6f, 1.0f);
        colorRing.AddComponent<CanvasRenderer>();
        Image image = colorRing.AddComponent<Image>();
        image.sprite = wheel;
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Radial360;
        image.fillOrigin = (int) Image.Origin360.Top;
        image.fillClockwise = false;
        image.color = color;
        float fillAmount = degrees / 360.0f;
        image.fillAmount = fillAmount;
        rings.Add(colorRing);
        colorRing.transform.SetParent(wheelCanvas.transform, false);
    }

    public void DestroyWheel()
    {
        foreach (var collider in collidersList)
        {
            Destroy(collider);
        }
        foreach (var ring in rings)
        {
            Destroy(ring);
        }
        collidersList.Clear();
        rings.Clear();
        currentRing = -1;
    }

    public Color ChangeAlpha(Color oldColor,float alpha)
    {
        return new Color(oldColor.r, oldColor.g, oldColor.b, alpha);

    }
}