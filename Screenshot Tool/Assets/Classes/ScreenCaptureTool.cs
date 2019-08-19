using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC.Tools.ScreenCapture
{
    public class ScreenCaptureTool : MonoBehaviour
    {
        public static ScreenCaptureTool instance; // Singleton

        // Normal Settings
        [SerializeField, Tooltip("The file name of the screenshot")] private string fileName = "Screenshot";
        [SerializeField, Range(1, 5),
            Tooltip("Upscale the initial image by a factor of x")] private int upScale = 1;

        // Advanced Settings
        [SerializeField, 
            Tooltip("Recommended for sequencial screenshots")] private bool useTime = false;
        [SerializeField, Tooltip("The file type of the screenshot")] private FileType fileType = FileType.PNG;


        /// <summary>
        /// Take screenshot without passing in any settings
        /// </summary>
        [ContextMenu("Take Screenshot")]
        public void TakeScreenshot()
        {
            // Set the file name
            string file = fileName;

            // If we are using time to modify the file name
            if (useTime)
            {
                // Get the current time in string form
                string time = System.DateTime.Now.ToLongTimeString();
                
                // Replace all : with _
                time = time.Replace(':', '_');

                // Add the current time to the file name
                file += "_" + time;
            }
            
            // Add the correct file extension to the file name
            file += DetermineFileType(fileType);

            // Take the screenshot
            UnityEngine.ScreenCapture.CaptureScreenshot(file, upScale);
        }

        /// <summary>
        /// Take screenshot with some settings
        /// </summary>
        /// <param name="_fileName">Name of the file</param>
        public void TakeScreenshot(string _fileName)
        {
            // Set the file name
            string file = _fileName;

            // If we are using time to modify the file name
            if (useTime)
            {
                // Get the current time in string form
                string time = System.DateTime.Now.ToLongTimeString();

                // Replace all : with _
                time = time.Replace(':', '_');

                // Add the current time to the file name
                file += "_" + time;
            }

            // Add the correct file extension to the file name
            file += DetermineFileType(fileType);

            // Take the screenshot
            UnityEngine.ScreenCapture.CaptureScreenshot(file, upScale);
        }

        /// <summary>
        /// Take screenshot with some settings
        /// </summary>
        /// <param name="_fileName">Name of the file</param>
        /// <param name="_useTime">Is the current time addd to the file name</param>
        public void TakeScreenshot(string _fileName, bool _useTime)
        {
            // Set the file name
            string file = _fileName;

            // If we are using time to modify the file name
            if (_useTime)
            {
                // Get the current time in string form
                string time = System.DateTime.Now.ToLongTimeString();

                // Replace all : with _
                time = time.Replace(':', '_');

                // Add the current time to the file name
                file += "_" + time;
            }

            // Add the correct file extension to the file name
            file += DetermineFileType(fileType);

            // Take the screenshot
            UnityEngine.ScreenCapture.CaptureScreenshot(file, upScale);
        }

        /// <summary>
        /// Take screenshot with some settings
        /// </summary>
        /// <param name="_fileName">Name of the file</param>
        /// <param name="_upscale">The value the image is upscaled by</param>
        public void TakeScreenshot(string _fileName, int _upscale)
        {
            // Set the file name
            string file = _fileName;

            // If we are using time to modify the file name
            if (useTime)
            {
                // Get the current time in string form
                string time = System.DateTime.Now.ToLongTimeString();

                // Replace all : with _
                time = time.Replace(':', '_');

                // Add the current time to the file name
                file += "_" + time;
            }

            // Add the correct file extension to the file name
            file += DetermineFileType(fileType);

            // Take the screenshot
            UnityEngine.ScreenCapture.CaptureScreenshot(file, _upscale);
        }

        /// <summary>
        /// Take screenshot with some settings
        /// </summary>
        /// <param name="_fileName">Name of the file</param>
        /// <param name="_upscale">The value the image is upscaled by</param>
        /// <param name="_useTime">Is the current time addd to the file name</param>
        public void TakeScreenshot(string _fileName, int _upscale, bool _useTime)
        {
            // Set the file name
            string file = _fileName;

            // If we are using time to modify the file name
            if (_useTime)
            {
                // Get the current time in string form
                string time = System.DateTime.Now.ToLongTimeString();

                // Replace all : with _
                time = time.Replace(':', '_');

                // Add the current time to the file name
                file += "_" + time;
            }

            // Add the correct file extension to the file name
            file += DetermineFileType(fileType);

            // Take the screenshot
            UnityEngine.ScreenCapture.CaptureScreenshot(file, _upscale);
        }

        /// <summary>
        /// Reset the current settings to the defaults
        /// </summary>
        public void ResetSettings()
        {
            // TODO: Make sure that all settings are reset
            fileName = "Screenshot";
            upScale = 1;
            useTime = false;
            fileType = FileType.PNG;
        }

        /// <summary>
        /// Determines what the file type is and returns it's respective file extension in string form
        /// </summary>
        /// <param name="_type">File type</param>
        /// <returns>File extension in string form</returns>
        private string DetermineFileType(FileType _type)
        {
            switch(_type)
            {
                case FileType.PNG:
                    return ".png";
                case FileType.JPEG:
                    return ".jpeg";
                case FileType.BMP:
                    return ".bmp";
                case FileType.GIF:
                    return ".gif";
                default: // If not a standard image file format return empty string and log error
                    Debug.LogError("Screenshot - Invalid File Type");
                    return "";
            }
        }
    }

    public enum FileType
    {
        PNG,
        JPEG,
        BMP,
        GIF,
    }
}
