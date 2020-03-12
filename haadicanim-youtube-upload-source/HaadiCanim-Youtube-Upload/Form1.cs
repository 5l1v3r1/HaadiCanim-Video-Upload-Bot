using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Eklenenler
using Google.GData.Client.ResumableUpload;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using Google.GData.Client;

namespace HaadiCanim_Youtube_Upload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();

            DialogResult soru = ac.ShowDialog();


            if (soru == DialogResult.OK)
            {
                textBox1.Text = ac.FileName;

                UploadVideo(ac.FileName,"Test Video","Test Video açıklaması");
            }
            else
            {
                MessageBox.Show("Yüklenecek dosya seçilmedi");
                label2.Text = "Yüklenecek dosya seçilmedi";
            }

        }

        #region Youtube Upload Fonksiyonu
        public static string UploadVideo(string FilePath, string Title, string Description)
        {
            YouTubeRequestSettings settings;
            YouTubeRequest request;
            string devkey = "AIzaSyAijRdjujLWtxE2cz5OcvH7pxEVlLMYQuI"; //Api Key
            string username = "haadicanim"; //Kullanıcı adı
            string password = "holocaust32"; //Kullanıcı şifre
            settings = new YouTubeRequestSettings("Haadi Canim Browser", devkey, username, password) { Timeout = -1 };
            request = new YouTubeRequest(settings);

            //settings.Timeout = 1;

            Video newVideo = new Video();

            newVideo.Title = Title;
            newVideo.Description = Description;
            newVideo.Private = true;
            newVideo.YouTubeEntry.Private = false;

            //newVideo.Tags.Add(new MediaCategory("Autos", YouTubeNameTable.CategorySchema));

            //newVideo.Tags.Add(new MediaCategory("mydevtag, anotherdevtag", YouTubeNameTable.DeveloperTagSchema));

            //newVideo.YouTubeEntry.setYouTubeExtension("location", "Paris, FR");
            // You can also specify just a descriptive string ==>
            // newVideo.YouTubeEntry.Location = new GeoRssWhere(71, -111);
            // newVideo.YouTubeEntry.setYouTubeExtension("location", "Paris, France.");

            newVideo.YouTubeEntry.MediaSource = new MediaFileSource(FilePath, "video/mp4");
            Video createdVideo = request.Upload(newVideo);

            return createdVideo.VideoId;
        }
        #endregion
    }
}
