using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC.Tools.ScreenCapture
{
    /// <summary>
    /// Used for opening various web pages
    /// </summary>
    public static class ScreenCapLinks
    {

        private static string documentationURL = "https://loucacoles.github.io/UnityScreenshotTool/";
        private static string wikiURL = "https://github.com/LoucaColes/UnityScreenshotTool/wiki";


        /// <summary>
        /// Opens The documentation web page
        /// </summary>
        public static void OpenDocumentation()
        {
            Application.OpenURL(documentationURL);
        }

        /// <summary>
        /// Opens the wiki web page
        /// </summary>
        public static void OpenWiki()
        {
            Application.OpenURL(wikiURL);
        }
    }
}
