using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;



namespace Game
{ 
public class Gamecontroller : MonoBehaviour
{
        // Three text to one for words one for latter in word one for the score
        public Text wordIndicator;
        public Text scoreIndicator;
        public Text letterIndicator;

        public AudioSource correctAnswer; 
        public AudioSource gameWin;
        
        // Creating an object of dragoncontroller class
        private Dragoncontroller Dragon;

        private string word;
        
        // Creating an arry of the charecters
        private char[] reveled;

        // Variable for the score and completed
        private int score;
        private bool completed;
    public void Start()
    {
            // Assinging an unity object to the dragon object of the dragon controller class
            Dragon = GameObject.FindGameObjectWithTag("Player").GetComponent<Dragoncontroller>();
            
            // calling reset method
            reset();   
    }

 
    void Update()
    {
            string s = Input.inputString;

            // Reviling the right answer for player to see but only if the game is completed 
            if (completed)
            {
                // Creating a temporary string for to save the user input
                string tmp = Input.inputString;
                if (Input.anyKeyDown)
                    next();
                return;
            }
            // Getting valid input from user

            if (s.Length == 1 && Textutil.isAlpha(s[0]))
            {
                if (!check(s.ToUpper()[0]))
                {
                    Dragon.punish();

                    if (Dragon.isfired)
                    {
                        //Reveling each latter from user
                        wordIndicator.text = word;
                        completed = true;
                    }
                }
            }

            
    }
        // Checking each user input
        private bool check(char c)
        {
            
            int completed = 0;
            int score = 0;
            bool ret = false;

            for (int i =0; i < reveled.Length; i++)
            {

                if (c == word[i])
                {
                    //check if the charecter is valid or not
                    ret = true;
                    if (reveled[i] == 0)
                    {
                        reveled[i] = c;
                        score++;
                    }
                }
                //check if the game is completed*
                if (reveled[i] != 0)
                {
                    completed++;
                }
                if(score != 0)
                {
                    // If all carecters are reveled
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

           //reveling charecters
            reveled = new char[word.Length];
            letterIndicator.text = "Letters = " + word.Length;
            
            updatewordindicator();
        }
        public void next()
        {
            // If the player runs out of tries reset the game
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
