using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC.Tools.ScreenCapture
{
    /// <summary>
    /// A simple tool to take screenshots
    /// </summary>
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

        private void Awake()
        {
            // Check to see if there is an instance
            if (!instance)
            {
                instance = this; // If not set to this
            }
            else
            {
                Destroy(this.gameObject); // Otherwise destroy this
            }
        }


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
        /// <param name="_fileType">The file extention of the image</param>
        public void TakeScreenshot(string _fileName, FileType _fileType)
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
            file += DetermineFileType(_fileType);

            // Take the screenshot
            UnityEngine.ScreenCapture.CaptureScreenshot(file, upScale);
        }

        /// <summary>
        /// Take screenshot with some settings
        /// </summary>
        /// <param name="_fileName">Name of the file</param>
        /// <param name="_upscale">The value the image is upscaled by</param>
        public void TakeScreenshot(string _fileName, int _upScale)
        {
            // Check for an invalid upscale value
            if (_upScale < 1 || _upScale > 5)
            {
                Debug.LogError("Screen Capture Tool - Invalid Upscale");
                return;
            }

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
            UnityEngine.ScreenCapture.CaptureScreenshot(file, _upScale);
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
        /// Takes a screenshot x amount of times with y seconds of delay
        /// </summary>
        /// <param name="_repeatCount">How many times this repeats</param>
        /// <param name="_delay">The delay between each screenshot</param>
        public void TakeScreenshotsRepeating(int _repeatCount, float _delay)
        {
            // Start repeat coroutine
            StartCoroutine(Repeat(_repeatCount, _delay));
        }

        /// <summary>
        /// Will take screenshots for x amount of time with y delay
        /// </summary>
        /// <param name="_repeatCount">How many times this repeats</param>
        /// <param name="_delay">The delay between each screenshot</param>
        /// <returns>Nothing</returns>
        private IEnumerator Repeat(int _repeatCount, float _delay)
        {
            // Set count to 0
            int count = 0;

            // While the count is less than repeat count
            while (count < _repeatCount)
            {
                // Wait for delay
                yield return new WaitForSeconds(_delay);

                // Set up file name
                string newFilename = fileName + count;

                // Take the screenshot
                TakeScreenshot(newFilename);

                // Increase the count
                count++;
            }
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
            // Check the type and return correct file extension
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

        /// <summary>
        /// Used to open the wiki webpage
        /// </summary>
        [ContextMenu("Open Wiki")]
        public void OpenWiki()
        {
#if UNITY_EDITOR
            ScreenCapLinks.OpenWiki(); // If in editor open wiki webpage
#endif
        }

        /// <summary>
        /// Used to open the documentation webpage
        /// </summary>
        [ContextMenu("Open Documentation")]
        public void OpenDocs()
        {
#if UNITY_EDITOR
            ScreenCapLinks.OpenDocumentation(); // If in editor open documentation webpage
#endif
        }
    }

    /// <summary>
    /// Possible file tpyes for the images
    /// </summary>
    public enum FileType
    {
        PNG,
        JPEG,
        BMP,
        GIF,
    }
}
