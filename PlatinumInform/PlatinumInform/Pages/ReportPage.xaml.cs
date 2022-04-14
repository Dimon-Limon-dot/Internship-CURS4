using PlatinumInform.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Page = System.Windows.Controls.Page;
using Microsoft.Win32;
using System.Windows.Shapes;

namespace PlatinumInform.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        Price report;
        public ReportPage()
        {
            InitializeComponent();
            cbProduct.ItemsSource = ConectDB.inform.Product.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnRepWord_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            report = dgReport.SelectedItem as Price;
            if (report != null)
            {
                try
                {
                    string source = $@"{Directory.GetCurrentDirectory()}\Информация по детали.docx";
                    Word.Application app = new Word.Application();
                    Word.Document doc = app.Documents.Open(source);
                    doc.Activate();
                    try
                    {
                        var res = ConectDB.inform.Price.Join(ConectDB.inform.Product, price => price.CodeProduct, detail => detail.CodeProduct, (price, detail) => new
                        {
                            price.Cost,
                            price.DateInsert,
                            detail.CodeOrg,
                            detail.CodeCharac,
                            detail.SerialNum,
                            detail.CodeProduct,
                            detail.NameProduct,
                            detail.NumDep
                        }).Join(ConectDB.inform.Departament, price => price.NumDep, departament => departament.NumDep, (price, departament) => new
                        {
                            price.Cost,
                            price.DateInsert,
                            price.CodeOrg,
                            price.CodeCharac,
                            price.SerialNum,
                            price.CodeProduct,
                            price.NumDep,
                            price.NameProduct,
                            departament.Name
                        }).Where(c => c.CodeProduct == report.CodeProduct).FirstOrDefault();
                        Word.Bookmarks wB = doc.Bookmarks;

                        wB["ДетальГлавная"].Range.Text = res.NameProduct.ToString();
                        wB["ДецНомер"].Range.Text = res.CodeOrg.ToString() + "." + res.CodeCharac.ToString() + "." + res.SerialNum.ToString();
                        wB["Деталь"].Range.Text = res.NameProduct.ToString();
                        wB["Цех"].Range.Text = res.Name.ToString();
                        wB["Цена"].Range.Text = res.Cost.ToString();
                        wB["ДатаУстановки"].Range.Text = res.DateInsert.ToShortDateString();
                        wB["ДатаДоговора"].Range.Text = date.ToShortDateString();
                        doc.SaveAs2($@"{Directory.GetCurrentDirectory()}\Информация по деталям\Информация по детали {res.NameProduct}.docx");
                        doc.Close();
                        doc = null;
                        app.Quit();
                        MessageBox.Show("Файл успешно создан!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        doc.Close();
                        doc = null;
                        app.Quit();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Отсутствует макет документа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите данные для создания файла!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            var app = new Excel.Application();
            try
            {
                SaveFileDialog svd = new SaveFileDialog();
                svd.Title = "Сохранить как...";
                svd.Filter = "Excel file(*.xlsx)|.*xslx";
                svd.OverwritePrompt = true;
                svd.CheckPathExists = true;
                if (svd.ShowDialog() == false)
                {
                    app.Quit();
                }
                else
                {
                    List<Price> specializationList = ConectDB.inform.Price.ToList();
                    app.Workbooks.Add(Type.Missing);
                    var worksheet = (Excel.Worksheet)app.Worksheets[1];
                    count = specializationList.Count;
                    for (int i = 0; i < count; i++)
                    {
                        worksheet.Cells[i + 1, 1] = specializationList[i].Product.NameProduct;
                        worksheet.Cells[i + 1, 2] = specializationList[i].Cost;
                    }
                    worksheet.Columns.AutoFit();
                    var xlCharts = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                    var myChart = (Excel.ChartObject)xlCharts.Add(120, 0, 350, 250);
                    var chart = myChart.Chart;
                    var seriesCollection = (Excel.SeriesCollection)chart.SeriesCollection(Type.Missing);
                    var series = seriesCollection.NewSeries();
                    series.XValues = worksheet.get_Range("A1", "A" + count);
                    series.Values = worksheet.get_Range("B1", "B" + count);
                    chart.ChartType = Excel.XlChartType.xlColumnStacked;
                    app.Application.ActiveWorkbook.SaveAs(svd.FileName);
                    app.Quit();
                    MessageBox.Show("Отчет сформирован!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                app.Quit();
            }
        }

        private void cbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product detail = (Product)cbProduct.SelectedItem;
            if (detail != null)
            {
                dgReport.ItemsSource = ConectDB.inform.Price.ToList().Where(c => c.CodeProduct == detail.CodeProduct);
            }
        }
    }
}
