using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace PDF_Search
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ReadPdfFile(string fileName, String searchText)
        {
            List<int> pages = new List<int>();
            if (File.Exists(fileName))
            {
                int page = 1;
                PdfReader pdfReader = new PdfReader(fileName);
               // for (int page = 1; page <= pdfReader.NumberOfPages; page++)
             //   {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                    string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                    if (currentPageText.Contains(searchText))
                    {
                        pages.Add(page);
                    }
               // }
                pdfReader.Close();
            }
            if (pages.Count == 0)
                return null;
            else
                return fileName;
        }

        protected void txtBoxSearchPDF_Click(object sender, EventArgs e)
        {
         //   string[] filePaths = Directory.GetFiles(@"C:\schools\syllabus");
            if (txtBoxSearchString.Text == "")
            {
                lblNoSearchString.Visible = true;
            }
            else
            {
                lblNoSearchString.Visible = false;
                var files = from file in Directory.EnumerateFiles(@"C:\schools\Birth", "*.pdf", SearchOption.AllDirectories)

                            select new
                            {
                                File = file,
                            };

                StringBuilder sb = new StringBuilder();

                foreach (var f in files)
                {
                    string fileNameOnly = string.Empty;
                    string pdfSearchMatch = ReadPdfFile(f.File, txtBoxSearchString.Text);
                    if (pdfSearchMatch != null)
                    {
                        //string domainURL = Regex.Replace(pdfSearchMatch, @"C:\\schools\\syllabus", @"https://mywebsite.com/search/syllabus/");
                        string domainURL = Regex.Replace(pdfSearchMatch, @"C:\\schools\\Birth", @"https://mywebsite.com/search/syllabus/");
                        string finalSyllabusURL = Regex.Replace(domainURL, " ", "%20");
                        fileNameOnly = Regex.Replace(domainURL, @"https://mywebsite.com/search/syllabus/", "");
                        string pdfHyperlink = @"<a href=" + finalSyllabusURL + ">" + fileNameOnly + "</a>";
                        sb.AppendLine(pdfHyperlink);
                       sb.AppendLine("<br>");

                        readfiles(fileNameOnly);
                       // string str = @"C:\\schools\\syllabus" + files.ToString(), Replace();
                        //string str = @"C:\\schools\\Found"+ files.ToString();
                       // if (!File.Exists(str))
                        //{
                        //    File.Copy(f.File, str);
                        //}
                    }

                    Regex regex = new Regex(txtBoxSearchString.Text, RegexOptions.IgnoreCase);
                    string domainURLfileName = Regex.Replace(f.File, @"C:\\schools\\Birth", @"https://mywebsite.com/search/syllabus/");
                    string finalSyllabusURLfileName = Regex.Replace(domainURLfileName, " ", "%20");
                    string fileNameOnly2 = Regex.Replace(domainURLfileName, @"https://mywebsite.com/search/syllabus/", "");
                    string pdfHyperlinkMappedDrive = @"<a href=" + finalSyllabusURLfileName + ">" + fileNameOnly2 + "</a>";

                    if ((regex.IsMatch(fileNameOnly2)) && (fileNameOnly != fileNameOnly2))
                    {
                        sb.AppendLine(pdfHyperlinkMappedDrive);
                        sb.AppendLine("<br>");
                    }
                    else
                    {
                        //moving on
                    }
                }

                Panel1.Controls.Clear();
                if (sb.ToString() != "")
                {
                    Panel1.Attributes["style"] = "height: 222px;";
                    Panel1.Controls.Add(new LiteralControl(sb.ToString()));
                    lblNoSearchString.Visible = false;


                }
                else
                {
                    string noResults = "No results matched the specified search string.";
                    Panel1.Attributes["style"] = "padding-left: 5px; height: 22px; padding-top: 2px;";
                    Panel1.Controls.Add(new LiteralControl(noResults));
                    lblNoSearchString.Visible = false;
                }
            }
        }

        public void readfiles(string filename)
        {
            //string[] filePaths = Directory.GetFiles("Your Path");
            //foreach (var filename in filePaths)
            //{
            string file = filename.ToString();

            //Do your job with "file"  
            //string str = "Your Destination" + file.ToString();
            string str = @"C:\\schools\\Birth" + file.ToString();
            //{
            //    File.Copy(file, str);
            //}

            //string path = @"C:\\schools\\Birth";
            string path1 = @"C:\\schools\\Found" + file.ToString();
            File.Copy(str, path1);
            //}
        }
    }
}