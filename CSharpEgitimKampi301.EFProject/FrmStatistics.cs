using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            //Total Location Count

            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            //Total Capacity

            lblGuideCount.Text = db.Guide.Count().ToString();
            //Total Guide Count

            lblAvgCapacity.Text = Convert.ToDecimal(db.Location.Average(x => x.Capacity)).ToString("0.00");
            //Average Capacity

            lblAvgLocationPrice.Text = Convert.ToDecimal(db.Location.Average(x => x.Price)).ToString("0.00") + " ₺";
            //Average Location Price

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();
            //Added Last Country Name

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City.Equals("Kapadokya")).Select(y => y.Capacity).FirstOrDefault().ToString();
            //Cappadocia Location Capacity

            lblLocationTurkeyAvgCapacity.Text = Convert.ToDecimal(db.Location.Where(x => x.Country.Equals("Türkiye")).Average(y => y.Capacity)).ToString("0.00");
            //Turkey Location Average Capacity

            /*int guideId = Convert.ToInt32(db.Location.Where(x => x.City.Equals("Roma")).Select(y => y.GuideId).FirstOrDefault());
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == guideId).Select(y => y.GuideName).FirstOrDefault().ToString();*/
            //Rome Guide Name

            lblRomeGuideName.Text = db.Location.Where(x => x.City.Equals("Roma")).Select(y => y.Guide.GuideName + " " + y.Guide.GuideSurname).FirstOrDefault();
            //Rome Guide Name

            /*int maxCapacity = Convert.ToInt32(db.Location.Max(x => x.Capacity));
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();*/
            //Max Capacity Location

            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == db.Location.Max(y => y.Capacity)).Select(z => z.City).FirstOrDefault();
            //Max Capacity Location

            lblMostExpensiveLocation.Text = db.Location.OrderByDescending(x => x.Price).Select(y => y.City).FirstOrDefault();
            //Most Expensive Location

            int guideId = db.Guide.Where(x => x.GuideName.Equals("Ayşegül") && x.GuideSurname.Equals("Çınar")).Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideId).Count().ToString();
            //Aysegul Cinar Location Count
        }
    }
}
