using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AftoSpravochnic
{
    public partial class ViewCarPage : Form
    {
        private DataGridView dgvCars;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnDelete;

        public ViewCarPage()
        {
            
            dgvCars = new DataGridView();
            dgvCars.Location = new System.Drawing.Point(20, 60); 
            dgvCars.Size = new System.Drawing.Size(650, 300);
            dgvCars.AllowUserToAddRows = false; 
            dgvCars.AllowUserToDeleteRows = false; 
            dgvCars.ReadOnly = true; 
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 

            
            dgvCars.Columns.Add("Make", "Марка");
            dgvCars.Columns.Add("Model", "Модель");
            dgvCars.Columns.Add("Year", "Год");
            dgvCars.Columns.Add("Color", "Цвет");
            dgvCars.Columns.Add("Price", "Цена");

            
            Controls.Add(dgvCars);

            
            txtSearch = new TextBox();
            txtSearch.Location = new System.Drawing.Point(20, 20);
            txtSearch.Size = new System.Drawing.Size(200, 20);

            
            btnSearch = new Button();
            btnSearch.Text = "Поиск";
            btnSearch.Location = new System.Drawing.Point(240, 20);
            btnSearch.Click += BtnSearch_Click;

            
            btnDelete = new Button();
            btnDelete.Text = "Удалить";
            btnDelete.Location = new System.Drawing.Point(330, 20);
            btnDelete.Click += BtnDelete_Click;

            
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);

            Text = "Просмотр автомобилей";
            LoadCars();
            InitializeComponent();
        }

        private void LoadCars()
        {
            
            if (File.Exists("cars.txt"))
            {
                string[] cars = File.ReadAllLines("cars.txt");
                foreach (var car in cars)
                {
                    
                    var carData = car.Split(',');
                    dgvCars.Rows.Add(carData);
                }
            }
            else
            {
                MessageBox.Show("Нет сохраненных данных.");
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            string searchTerm = txtSearch.Text.ToLower();

            
            foreach (DataGridViewRow row in dgvCars.Rows)
            {
                bool isMatch = false;

                
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm))
                    {
                        isMatch = true;
                        break;
                    }
                }

                
                row.Visible = isMatch;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            
            if (dgvCars.SelectedRows.Count > 0)
            {
                
                int rowIndex = dgvCars.SelectedRows[0].Index;

                
                dgvCars.Rows.RemoveAt(rowIndex);

               
                UpdateCarDataFile();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void UpdateCarDataFile()
        {
            
            var carDataList = new List<string>();

            foreach (DataGridViewRow row in dgvCars.Rows)
            {
                
                if (row.IsNewRow) continue;

                
                var carData = string.Join(",", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value.ToString()));
                carDataList.Add(carData);
            }

            
            File.WriteAllLines("cars.txt", carDataList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage frm = new MainPage();
            this.Hide();
            frm.Show();
        }
    }
}
