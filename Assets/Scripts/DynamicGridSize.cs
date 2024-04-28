using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class DynamicGridSize : MonoBehaviour
{
    public int columnCount;
    public int rowCount;
    private GridLayoutGroup gridLayout;
    
    private RectTransform rectTransform;

    void Start()
    {
        columnCount = PlayerPrefs.GetInt("ColumnCount", 4);
        rowCount = PlayerPrefs.GetInt("RowsCount", 4);
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        UpdateCellSize();
    }

    void UpdateCellSize()
    {
        // Calculate cell size based on parent size, number of columns, and number of rows
        float cellWidth = (rectTransform.rect.width - gridLayout.padding.left - gridLayout.padding.right - (columnCount - 1) * gridLayout.spacing.x) / columnCount;
        float cellHeight = (rectTransform.rect.height - gridLayout.padding.top - gridLayout.padding.bottom - (rowCount - 1) * gridLayout.spacing.y) / rowCount;

        // Setting the cell size
        gridLayout.cellSize = new Vector2(cellWidth, cellHeight);

        // Setting the cell size
        gridLayout.cellSize = new Vector2(cellWidth, cellHeight);
    }
}