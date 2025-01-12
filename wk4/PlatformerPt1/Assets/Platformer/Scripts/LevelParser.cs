﻿using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject coinPrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
        
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{"Test"}.txt";  //filename = "Test"
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

            int row = 0;

        // Go through the rows from bottom to top
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (var col = 0; col < letters.Length; col++)
            {
                var letter = letters[col];
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot

                if (letter =='x')
                {
                    Vector3 newPos = new Vector3(col,row,0f);
                    GameObject newObj = Instantiate(rockPrefab,newPos,Quaternion.identity,environmentRoot);
                }
                

                if (letter =='b')
                {
                    Vector3 newPos = new Vector3(col,row,0f);
                    GameObject newObj2 = Instantiate(brickPrefab,newPos,Quaternion.identity,environmentRoot);
                }

                 if (letter =='?')
                {
                    Vector3 newPos = new Vector3(col,row,0f);
                    GameObject newObj3 = Instantiate(questionBoxPrefab,newPos,Quaternion.identity,environmentRoot);
                }
                
                if (letter =='s')
                {
                    Vector3 newPos = new Vector3(col,row,0f);
                    GameObject newObj3 = Instantiate(stonePrefab,newPos,Quaternion.identity,environmentRoot);
                }

                if (letter =='c')
                {
                    Vector3 newPos = new Vector3(col,row,0f);
                    GameObject newObj3 = Instantiate(coinPrefab,newPos,Quaternion.identity,environmentRoot);
                }
                

            }
                row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
