using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Panels")]
    public GameObject BuildingSelectionPanel;
    public GameObject FloorSelectionPanel;
    public GameObject NavigationPanel;

    [Header("Navigation UI")]
    public TextMeshProUGUI NavigationStatus;
    public TextMeshProUGUI NavigationInfo;

    [Header("Current Selection")]
    public string CurrentBuilding = "";
    public int CurrentFloor = 1;

    [Header("Rescue Status")]
    public bool VictimDetected = false;


    // =====================================================
    // AWAKE
    // =====================================================

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // =====================================================
    // START
    // =====================================================

    void Start()
    {
        // Show building selection at the beginning
        if (BuildingSelectionPanel != null)
            BuildingSelectionPanel.SetActive(true);

        // Hide floor selection
        if (FloorSelectionPanel != null)
            FloorSelectionPanel.SetActive(false);

        // Hide navigation panel
        if (NavigationPanel != null)
            NavigationPanel.SetActive(false);

        // Initial navigation status
        if (NavigationStatus != null)
            NavigationStatus.text = "Route Ready";

        Debug.Log("AI AR Rescue Navigation System Started");
    }


    // =====================================================
    // BUILDING SELECTION
    // =====================================================

    public void SelectBuilding(string buildingName)
    {
        CurrentBuilding = buildingName;

        if (BuildingSelectionPanel != null)
            BuildingSelectionPanel.SetActive(false);

        if (FloorSelectionPanel != null)
            FloorSelectionPanel.SetActive(true);

        Debug.Log("Building Selected: " + buildingName);
    }


    // =====================================================
    // FLOOR SELECTION
    // =====================================================

    public void SelectFloor(int floor)
    {
        CurrentFloor = floor;

        Debug.Log("Floor Selected: " + floor);
    }


    // =====================================================
    // OPEN RESCUE NAVIGATION
    // =====================================================

    public void OpenNavigation()
    {
        // Hide building selection
        if (BuildingSelectionPanel != null)
            BuildingSelectionPanel.SetActive(false);

        // Hide floor selection
        if (FloorSelectionPanel != null)
            FloorSelectionPanel.SetActive(false);

        // Show navigation panel
        if (NavigationPanel != null)
            NavigationPanel.SetActive(true);

        // Show Route Ready
        if (NavigationStatus != null)
            NavigationStatus.text = "Route Ready";

        // Show only building and floor
        if (NavigationInfo != null)
        {
            NavigationInfo.text =
                "Building: " + CurrentBuilding +
                "\nFloor: " + CurrentFloor;
        }

        Debug.Log("Rescue Navigation Started");
        Debug.Log("Building: " + CurrentBuilding);
        Debug.Log("Floor: " + CurrentFloor);
    }


    // =====================================================
    // START AR NAVIGATION
    // =====================================================

    public void StartARNavigation()
    {
        Debug.Log("AR Navigation Started!");

        Debug.Log(
            "Navigation Target: " +
            CurrentBuilding +
            " - Floor " +
            CurrentFloor
        );

        // Change Route Ready to AR Navigation Active
        if (NavigationStatus != null)
        {
            NavigationStatus.text = "AR NAVIGATION ACTIVE";
        }

        // Show building and floor information
        if (NavigationInfo != null)
        {
            NavigationInfo.text =
                "Building: " + CurrentBuilding +
                "\nFloor: " + CurrentFloor +
                "\n\nFollow the AR route";
        }
    }


    // =====================================================
    // VICTIM DETECTION
    // =====================================================

    public void VictimFound()
    {
        VictimDetected = true;

        Debug.Log("Victim Detected Successfully");

        // Change status
        if (NavigationStatus != null)
        {
            NavigationStatus.text = "VICTIM DETECTED!";
        }

        // Show victim information
        if (NavigationInfo != null)
        {
            NavigationInfo.text =
                "Building: " + CurrentBuilding +
                "\nFloor: " + CurrentFloor +
                "\n\nProceed to victim location";
        }
    }
}