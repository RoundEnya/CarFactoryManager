using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Quiz_Main : MonoBehaviour
{
    string[] liness;
    string[] paths = new string[15];
    string[] titles = new string[15];
    public Text[] answer1= new Text[20];
    public Text[] answer2 = new Text[20];
    public Text[] answer3 = new Text[20];
    public Text[] answer4 = new Text[20];
    public Text[] questions=new Text[5];
    private int[] corectAnswers=new int[5];
    private int[] answers = new int[5];
    public Text quizTitle;
    public Text DoneScore;
    public Text RedoScore;
    public Text AnotherScore;
    public int scoreCounter=0;
    private int Category;
    public static GameObject Quiz;
    public static GameObject Done;
    public static GameObject Redo;
    public static GameObject Another;
    public Button[] categoriesButtons = new Button[12];
    public Button[] buttons = new Button[20];
    int j;
    TextAsset quizfile;
    public Text[] categoriesButtonsText = new Text[12];
    public Text SelectCategory;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name=="Quiz_Main")
        {
            SelectCategory.text = LanguageManager.language == "English" ? "Select Category" : "Selecteaza Categoria";
            SetPathsAndTitles();
            for (int i = 0; i < 12; i++)
            {
                if (LanguageManager.language == "Romana")
                {
                    if (ProfileManager.CategoriesAvailable[i] == 0)
                    {
                        categoriesButtons[i].enabled = false;
                    }
                    else
                    {
                        categoriesButtons[i].enabled = true;
                    }
                    categoriesButtonsText[i].text = titles[i];
                }
                else if (LanguageManager.language == "English")
                {
                    if (ProfileManager.CategoriesAvailableEN[i] == 0)
                    {
                        categoriesButtons[i].enabled = false;
                    }
                    else
                    {
                        categoriesButtons[i].enabled = true;
                    }
                    categoriesButtonsText[i].text = titles[i];
                }
            }

        }
        if (SceneManager.GetActiveScene().name == "Quiz")
        {
            Category = PlayerPrefs.GetInt("Category");
            SetPathsAndTitles();
            LoadData();
            Quiz = GameObject.FindGameObjectWithTag("Quiz");
            Done = GameObject.FindGameObjectWithTag("Done");
            Redo = GameObject.FindGameObjectWithTag("Redo");
            Another = GameObject.FindGameObjectWithTag("Another");
            Quiz.SetActive(true);
            Done.SetActive(false);
            Redo.SetActive(false);
            Another.SetActive(false);
        }
    }

    public void SetCategory(int category)
    {
        PlayerPrefs.SetInt("Category", category);
    }
    public void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void setAnswer(Check_Answer ca)
    {
        answers[ca.question-1] = ca.answer;
        for (int i=1;i<=4;i++)
        {
            if (i==ca.answer)
            {
                buttons[(i + (ca.question - 1) * 4)-1].interactable = false;
            }
            else
            {
                buttons[(i + (ca.question - 1) * 4) - 1].enabled = false;
                buttons[(i + (ca.question - 1) * 4) - 1].enabled = true;
                buttons[(i + (ca.question - 1) * 4)-1].interactable = true;
            }
        }

    }
    public void Check()
    {
        for (int i=0;i<=4;i++)
        {
            if (answers[i]==corectAnswers[i])
            {
                scoreCounter++;
            }
        }
        if (scoreCounter>=4)
        {
            if (LanguageManager.language == "Romana")
            {
                ProfileManager.redoAvailable[Category] = 0;
            }
            else if (LanguageManager.language == "English")
            {
                ProfileManager.redoAvailableEN[Category] = 0;
            }
            DoneScore.text = scoreCounter.ToString() + "/5";
            Quiz.SetActive(false);
            Done.SetActive(true);
            ProfileManager.unlockUpgrade = true;
            scoreCounter = 0;
            if (LanguageManager.language == "Romana")
            {
                if (ProfileManager.quizNumber[Category] == j)
                {
                    ProfileManager.CategoriesAvailable[Category] = 0;
                    categoriesButtons[Category].enabled = false;
                    ProfileManager PM = new ProfileManager();
                    PM.SetData();
                }
            }
            else if (LanguageManager.language == "English")
            {
                if (ProfileManager.quizNumberEN[Category] == j)
                {
                    ProfileManager.CategoriesAvailableEN[Category] = 0;
                    categoriesButtons[Category].enabled = false;
                    ProfileManager PM = new ProfileManager();
                    PM.SetData();
                }
            }
        }
        else
        {
            if (LanguageManager.language == "Romana")
            {
                if (ProfileManager.redoAvailable[Category] == 1)
                {
                    ProfileManager.quizNumber[Category] -= 30;
                    RedoScore.text = scoreCounter.ToString() + "/5";
                    Quiz.SetActive(false);
                    Redo.SetActive(true);
                    scoreCounter = 0;
                }
                else if (ProfileManager.redoAvailable[Category] == 2)
                {
                    ProfileManager.redoAvailable[Category] = 0;
                    AnotherScore.text = scoreCounter.ToString() + "/5";
                    Quiz.SetActive(false);
                    Another.SetActive(true);
                    scoreCounter = 0;
                    if (ProfileManager.quizNumber[Category] == j)
                    {
                        ProfileManager.CategoriesAvailable[Category] = 0;
                        categoriesButtons[Category].enabled = false;
                        ProfileManager PM = new ProfileManager();
                        PM.SetData();
                    }
                }
            }
            else if (LanguageManager.language == "English")
            {
                if (ProfileManager.redoAvailableEN[Category] == 1)
                {
                    ProfileManager.quizNumberEN[Category] -= 30;
                    RedoScore.text = scoreCounter.ToString() + "/5";
                    Quiz.SetActive(false);
                    Redo.SetActive(true);
                    scoreCounter = 0;
                }
                else if (ProfileManager.redoAvailableEN[Category] == 2)
                {
                    ProfileManager.redoAvailableEN[Category] = 0;
                    AnotherScore.text = scoreCounter.ToString() + "/5";
                    Quiz.SetActive(false);
                    Another.SetActive(true);
                    scoreCounter = 0;
                    if (ProfileManager.quizNumberEN[Category] == j)
                    {
                        ProfileManager.CategoriesAvailableEN[Category] = 0;
                        categoriesButtons[Category].enabled = false;
                        ProfileManager PM = new ProfileManager();
                        PM.SetData();
                    }
                }
            }
        }
    }
    
    public void RedoQuiz()
    {
        if (LanguageManager.language == "Romana")
        {
            ProfileManager.redoAvailable[Category]++;
        }
        else if (LanguageManager.language == "English")
        {
            ProfileManager.redoAvailableEN[Category]++;
        }
        Redo.SetActive(false);
        Quiz.SetActive(true);
        for (int i=0;i<20;i++)
        {
            buttons[i].enabled = false;
            buttons[i].enabled = true;
            buttons[i].interactable = true;
        }
        for (int i=0;i<=4;i++)
        {
            answers[i] = 0;
        }
        if (LanguageManager.language == "Romana")
        {
            ProfileManager.quizNumber[Category] += 30;
        }
        else if (LanguageManager.language == "English")
        {
            ProfileManager.quizNumberEN[Category] += 30;
        }
        ProfileManager PM = new ProfileManager();
        PM.SetData();
    }


    void Disable(Button b)
    {
        b.enabled = false;
    }

    void LoadData()
    {
        quizfile = Resources.Load(paths[Category]) as TextAsset;
        liness = quizfile.text.Split("\n"[0]);
        Debug.Log(liness[0]);
        quizTitle.text = titles[Category];
        j = Convert.ToInt32(liness[0]);
        if (LanguageManager.language == "Romana")
        {
            for (int i = 0; i <= 4; i++)
            {
                questions[i].text = liness[ProfileManager.quizNumber[Category]++];
                answer1[i].text = liness[ProfileManager.quizNumber[Category]++];
                answer2[i].text = liness[ProfileManager.quizNumber[Category]++];
                answer3[i].text = liness[ProfileManager.quizNumber[Category]++];
                answer4[i].text = liness[ProfileManager.quizNumber[Category]++];
                corectAnswers[i] = Convert.ToInt32(liness[ProfileManager.quizNumber[Category]++]);
            }
        }
        else if (LanguageManager.language == "English")
        {
            for (int i = 0; i <= 4; i++)
            {
                questions[i].text = liness[ProfileManager.quizNumberEN[Category]++];
                answer1[i].text = liness[ProfileManager.quizNumberEN[Category]++];
                answer2[i].text = liness[ProfileManager.quizNumberEN[Category]++];
                answer3[i].text = liness[ProfileManager.quizNumberEN[Category]++];
                answer4[i].text = liness[ProfileManager.quizNumberEN[Category]++];
                corectAnswers[i] = Convert.ToInt32(liness[ProfileManager.quizNumberEN[Category]++]);
            }
        }
        if (LanguageManager.language == "Romana")
        {
            ProfileManager.redoAvailable[Category]++;
        }
        else if (LanguageManager.language == "English")
        {
            ProfileManager.redoAvailableEN[Category]++;
        }
    }

    public void SetPathsAndTitles()
    {
        switch (LanguageManager.language)
        {
            case "Romana":
                paths[0] = "1.Stiinte naturale";
                titles[0] = "Stiinte naturale";
                paths[1] = "2.Arta si Cultura";
                titles[1] = "Arta si Cultura";
                paths[2] = "3.Diverse";
                titles[2] = "Diverse";
                paths[3] = "4.Economie si finante";
                titles[3] = "Economie si finante";
                paths[4] = "5.Filosofie";
                titles[4] = "Filosofie";
                paths[5] = "6.Geografie";
                titles[5] = "Geografie";
                paths[6] = "7.Istoria Romaniei";
                titles[6] = "Istoria Romaniei";
                paths[7] = "8.Istorie universala";
                titles[7] = "Istorie universala";
                paths[8] = "9.Noile mijloace de comunicare IT";
                titles[8] = "Noile mijloace de comunicare IT";
                paths[9] = "10.Religie";
                titles[9] = "Religie";
                paths[10] = "11.Sport";
                titles[10] = "Sport";
                paths[11] = "12.Terra si Natura";
                titles[11] = "Terra si Natura";
                break;
            case "English":
                paths[0] = "1.Basic General Knowledge";
                titles[0] = "Basic General Knowledge";
                paths[1] = "2.General Science";
                titles[1] = "General Science";
                paths[2] = "3.World Geography";
                titles[2] = "World Geography";
                paths[3] = "4.Chemistry";
                titles[3] = "Chemistry";
                paths[4] = "5.Honours and Awards";
                titles[4] = "Honours and Awards";
                paths[5] = "6.Technology";
                titles[5] = "Technology";
                paths[6] = "7.Famous Personalities";
                titles[6] = "Famous Personalities";
                paths[7] = "8.Physics";
                titles[7] = "Physics";
                paths[8] = "9.Inventions";
                titles[8] = "Inventions";
                paths[9] = "10.Biology";
                titles[9] = "Biology";
                paths[10] = "11.Books and Authors";
                titles[10] = "Books and Authors";
                paths[11] = "12.Sports";
                titles[11] = "Sports";
                break;
        }
    }
}
