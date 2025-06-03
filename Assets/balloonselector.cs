using UnityEngine;

public class SelectTool : MonoBehaviour
{
    [Header("Assignable Selectable Objects (Max 3)")]
    public GameObject[] selectableObjects = new GameObject[3];

    private int currentIndex = 0;

    void Start()
    {
        HighlightCurrentObject();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CycleSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CycleSelection(-1);
        }
    }

    void CycleSelection(int direction)
    {
        UnhighlightCurrentObject();

        // Move index with wrap-around
        currentIndex = (currentIndex + direction + selectableObjects.Length) % selectableObjects.Length;

        HighlightCurrentObject();
    }

    void HighlightCurrentObject()
    {
        if (selectableObjects[currentIndex] != null)
        {
            Renderer rend = selectableObjects[currentIndex].GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.yellow; // Highlight color
            }
        }
    }

    void UnhighlightCurrentObject()
    {
        if (selectableObjects[currentIndex] != null)
        {
            Renderer rend = selectableObjects[currentIndex].GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.red; // Default color
            }
        }
    }
}