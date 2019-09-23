using UnityEngine;
using UnityEditor;

namespace LC.Tools.ScreenCapture
{
    /// <summary>
    /// Editor tool to increase functionality of the ScreenCaptureTool inspector
    /// </summary>
    [CustomEditor(typeof(ScreenCaptureTool))]
    public class ScreenCaptureToolEditor : Editor
    {
        ScreenCaptureTool captureTool;

        // Properties
        // Normal Settings
        private SerializedProperty fileName;
        private SerializedProperty upscale;

        // Advanced Settings
        private SerializedProperty useTime;
        private SerializedProperty fileType;

        // Foldouts
        private bool settingsFoldout = true;
        private bool advancedSettingsFoldout = true;

        // Styles
        private Color originalBackgroundColour;
        private GUIStyle screenshotButtonStyle;

        /// <summary>
        /// Set up references and variables
        /// </summary>
        void OnEnable()
        {
            // Get a reference to the target
            captureTool = (ScreenCaptureTool)target;

            // Get all of the properties from the target class
            // Settings
            fileName = serializedObject.FindProperty("fileName");
            upscale = serializedObject.FindProperty("upScale");

            // Advanced Settings
            useTime = serializedObject.FindProperty("useTime");
            fileType = serializedObject.FindProperty("fileType");

            
        }

        /// <summary>
        /// Update the inspector GUI
        /// </summary>
        public override void OnInspectorGUI()
        {
            // Update the serialised object
            serializedObject.Update();

            // Get a copy of the original GUI background colour and set the GUI background colour to it
            originalBackgroundColour = GUI.backgroundColor;
            GUI.backgroundColor = originalBackgroundColour;

            // Display the settings foldout
            settingsFoldout = EditorGUILayout.Foldout(settingsFoldout, "Settings");
            if (settingsFoldout) // If foldout is true
            {
                // Display the file name property field
                EditorGUILayout.PropertyField(fileName);
                if (fileName.stringValue.Length >= 10) // If the file name is >= 10
                {
                    // Display warning message about being too long
                    EditorGUILayout.HelpBox("File name is getting long!", MessageType.Warning);
                }

                // Display the upscale property
                EditorGUILayout.PropertyField(upscale);
                if (upscale.intValue > 1) // If the upscale value is > 1
                {
                    // Display a warning message about framerate issues
                    EditorGUILayout.HelpBox("Setting the upscale value to be greater than 1 can cause framerate issues", MessageType.Warning);
                }
            }

            // Display the advanced settings  foldout
            advancedSettingsFoldout = EditorGUILayout.Foldout(advancedSettingsFoldout, "Advanced Settings");
            if (advancedSettingsFoldout) // If foldout is true
            {
                // Display the use time property
                EditorGUILayout.PropertyField(useTime);
                if (!useTime.boolValue) // If use time is false
                {
                    // Display warning message
                    EditorGUILayout.HelpBox("If taking sequential or a group of screenshots, this will be useful as otherwise screenshots " +
                        "could be overwritten",
                        MessageType.Warning);
                }

                // Display the file type property field
                EditorGUILayout.PropertyField(fileType);
                if (fileType.enumValueIndex == 3) // If gif file type
                {
                    // Display warning message
                    EditorGUILayout.HelpBox("Warning: The gif won't be animated!", MessageType.Warning);
                }
            }

            // Apply the changes to the serialised object
            serializedObject.ApplyModifiedProperties();

            // Set the background colour to red
            GUI.backgroundColor = Color.red;

            // Set up screenshot button style
            screenshotButtonStyle = new GUIStyle(GUI.skin.button);
            screenshotButtonStyle.normal.textColor = Color.white;

            // Display take screenshot button
            if (GUILayout.Button("Take Screenshot", screenshotButtonStyle))
            {
                // If button pressed take screenshot
                captureTool.TakeScreenshot();
            }

            // Reset the GUI background colour
            GUI.backgroundColor = originalBackgroundColour;

            // Display the reset settings button
            if (GUILayout.Button("Reset Settings"))
            {
                // If button pressed reset the settings
                captureTool.ResetSettings();
            }

            // Display the help button
            if (GUILayout.Button("Help!"))
            {
                ScreenCaptureToolHelpWindow window = ScreenCaptureToolHelpWindow.Instance;
            }
        }
    }
}
