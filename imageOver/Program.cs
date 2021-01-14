using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace imageOver
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyProgramPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\files\\";

            using (Stream inputPdfStream = new FileStream(MyProgramPath + "inputPdf.pdf", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream inputImageStream = new FileStream(MyProgramPath + "inputImage.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream outputPdfStream = new FileStream(MyProgramPath + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var reader = new PdfReader(inputPdfStream);
                var stamper = new PdfStamper(reader, outputPdfStream);
                var pdfContentByte = stamper.GetOverContent(1);

                Image image = Image.GetInstance(inputImageStream);
                image.SetAbsolutePosition(100, 100);
                pdfContentByte.AddImage(image);
                stamper.Close();
            }
        }
    }
}
