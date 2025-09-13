using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Terrenal__Kiel__Inventory
{

    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;

        public string Product_Name(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    throw new StringFormatException("Invalid Input.");
                }
                    
            }
            catch (StringFormatException mim)
            {
                MessageBox.Show(mim.Message);
            }
            return name;
             
        }
        public int Quantity(string qty)
        {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    throw new NumberFormatException("Invalid Input.");
                }
            }
            catch (NumberFormatException mim)
            {  MessageBox.Show(mim.Message); 

            }
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    throw new NumberFormatException("Invalid Input.");
                }
            }
            catch (CurrencyFormatException mim)
            {
                MessageBox.Show(mim.Message);
            }
            return Convert.ToDouble(price);
        }
        
        
        BindingSource showProductList = new BindingSource();


        public frmAddProduct()
        {
            InitializeComponent();
            string[] ListofProductCategory = {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Other",
            };
            foreach (string Category in ListofProductCategory)
            {
                cbCategory.Items.Add(Category);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch
            {

            }

        }
    }
    public class NumberFormatException : Exception
    {
        public NumberFormatException(string str) : base(str)
        {
        }
    }
    public class StringFormatException : Exception
    {
        public StringFormatException(string str) : base(str)
        {
        }
    }
    public class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string str) : base(str)
        {
        }
    }
}


