using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LC.Tools.ScreenCapture
{
    /// <summary>
    /// A helper window to display any useful information and links
    /// </summary>
    public class ScreenCaptureToolHelpWindow : EditorWindow
    {

        Vector2 scrollPos;

        string welcomeMessage = "Thanks for downloading the Screen Capture Tool by Louca Coles."
            + " This tool can be used to help take gameplay screenshots of you game both in editor and in game.";

        string howToUseMessage = "To use this tool, simply attach the ScreenCaptureTool component to any game object in the scene,"
            + " or use the prefab provided. Once there is an object with the component attached you can enter the various settings."
            + "These settings can be reset, by clicking the reset button. \n"
            + "If you want to take screenshots in editor all you have to do is click the Take Screenshot button,"
            + " however, if you want to take them in game you will need to access the singleton via "
            + "ScreenCaptureTool.instance and call the Take Screenshot function. The Take Screenshot function has different variations,"
            + " this means you can pass in specific settings that you want to use and the ones you don't pass in refer to the defaults"
            + " set in the components inpsector.";

        string settingsMessage = "File Name - This is the name of the file when its saved to the system (NB. you don't need "
            + "to add the file extenstion as that is handled for you.) \n"
            + "Up Scale - This is how much the image size is multiplied by when taken (NB. This can cause performance"
            + " issues when set high) \n"
            + "Use Time - This adds the systems time to the end of the file name \n"
            + "File Type - This determine the file extension that is added to the end of the file name";

        string contactMessage = "For Support - Email: coleslouca@gmail.com (Subject: Unity Screenshot Tool)\n"
            + "If you like this tool make sure to support me on: \n"
            + "Twitter: @LoucaColes_ \n";

        /// <summary>
        /// Get the instance of the help window
        /// </summary>
        public static ScreenCaptureToolHelpWindow Instance
        {
            get { return GetWindow<ScreenCaptureToolHelpWindow>(); }
        }

        // Add menu named "My Window" to the Window menu
        [MenuItem("Tools/ScreenCapTool/Help")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            ScreenCaptureToolHelpWindow window = (ScreenCaptureToolHelpWindow)EditorWindow.GetWindow(typeof(ScreenCaptureToolHelpWindow));
            window.Show();
        }

        void OnGUI()
        {
            // Set up the vertical scroll
            EditorGUILayout.BeginVertical();

            // Update the scroll position
            scrollPos =
                EditorGUILayout.BeginScrollView(scrollPos);

            // Enable word wrap and rich text
            EditorStyles.label.wordWrap = true;
            EditorStyles.label.richText = true;

            // Display welcome message
            EditorGUILayout.LabelField(welcomeMessage);

            EditorGUILayout.Separator();

            // Display how to use text
            EditorGUILayout.LabelField("<b>How To Use</b>");
            EditorGUILayout.LabelField(howToUseMessage);

            EditorGUILayout.Separator();

            // Display settings text
            EditorGUILayout.LabelField("<b>Settings</b>");
            EditorGUILayout.LabelField(settingsMessage);

            EditorGUILayout.Separator();

            // Display contact text
            EditorGUILayout.LabelField("<b>Contact</b>");
            EditorGUILayout.LabelField(contactMessage);

            EditorGUILayout.Separator();

            // End scroll view and vertical scroll
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            // Display and check if open wiki button pressed
            if (GUILayout.Button("Open Wiki"))
            {
                // Open wiki link
                ScreenCapLinks.OpenWiki();
            }

            // Display and check if open docs button pressed
            if (GUILayout.Button("Open Documentation"))
            {
                // Open docs link
                ScreenCapLinks.OpenDocumentation();
            }
        }
    }
}
