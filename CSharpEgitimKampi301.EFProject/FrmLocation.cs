using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName +" "+ x.GuideSurname, x.GuideId

            }).ToList();

            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.DayNight = txtDayNight.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.GuideId = (int)cmbGuide.SelectedValue;
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Location Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnList_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.Location.Find(id); // Find metodu primary key'e (id) göre silme işlemi yapar.
            db.Location.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Location Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnList_Click(null, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Location.Find(id);
            updateValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updateValue.City = txtCity.Text;
            updateValue.Country = txtCountry.Text;
            updateValue.DayNight = txtDayNight.Text;
            updateValue.Price = decimal.Parse(txtPrice.Text);
            updateValue.GuideId = (int)cmbGuide.SelectedValue;
            db.SaveChanges();
            MessageBox.Show("Location Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnList_Click(null, null);
        }
    }
}
