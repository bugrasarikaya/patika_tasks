using Aspose.BarCode.BarCodeRecognition;
using BarcodeLib;
using System.Drawing;
using System.Drawing.Imaging;
using Color = System.Drawing.Color;
namespace task_13 {
    internal class main {
        static void Main(string[] args) {
            Barcode barcode_api = new Barcode();
            int image_width = 290;
            int image_height = 120;
            Color fore_color = Color.Black;
            Color back_color = Color.Transparent;
            string data = "038000356216";
            Image barcode_image = barcode_api.Encode(TYPE.UPCA, data, fore_color, back_color, image_width, image_height);
            barcode_image.Save(@"..\..\..\generated_barcode.png", ImageFormat.Png);
            BarCodeReader reader = new BarCodeReader(@"..\..\..\generated_barcode.png");
            BarCodeResult[] result = reader.ReadBarCodes();
            Console.WriteLine("CodeText: " + result[0].CodeText);
        }
    }
}