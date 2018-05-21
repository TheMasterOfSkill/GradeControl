using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace GradeControl
{
    public static class DataGridStyler
    {
        private const string RELEVANT_COLOR = "#FF5A28";

        private static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;

                if (child == null)
                    child = GetVisualChild<T>(v);
                else
                    break;
            }

            return child;
        }

        private static DataGridRow GetRow(DataGrid grid, int index)
        {
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);

            if (row == null)
            {
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.Items[index]);
                row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            }

            return row;
        }

        private static DataGridCell GetCell(DataGrid grid, DataGridRow row, int column)
        {
            if (row != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

                if (presenter == null)
                {
                    grid.ScrollIntoView(row, grid.Columns[column]);
                    presenter = GetVisualChild<DataGridCellsPresenter>(row);
                }

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }

            return null;
        }

        private static DataGridCell GetCell(DataGrid grid, int row, int column)
        {
            DataGridRow rowContainer = GetRow(grid, row);
            return GetCell(grid, rowContainer, column);
        }

        public static void SetCellEmptyAndDisabled(DataGrid grid, int row, int column)
        {
            DataGridCell cell = GetCell(grid, row, column);
            cell.Content = null;
            cell.IsEnabled = false;
        }

        public static void SetCellRelevant(DataGrid grid, int row, int column, bool relevant)
        {
            DataGridCell cell = GetCell(grid, row, column);
            Brush brush;

            if (relevant)
                brush = (SolidColorBrush)new BrushConverter().ConvertFromString(RELEVANT_COLOR);
            else
                brush = new SolidColorBrush(Colors.Transparent);

            cell.Background = brush;
        }
    }
}
