using System;

namespace Scraper
{
    public class UriLoader
    {

        public UriLoader()
        {

        }


        /// <summary>
        /// Replaces a field of the format '[FIELD]' with a parameter 'parameter' in a given URI String
        /// </summary>
        /// <param name="baseStr">String to be modified</param>
        /// <param name="fieldStr">Name of the field, typically in all capitals. Surrounded by '[]' in base, but omitted in name.</param>
        /// <param name="paramStr">The parameter to be substituted into the field</param>
        /// <returns>A boolean of whether or not a substitution occurred.</returns>
        public bool ReplaceField(ref string baseStr, string fieldStr, string paramStr)
        {
            for(int i=0; i<baseStr.Length; i++)
            {
                if(baseStr[i] == '[')
                {
                    int j = i;
                    string candidate = "";
                    while(baseStr[j+1] != ']') { candidate += baseStr[j++]; }

                    if (candidate == fieldStr) { ReplaceString(ref baseStr, i, j + 1, paramStr); return true; } //j+1 to tack on the ending ']'
                }
            }
            return false;
        }
        private void ReplaceString(ref string baseStr, int startIndex, int EndIndex, string substitute)
        {
            string tail;
            if (EndIndex < baseStr.Length-1)    tail = baseStr.Substring(EndIndex+1, baseStr.Length - (EndIndex+1));
            else                                tail = "";
            string head = baseStr.Substring(0, startIndex);
            baseStr = head + substitute + tail;
        }
    }
}
