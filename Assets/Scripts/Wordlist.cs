using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Util 
{
    public class Wordlist : MonoBehaviour
    {
        private static Wordlist s_instance;
        private string[] wrods;

        public static Wordlist instance
        {
            get 
            {
                return s_instance == null ? load() : s_instance;
            }
        }
        private Wordlist(string[] words)
        {
            this.wrods = words;    
        }

        private static bool isWordok(string word) 
        {
            if (word.Length < 1)
                return false;

            foreach(char c in word)
            {
                if (!Textutil.isAlpha(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static Wordlist load()
        {
            if(s_instance != null)
            {
                return s_instance;
            }
            HashSet<string> wordlist = new HashSet<string>();
            TextAsset asset = Resources.Load("words") as TextAsset;
            TextReader src = new StringReader(asset.text);

            while (src.Peek() != -1)
            {
                string word = src.ReadLine();

                if (isWordok(word))
                {
                    wordlist.Add(word);
                }
            }
            Resources.UnloadAsset(asset);
            
            string[] words = new string[wordlist.Count];
            wordlist.CopyTo(words);

            s_instance = new Wordlist(words);
            return s_instance;
        }
        public string next(int limit)
        {
            int index = (int)(Random.value * (wrods.Length - 1));
            return wrods[index];
        }
    }
}
