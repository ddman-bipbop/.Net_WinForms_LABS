using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Lab13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataSet1 _commentDbDataSet;
        private DataSet1TableAdapters.Kind_sportTableAdapter _commentDbDataSetUsersTableAdapter;
        private DataSet1TableAdapters.Sport_clubTableAdapter _commentDbDataSetCommentsTableAdapter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _commentDbDataSet = (DataSet1)FindResource("DataSet1");
            // Загрузить данные в таблицу Users. Можно изменить этот код как требуется.
            _commentDbDataSetUsersTableAdapter = new DataSet1TableAdapters.Kind_sportTableAdapter();
            _commentDbDataSetUsersTableAdapter.Fill(_commentDbDataSet.Kind_sport);
            var usersViewSource = (CollectionViewSource)FindResource("kindSportViewSource");
            usersViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Comments. Можно изменить этот код как требуется.
            _commentDbDataSetCommentsTableAdapter = new DataSet1TableAdapters.Sport_clubTableAdapter();
            _commentDbDataSetCommentsTableAdapter.Fill(_commentDbDataSet.Sport_club);
            var usersCommentsViewSource = (CollectionViewSource)FindResource("sportClubViewSource");
            usersCommentsViewSource.View.MoveCurrentToFirst();
        }

        private void SaveSportClub_Click(object sender, RoutedEventArgs e)
        {
            _commentDbDataSetCommentsTableAdapter.Update(_commentDbDataSet.Sport_club);
        }

        private void DeleteSportClub_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < sportClubDataGrid.SelectedItems.Count; i++)
            {
                var dataRowView = sportClubDataGrid.SelectedItems[i] as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dataRow = dataRowView.Row;
                    dataRow.Delete();
                }
            }
            _commentDbDataSetCommentsTableAdapter.Update(_commentDbDataSet.Sport_club);
        }
        private void loadImage_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".jpg",
                Filter = "Image files (*.jpg)|*.jpg|All files|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                if (sportClubDataGrid.SelectedItems.Count > 0)
                {
                    var dataRowView = sportClubDataGrid.SelectedItems[0] as DataRowView;
                    if (dataRowView != null)
                    {
                        var dataRow = dataRowView.Row as DataSet1.Sport_clubRow;
                        if (dataRow != null)
                        {
                            dataRow.Image_club = File.ReadAllBytes(openFileDialog.FileName);
                        }
                    }
                }
            }
        }

        private void SaveKindSport_Click(object sender, RoutedEventArgs e)
        {
            _commentDbDataSetUsersTableAdapter.Update(_commentDbDataSet.Kind_sport);
        }

        private void DeleteKindSport_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < kindSportDataGrid.SelectedItems.Count; i++)
            {
                var dataRowView = kindSportDataGrid.SelectedItems[i] as DataRowView;
                if (dataRowView != null)
                {
                    DataRow dataRow = dataRowView.Row;
                    dataRow.Delete();
                }
            }
            _commentDbDataSetUsersTableAdapter.Update(_commentDbDataSet.Kind_sport);
        }
    }
}
