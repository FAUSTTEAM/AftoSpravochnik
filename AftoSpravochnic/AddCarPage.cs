using System;
using System.Windows.Forms;

namespace AftoSpravochnic
{
    public partial class AddCarPage : Form
    {
        private TextBox txtMake;
        private TextBox txtModel;
        private TextBox txtYear;
        private TextBox txtColor;
        private TextBox txtPrice;
        private Button btnSave;

        public AddCarPage()
        {
            
            txtMake = new TextBox();
            txtModel = new TextBox();
            txtYear = new TextBox();
            txtColor = new TextBox();
            txtPrice = new TextBox();
            btnSave = new Button();

            
            Label lblMake = new Label();
            Label lblModel = new Label();
            Label lblYear = new Label();
            Label lblColor = new Label();
            Label lblPrice = new Label();

            lblMake.Text = "Марка:";
            lblMake.Text = "Марка:";
            lblModel.Text = "Модель:";
            lblYear.Text = "Год:";
            lblColor.Text = "Цвет:";
            lblPrice.Text = "Цена:";

            
            lblMake.Location = new System.Drawing.Point(20, 20);
            txtMake.Location = new System.Drawing.Point(150, 20);
            txtMake.Size = new System.Drawing.Size(200, 20);
            txtMake.ScrollBars = ScrollBars.Horizontal; 

            lblModel.Location = new System.Drawing.Point(20, 60);
            txtModel.Location = new System.Drawing.Point(150, 60);
            txtModel.Size = new System.Drawing.Size(200, 20);
            txtModel.ScrollBars = ScrollBars.Horizontal; 

            lblYear.Location = new System.Drawing.Point(20, 100);
            txtYear.Location = new System.Drawing.Point(150, 100);
            txtYear.Size = new System.Drawing.Size(200, 20);
            txtYear.ScrollBars = ScrollBars.Horizontal; 

            lblColor.Location = new System.Drawing.Point(20, 140);
            txtColor.Location = new System.Drawing.Point(150, 140);
            txtColor.Size = new System.Drawing.Size(200, 20);
            txtColor.ScrollBars = ScrollBars.Horizontal; 

            lblPrice.Location = new System.Drawing.Point(20, 180);
            txtPrice.Location = new System.Drawing.Point(150, 180);
            txtPrice.Size = new System.Drawing.Size(200, 20);
            txtPrice.ScrollBars = ScrollBars.Horizontal; 

            btnSave.Text = "Сохранить";
            btnSave.Location = new System.Drawing.Point(100, 220);
            btnSave.Click += BtnSave_Click;

            
            Controls.Add(lblMake);
            Controls.Add(txtMake);
            Controls.Add(lblModel);
            Controls.Add(txtModel);
            Controls.Add(lblYear);
            Controls.Add(txtYear);
            Controls.Add(lblColor);
            Controls.Add(txtColor);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(btnSave);

            
            Text = "Добавить автомобиль";
            Size = new System.Drawing.Size(350, 300); 
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Сохраняем данные в файл cars.txt
            string carData = $"{txtMake.Text},{txtModel.Text},{txtYear.Text},{txtColor.Text},{txtPrice.Text}";
            System.IO.File.AppendAllText("cars.txt", carData + Environment.NewLine);
            MessageBox.Show("Данные сохранены!");
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            MainPage frm = new MainPage();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
