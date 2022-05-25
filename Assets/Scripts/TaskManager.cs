using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [Header("Add task button")]
    [Header(" heights")]
    [SerializeField] float _shrinkHeight;
    [SerializeField] float _ExpandHeight;
    [Header("Frames")]
    [SerializeField] Sprite _shringFrame;
    [SerializeField] Sprite _expandFrame;
    [Header("Picture")]
    [SerializeField] Image _pictureImage;
    [SerializeField] Color _pictureDisableColor;
    Image _addTaskButtonFrameImage;
    [Header("References")]
    [SerializeField] RectTransform _addTaskButton;
    [SerializeField] GameObject _addTaskButtonOtherButtons;
    [SerializeField] Image _okAddButton;
    [Header("")]
    [SerializeField] Transform _taskListContainer;
    [Header("Ok button sprites")]
    [SerializeField] Sprite _okButtonSprite;
    [SerializeField] Sprite _addButtonSprite;
    static TaskManager _instance;
    AddTaskButtonStates _addTaskState;
    private void Awake()
    {
        _addTaskButtonFrameImage = _addTaskButton.GetComponent<Image>();
        changeAddTaskButtonState(AddTaskButtonStates.Shrinked);
    }


    #region Methods
    /// <summary>
    /// Change the current state and set the correct sizes and frames.
    /// </summary>
    /// <param name="newState"></param>
    private void changeAddTaskButtonState(AddTaskButtonStates newState)
    {
        _addTaskState = newState;
        _addTaskButtonFrameImage.sprite = stateSprite;
        _addTaskButton.sizeDelta = stateHeight;
        _addTaskButtonOtherButtons.SetActive(_addTaskState == AddTaskButtonStates.Expanded);
    }
    public void addNewTask()
    {

    }
    #endregion

    #region Properties
    /// <summary>
    /// Instance of this class.Created to access it without referencing direcly because there will be only one instance of it.
    /// </summary>
    public static TaskManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<TaskManager>();
            return _instance;
        }
    }
    /// <summary>
    /// Returns the correct sprite depending of state.
    /// </summary>
    public Sprite stateSprite => _addTaskState == AddTaskButtonStates.Shrinked ? _shringFrame : _expandFrame;
    /// <summary>
    /// Returns the correct height depending of state.
    /// </summary>
    public Vector2 stateHeight => _addTaskState == AddTaskButtonStates.Shrinked ? new Vector2(_addTaskButton.sizeDelta.x, _shrinkHeight) : new Vector2(_addTaskButton.sizeDelta.x, _ExpandHeight);

    #endregion
}
public enum AddTaskButtonStates
{
    None,
    Shrinked,
    Expanded
}
