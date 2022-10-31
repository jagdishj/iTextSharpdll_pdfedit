using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*using iText;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;*/
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Prj_Web_PDF_Form_Fill.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string oldFile = Server.MapPath("/PDFForms/Form49A.pdf");
            string newFile = Server.MapPath("/PDFForms/Form49A_edited.pdf");

            AddTextToPdf(oldFile, newFile, "JJ1234", new System.Drawing.Point(100,100));
            /*PdfReader reader = new PdfReader(Filepath);
            PdfWriter writer = new PdfWriter(dest);
            //PdfDocument pdfDoc = new PdfDocument(reader, writer);
            //var form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            //var fields = form.GetFormFields();


            PdfDocument pdfDoc = new PdfDocument(reader, writer);

            PdfFormField personal = PdfFormField.CreateEmptyField(pdfDoc);
            personal.SetValue("personal");
            PdfTextFormField name =
                    PdfFormField.CreateText(pdfDoc, new Rectangle(60, 38, 16, 150),
                            "name", "JJJ");
            
            personal.AddKid(name);
            name.SetAlternativeName("Name");

            PdfTextFormField password =
                    PdfFormField.CreateText(pdfDoc, new Rectangle(150, 760, 300, 30),
                            "password", "");
            personal.AddKid(password);
            var form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            var fields = form.GetFormFields();
            try
            {
                form.AddField(personal);
            }
            catch(Exception ex)
            { }
            
            //form.AddField(, pdfDoc.GetFirstPage());
            //form.AddFieldAppearanceToPage(personal, pdfDoc.GetFirstPage());

            pdfDoc.Close();

            */

            // open the reader
            /*
            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DarkGray);
            cb.SetFontAndSize(bf, 8);

            // write the text in the pdf content
            cb.BeginText();
            string text = "Some random blablablabla...";
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, text, 520, 640, 0);
            cb.EndText();
            cb.BeginText();
            text = "Other random blabla...";
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 100, 200, 0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();
            */

            return View();
        }

        public static void AddTextToPdf(string inputPdfPath, string outputPdfPath, string textToAdd, System.Drawing.Point point)
        {
            //variables
            string pathin = inputPdfPath;
            string pathout = outputPdfPath;

            //create PdfReader object to read from the existing document
            PdfReader pdfReader = new PdfReader(pathin);

            //create PdfStamper object to write to get the pages from reader 
            PdfStamper stamper = new PdfStamper(pdfReader, new FileStream(pathout, FileMode.Create));

            //select two pages from the original document
            pdfReader.SelectPages("1-2");

                    //gettins the page size in order to substract from the iTextSharp coordinates
                    var pageSize = pdfReader.GetPageSize(1);

                    // PdfContentByte from stamper to add content to the pages over the original content
                    PdfContentByte pbover = stamper.GetOverContent(1);

                    //add content to the page using ColumnText
                    Font font = new Font();
                    font.Size = 45;

                    //setting up the X and Y coordinates of the document
                    int x = point.X;
                    int y = point.Y;

                    y = (int)(pageSize.Height - y);

                    ColumnText.ShowTextAligned(pbover, Element.ALIGN_CENTER, new Phrase(textToAdd, font), x, y, 0);
            stamper.Close();
            pdfReader.Close();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}