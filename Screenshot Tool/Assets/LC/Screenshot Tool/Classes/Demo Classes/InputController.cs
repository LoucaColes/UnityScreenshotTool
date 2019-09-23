using UnityEngine;

/// <summary>
/// Simple controller to demonstrate screenshots
/// </summary>
public class InputController : MonoBehaviour {

    [Header("Input Keys")]
    [SerializeField] private KeyCode singleScreenshot = KeyCode.Alpha1;
    [SerializeField] private KeyCode repeatingScreenshot = KeyCode.Alpha2;

    [Header("Repeat Settings")]
    [SerializeField] private int repeatCount = 5;
    [SerializeField] private float repeatDelay = 1;

    // Update is called once per frame
    void Update () {

        // Check if single screenshot button was pressed
		if (Input.GetKeyDown(singleScreenshot))
        {
            // If so take screenshot
            LC.Tools.ScreenCapture.ScreenCaptureTool.instance.TakeScreenshot();
        }

        // Check if repeating screenshot button was pressed
        if (Input.GetKeyDown(repeatingScreenshot))
        {
            // If so take repeating screenshots
            LC.Tools.ScreenCapture.ScreenCaptureTool.instance.TakeScreenshotsRepeating(repeatCount, repeatDelay);
        }        
    }
}
