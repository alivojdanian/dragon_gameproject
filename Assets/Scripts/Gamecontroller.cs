using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;



namespace Game
{ 
public class Gamecontroller : MonoBehaviour
{
        public Text wordIndicator;
        public Text scoreIndicator;
        public Text letterIndicator;
        public AudioSource correctAnswer; 
        public AudioSource gameWin;


        private Dragoncontroller Dragon;
        private string word;
        private char[] reveled;
        private int score;
        private bool completed;
    public void Start()
    {
            Dragon = GameObject.FindGameObjectWithTag("Player").GetComponent<Dragoncontroller>();
            reset();    
    }

 
    void Update()
    {
            if (completed)
            {

                string tmp = Input.inputString; 
                if(Input.anyKeyDown)
                next();
                return;
            }
            
          
            string s = Input.inputString;
            if (s.Length == 1 && Textutil.isAlpha(s[0]))
            {
                if (!check(s.ToUpper()[0]))
                {
                    Dragon.punish();

                    if (Dragon.isfired)
                    {
                        wordIndicator.text = word;
                        completed = true;
                    }
                }
            }
    }
        private bool check(char c)
        {
            
            int completed = 0;
            int score = 0;
            bool ret = false;

            for (int i =0; i<reveled.Length; i++)
            {
                if (c == word[i])
                {
                    /*check if the charecter is valid or not*/
                    ret = true;
                    if (reveled[i] == 0)
                    {
                        reveled[i] = c;
                        score++;
                    }
                }
                /*check if the game is completed*/
                if (reveled[i] != 0)
                {
                    completed++;
                }
                if(score != 0)
                {
                    this.score += score;
                    if (completed == reveled.Length)
                    {
                        this.completed = true;
                        this.score += reveled.Length;
                        gameWin.Play();
                    }
                    updatewordindicator();
                    updatescoreIndicator();
                }
            }
            return ret;
        }

        private void updatewordindicator()
        {
            string displayed = " ";
            
            for(int i=0 ; i < reveled.Length ; i++)
            {
                char c = reveled[i];
                if (c == 0)
                {
                    c = '_';
                }
                displayed += ' ';
                displayed += c;

            }

            wordIndicator.text = displayed;
    
            
        }

        private void updatescoreIndicator()
        {
            scoreIndicator.text = "Score = " + score;
            correctAnswer.Play();
        }
        private void setword(string word)
        {
            word = word.ToUpper();
            this.word = word;

            /*reveling charecters */
            reveled = new char[word.Length];
            letterIndicator.text = "Letters = " + word.Length;
            
            updatewordindicator();
        }
        public void next()
        {
            Dragon.Reset();
            completed = false;
            setword(Wordlist.instance.next(0));
        }
        public void reset()
        {
            score = 0;
            //completed = false;
            updatescoreIndicator();
            next();
        }
    }
}
