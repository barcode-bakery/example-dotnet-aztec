using BarcodeBakery.Barcode;
using BarcodeBakery.Common;
using System;
using System.Threading.Tasks;

namespace BarcodeAztec.Core.Console
{
    public class ExampleAztec
    {
        public static async Task CreateAsync(string filePath, string? text = null)
        {
            // Loading Font
            var font = new BCGFont("Arial", 14);

            // Don't forget to sanitize user inputs
            text = text?.Length > 0 ? text : "Aztec";

            // Label, this part is optional
            var label = new BCGLabel();
            label.SetFont(font);
            label.SetPosition(BCGLabel.Position.Bottom);
            label.SetAlignment(BCGLabel.Alignment.Center);
            label.SetText(text);

            // The arguments are R, G, B for color.
            var colorBlack = new BCGColor(0, 0, 0);
            var colorWhite = new BCGColor(255, 255, 255);

            Exception? drawException = null;
            BCGBarcode? barcode = null;
            try
            {
                var code = new BCGaztec();
                code.SetScale(6);
                code.SetErrorLevel(23); // Error correction level
                code.SetForegroundColor(colorBlack); // Color of bars
                code.SetBackgroundColor(colorWhite); // Color of spaces

                // Remove the following line if you don't want any label
                code.AddLabel(label);

                code.Parse(text);
                barcode = code;
            }
            catch (Exception exception)
            {
                drawException = exception;
            }

            var drawing = new BCGDrawing(barcode, colorWhite);
            if (drawException != null)
            {
                drawing.DrawException(drawException);
            }

            // Saves the barcode into a file.
            await drawing.FinishAsync(BCGDrawing.ImageFormat.Png, filePath);

            // Saves the barcode into a MemoryStream
            ////var memoryStream = new System.IO.MemoryStream();
            ////await drawing.FinishAsync(BCGDrawing.ImageFormat.Png, memoryStream);
        }
    }
}
