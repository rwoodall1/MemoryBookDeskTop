using PdfiumViewer;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
namespace Mbc5.Forms.MixBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void iln()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select PDF";
                ofd.Filter = "PDF files (*.pdf)|*.pdf";
                if (ofd.ShowDialog(this) != DialogResult.OK)
                    return;

                var pdfPath = ofd.FileName;
                try
                {
                    // Load PDF with PdfiumViewer (uses native pdfium for reliable rendering)
                    using (var doc = PdfDocument.Load(pdfPath))
                    {
                        if (doc.PageCount <= 0)
                        {
                            MessageBox.Show(this, "PDF contains no pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Render the last page (choose another index if you want)
                        int pageIndex = Math.Max(0, doc.PageCount - 1);

                        // Desired DPI
                        int dpi = 300;

                        // Determine target pixel size from PDF page size (PdfiumViewer exposes PageSizes in points)
                        // PageSizes entries are in points (1 point = 1/72 inch)
                        var pageSize = doc.PageSizes[pageIndex]; // SizeF (width/height in points)
                        int pixelWidth = (int)Math.Ceiling(pageSize.Width / 72.0f * dpi);
                        int pixelHeight = (int)Math.Ceiling(pageSize.Height / 72.0f * dpi);

                        // Clamp to avoid extremely large bitmaps (adjust limit as needed)
                        const int maxDimension = 10000;
                        if (pixelWidth > maxDimension || pixelHeight > maxDimension)
                        {
                            double scale = Math.Min((double)maxDimension / pixelWidth, (double)maxDimension / pixelHeight);
                            pixelWidth = Math.Max(1, (int)(pixelWidth * scale));
                            pixelHeight = Math.Max(1, (int)(pixelHeight * scale));
                        }

                        // Render page to a Bitmap using Pdfium (includes annotations)
                        using (var rendered = doc.Render(pageIndex, pixelWidth, pixelHeight, dpi, dpi, PdfRenderFlags.Annotations))
                        {
                            // Suggest default filename based on PDF name
                            string defaultName = Path.GetFileNameWithoutExtension(pdfPath) + "_page" + (pageIndex + 1) + ".png";

                            using (var sfd = new SaveFileDialog())
                            {
                                sfd.Title = "Save page as image";
                                sfd.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp";
                                sfd.FileName = defaultName;
                                if (sfd.ShowDialog(this) != DialogResult.OK)
                                    return;

                                ImageFormat fmt = ImageFormat.Png;
                                string ext = Path.GetExtension(sfd.FileName).ToLowerInvariant();
                                if (ext == ".jpg" || ext == ".jpeg") fmt = ImageFormat.Jpeg;
                                else if (ext == ".bmp") fmt = ImageFormat.Bmp;

                                rendered.Save(sfd.FileName, fmt);
                                MessageBox.Show(this, "Saved image: " + sfd.FileName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Show full exception to aid diagnosis of native/pdfium issues
                    MessageBox.Show(this, "Error processing PDF: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.iln();
        }
    }
}
