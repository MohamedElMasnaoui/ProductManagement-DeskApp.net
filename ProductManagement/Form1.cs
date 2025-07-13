using ProductManagement.Entity;
using ProductManagement.Service.IService;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement
{
    public partial class Form1 : Form
    {
        private readonly IProductService _service = null!;

        private readonly BindingSource _bs = new BindingSource();

        public Form1(IProductService service)
        {
            InitializeComponent();
            _service = service;
            dataGridView1.DataSource = _bs;
            RefreshList();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshList(IEnumerable<Product>? list = null)
        {
            // If no filtered list is passed, get all products
            var items = (list ?? _service.GetAll())
                .Select(p => new { p.Id, p.Name, p.Price })
                .ToList();

            _bs.DataSource = items;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var price = numPrice.Value;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(
                    "Please enter a product name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Add the product, refresh the grid, and clear inputs
            _service.AddProduct(name, price);
            RefreshList();
            txtName.Clear();
            numPrice.Value = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var term = txtSearch.Text.Trim();

            // If there's no search term, show all; otherwise, show filtered
            if (string.IsNullOrEmpty(term))
                RefreshList();
            else
                RefreshList(_service.Search(term));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // simply invoke the TextChanged handler
                txtSearch_TextChanged(txtSearch, EventArgs.Empty);

                // prevent ding+newline
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}