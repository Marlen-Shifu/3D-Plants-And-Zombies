using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Card _cardSO;

    public Card CardSO
    {
        get => _cardSO;
        set { _cardSO = value; }
    }

    private GameObject _draggingBuilding;
    private Building _building;

    private Vector2Int _gradSize = new Vector2Int(15, 10);
    private bool isAvailableToBuild;

    private GridController _gridController;

    private void Awake() 
    {
        _gridController = GridController.Instance;
        _gridController.Grid = new Building[_gradSize.x, _gradSize.y];
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_draggingBuilding != null)
        {
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float pos))
            {
                Vector3 worldPosition = ray.GetPoint(pos);
                int x = Mathf.RoundToInt(worldPosition.x);
                int z = Mathf.RoundToInt(worldPosition.z);

                if (x < 0 || x > _gradSize.x - _building.BuildingSize.x)
                    isAvailableToBuild = false;
                else if (z < 0 || z > _gradSize.y - _building.BuildingSize.y)
                    isAvailableToBuild = false;
                else 
                    isAvailableToBuild = true;

                if (isAvailableToBuild && isPlaceTaken(x, z)) isAvailableToBuild = false;

                if ((x % 2 == 1) || (z % 2 == 1)) isAvailableToBuild = false;

                _draggingBuilding.transform.position = new Vector3(x, 0, z);

                _building.SetColor(isAvailableToBuild);
            }
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!isAvailableToBuild)
            Destroy(_draggingBuilding);
        else
        {
            _gridController.Grid[(int)_draggingBuilding.transform.position.x, (int)_draggingBuilding.transform.position.z] = _building;
            _building.ResetColor();

            WorkingTransition workingTransition = _draggingBuilding.GetComponent<WorkingTransition>();
            workingTransition.IsBuildingPlaced = true;
        }
    }

    private bool isPlaceTaken(int x, int y)
    {
        if (_gridController.Grid[x, y] != null)
            return true;
        return false;
    }

   public void OnPointerDown(PointerEventData eventData)
    {
        _draggingBuilding = Instantiate(_cardSO.prefab, Vector3.zero, Quaternion.identity);

        _building = _draggingBuilding.GetComponent<Building>();

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float pos))
        {
            Vector3 worldPosition = ray.GetPoint(pos);
            int x = Mathf.RoundToInt(worldPosition.x);
            int z = Mathf.RoundToInt(worldPosition.z);

            _draggingBuilding.transform.position = new Vector3(x, 0, z);
        }
    }
}
