using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using TMPro;
using System.Drawing;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class EventManager : MonoBehaviour
{
    public enum Mode
    {
        None,
        MainMonitor,
        VerticalMonitor,
        Laptop,
        Browser
    }

    public enum Figure
    {
        foxgirl,
        guts,
        phoenix
    }

    public Mode currentMode;

    public Figure selectedFigure;

    public GameObject MainCanvas;
    public GameObject MainMonitorCanvas;
    public GameObject VerticalMonitorCanvas;
    public GameObject LaptopCanvas;
    public GameObject BrowserCanvas;

    public TMP_Text descryption;

    public Sprite foxgirl_image;
    public Sprite guts_image;
    public Sprite phoenix_image;

    public Image descImage;


    //private void Start()
    //{
    //    descImage
    //}

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (currentMode == Mode.MainMonitor)
            {
                MainCanvas.SetActive(true);
                MainMonitorCanvas.SetActive(false);
                ChangeMode("None");
            } else if (currentMode == Mode.VerticalMonitor)
            {
                MainCanvas.SetActive(true);
                VerticalMonitorCanvas.SetActive(false);
                ChangeMode("None");
            } else if (currentMode == Mode.Laptop)
            {
                MainCanvas.SetActive(true);
                LaptopCanvas.SetActive(false);
                ChangeMode("None");
            }
            else if (currentMode == Mode.Browser)
            {
                MainMonitorCanvas.SetActive(true);
                BrowserCanvas.SetActive(false);
                ChangeMode("MainMonitor");
            }
        }
    }

    public void ChangeMode(string newMode) { Enum.TryParse(newMode, out currentMode); }
    public void ChangefigureSelected(string newFigure) 
    {
        Enum.TryParse(newFigure, out selectedFigure);
        if (selectedFigure == Figure.phoenix)
        {
            descryption.SetText("\"Objection! Your honor, there is no copyright violation in this game!\"");
            descImage.sprite = phoenix_image;
        }
        if (selectedFigure == Figure.guts)
        {
            descryption.SetText("\"Tell him... welp nevermind, i am going to sleep\"");
            descImage.sprite = guts_image;
        }
        if (selectedFigure == Figure.foxgirl)
        {
            descryption.SetText("Humanization of the best university's mascot! Limited edition!");
            descImage.sprite = foxgirl_image;
        }
    }
}
