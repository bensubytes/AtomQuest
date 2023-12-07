using UnityEngine;

public class NumberInput : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public TextMesh resultText;
    public int[] correctNumber; // Define the correct number to compare with
    public float segmentThreshold = 0.1f; // Distance threshold between points

    private Vector2 lastMousePosition;
    private bool isDrawing = false;

    void Update()
    {
        // Capture mouse input
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
            CheckInput();
        }
    }

    void StartDrawing()
    {
        lastMousePosition = Input.mousePosition;

        // Clear previous drawing
        lineRenderer.positionCount = 0;
        resultText.text = "";
        isDrawing = true;
    }

    void ContinueDrawing()
    {
        Vector2 currentMousePosition = Input.mousePosition;

        // Draw line
        if (Vector2.Distance(currentMousePosition, lastMousePosition) > segmentThreshold)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, Camera.main.ScreenToWorldPoint(currentMousePosition));

            lastMousePosition = currentMousePosition;
        }
    }

    void StopDrawing()
    {
        isDrawing = false;
    }

    void CheckInput()
    {
        if (isDrawing)
        {
            // Convert the drawn path to a numerical value
            int[] userInput = ConvertDrawingToNumber();

            // Check if the input is correct
            if (IsInputCorrect(userInput))
            {
                resultText.text = "Correct!";
            }
            else
            {
                resultText.text = "Incorrect!";
            }
        }
    }

    int[] ConvertDrawingToNumber()
    {
        // Placeholder implementation returning an empty array
        return new int[0];
    }

    bool IsInputCorrect(int[] userInput)
    {
        // Compare the user's input with the correct number
        return ArraysEqual(userInput, correctNumber);
    }

    bool ArraysEqual(int[] a1, int[] a2)
    {
        if (a1.Length != a2.Length)
            return false;

        for (int i = 0; i < a1.Length; i++)
        {
            if (a1[i] != a2[i])
                return false;
        }

        return true;
    }
}
