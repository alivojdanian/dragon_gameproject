using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game 
{
    public class Dragoncontroller : MonoBehaviour
    {

        public GameObject fire;
        public GameObject fire1;
        public GameObject fire2;
        public GameObject fire3;
        public GameObject fire4;
        public GameObject fire5;
        public GameObject fire6;
        public GameObject display;
        private int tries;
        private GameObject[] parts;
        public AudioSource loseSound;
        

        public bool isfired 
        {
            get { return tries < 0; }
        }

        private void Start()
        {
            parts = new GameObject[] { fire, fire1, fire2, fire3, fire4, fire5, fire6 };
            Reset();

        }
       // public void PlayLose()
       // {
            
       // }
        public void punish() 
        {
            if(tries >=0)
            {
                loseSound.Play();
                display.SetActive(false);
                parts[tries--].SetActive(true);
            }
        }
        public void Reset()
        {
            if(parts == null)
            {
                
                return;
            }
            tries = parts.Length - 1;

            foreach (GameObject g in parts)
            {
                
                g.SetActive(false);

            }
        }
    }
}
